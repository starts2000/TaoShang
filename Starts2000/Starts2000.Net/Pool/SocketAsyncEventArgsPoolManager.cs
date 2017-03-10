using System.Net.Sockets;
using Starts2000.Net.Session;

namespace Starts2000.Net.Pool
{
    internal sealed class SocketAsyncEventArgsPoolManager
    {
        #region Fields

        readonly ISocketAsyncEventArgsPool _receiveSaeaPool;
        readonly ISocketAsyncEventArgsPool _sendSaeaPool;
        readonly static SocketAsyncEventArgsPoolManager _instance = new SocketAsyncEventArgsPoolManager();

        internal const int SendSaeaPoolSize = 2048;
        internal const int ReceiveSaeaPoolSize = 2048;
        internal const int ReceiveBufferSize = 8192;

        #endregion

        #region Properties

        internal static SocketAsyncEventArgsPoolManager Instance
        {
            get { return _instance; }
        }

        internal ISocketAsyncEventArgsPool ReceiveSaeaPool
        {
            get { return _receiveSaeaPool; }
        }

        internal ISocketAsyncEventArgsPool SendSaeaPool
        {
            get { return _sendSaeaPool; }
        }

        #endregion

        #region Constructors

        private SocketAsyncEventArgsPoolManager()
        {
            _receiveSaeaPool = new BufferedSocketAsyncEventArgsPool(
                ReceiveSaeaPoolSize, ReceiveBufferSize, IOCompleted);
            _sendSaeaPool = new SocketAsyncEventArgsPool(SendSaeaPoolSize, IOCompleted);
        }

        #endregion

        #region Methods

        void IOCompleted(object sender, SocketAsyncEventArgs e)
        {
            var userToken = e.UserToken as AsyncSocketSessionToken;
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Send:
                case SocketAsyncOperation.SendTo:
                    if (userToken.Session != null)
                    {
                        userToken.Session.ProcessSend(e);
                    }
                    break;
                case SocketAsyncOperation.Receive:
                case SocketAsyncOperation.ReceiveFrom:
                    if (userToken.Session != null)
                    {
                        userToken.Session.ProcessReceive(e);
                    }
                    break;
            }
        }

        #endregion
    }
}
