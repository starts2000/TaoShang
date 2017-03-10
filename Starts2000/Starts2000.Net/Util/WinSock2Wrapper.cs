using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Starts2000.Net.Util
{
    internal static class WinSock2Wrapper
    {
        static readonly byte[] KeepAliveOff = BitConverter.GetBytes((uint)0);
        static readonly byte[] KeepAliveOn = BitConverter.GetBytes((uint)1);
        static readonly int UintSize = Marshal.SizeOf(typeof(uint));

        public const int INT32_LENGTH = 4;
        public const int SO_CONNECT_TIME = 0x700C;

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int getsockopt(IntPtr socketHandle, int level, int optname, out int optval, ref int optlen);

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int WSAGetLastError();

        public static int GetConnectTime(Socket socket)
        {
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }

            int num;
            int optlen = INT32_LENGTH;

            if (getsockopt(socket.Handle, 0xffff, SO_CONNECT_TIME, out num, ref optlen) != 0)
            {
                throw new SocketException(WSAGetLastError());
            }

            return num;
        }

        public static IPEndPoint QueryRoutingInterface(Socket socket, IPEndPoint remoteEP)
        {
            ValidateHelper.CheckNullArgument("sock", socket);
            ValidateHelper.CheckNullArgument("remoteEP", remoteEP);

            SocketAddress socketAddress = remoteEP.Serialize();
            byte[] optionInValue = new byte[socketAddress.Size];

            for (int i = 0; i < socketAddress.Size; i++)
            {
                optionInValue[i] = socketAddress[i];
            }

            byte[] optionOutValue = new byte[optionInValue.Length];
            socket.IOControl(IOControlCode.RoutingInterfaceQuery, optionInValue, optionOutValue);

            for (int j = 0; j < socketAddress.Size; j++)
            {
                socketAddress[j] = optionOutValue[j];
            }

            IPEndPoint point = (IPEndPoint)remoteEP.Create(socketAddress);
            point.Port = ((IPEndPoint)socket.LocalEndPoint).Port;
            return point;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="on"></param>
        /// <param name="time">开始首次KeepAlive探测前的TCP空闭时间，单位为毫秒。</param>
        /// <param name="interval">两次KeepAlive探测间的时间间隔，单位为毫秒。</param>
        public static void SetKeepAlive(Socket socket, bool on, uint time, uint interval)
        {
            byte[] dst = new byte[UintSize * 3];
            System.Buffer.BlockCopy(on ? KeepAliveOn : KeepAliveOff, 0, dst, 0, UintSize);
            System.Buffer.BlockCopy(BitConverter.GetBytes(time), 0, dst, UintSize, UintSize);
            System.Buffer.BlockCopy(BitConverter.GetBytes(interval), 0, dst, UintSize * 2, UintSize);
            socket.IOControl(IOControlCode.KeepAliveValues, dst, null);
        }
    }
}
