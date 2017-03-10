using System.Net.Sockets;

namespace Starts2000.Net.Buffer
{
    internal class FixedBufferManager
    {
        #region Fields

        readonly byte[] _buffer;
        int _bufferSize;
        int _totalBufferSize;
        int _currentIndex;

        #endregion

        #region Constructor

        public FixedBufferManager(int totalBufferSize, int bufferSize)
        {
            _totalBufferSize = totalBufferSize;
            _bufferSize = bufferSize;
            _buffer = new byte[totalBufferSize];
        }

        #endregion

        #region Methods

        public bool SetBuffer(SocketAsyncEventArgs args)
        {
            if (_totalBufferSize - _bufferSize < _currentIndex)
            {
                return false;
            }

            args.SetBuffer(_buffer, _currentIndex, _bufferSize);
            _currentIndex += _bufferSize;

            return true;
        }

        #endregion
    }
}
