using System.ServiceModel.Channels;

namespace Starts2000.Net.Buffer
{
    public static class BufferManagerFactory
    {
        static BufferManager _bufferManager;

        static BufferManagerFactory()
        {
            _bufferManager = BufferManager.CreateBufferManager(1024 * 1024 * 32, 1024 * 1024);
        }

        public static BufferManager BufferManager
        {
            get { return _bufferManager; }
        }
    }
}
