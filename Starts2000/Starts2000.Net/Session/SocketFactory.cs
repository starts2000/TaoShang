using System.Net.Sockets;

namespace Starts2000.Net.Session
{
    internal class SocketFactory
    {
        public static Socket CreateSocket(SessionType sessionType)
        {
            Socket socket = null;

            switch (sessionType)
            {
                case SessionType.Tcp:
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    break;
                case SessionType.Udp:
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    break;
            }

            return socket;
        }
    }
}
