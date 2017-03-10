namespace Starts2000.Net.Buffer
{
    public sealed class DefaultBufferPool : IBufferPool
    {
        static readonly DefaultBufferPool _instance = new DefaultBufferPool();

        public static DefaultBufferPool Instance
        {
            get { return _instance; }
        }

        public IBuffer Allocate(int capacity)
        {
            byte[] buffer = BufferManagerFactory.BufferManager.TakeBuffer(capacity);
            return new PooledByteArrayBuffer(buffer, 0, buffer.Length) { Limit = capacity };
        }

        #region PooledByteArrayBuffer

        private sealed class PooledByteArrayBuffer : ByteArrayBuffer
        {
            public PooledByteArrayBuffer(int capacity)
                : base(capacity)
            {
            }

            public PooledByteArrayBuffer(byte[] content, int offset, int capacity)
                : base(content, offset, capacity)
            {
            }

            protected override void InternalRelease()
            {
                BufferManagerFactory.BufferManager.ReturnBuffer(base.ByteArray);
                base.InternalRelease();
            }
        }

        #endregion
    }
}
