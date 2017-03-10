namespace Starts2000.Net.Buffer
{
    public static class BufferFactory
    {
        public static IBuffer GetBuffer(int capacity)
        {
            return GetBufferPool().Allocate(capacity);
        }

        public static IBufferPool GetBufferPool()
        {
            return DefaultBufferPool.Instance;
        }

        public static IBuffer Wrap(byte[] array)
        {
            return ByteArrayBuffer.Wrap(array);
        }

        public static IBuffer Wrap(byte[] array, int offset, int count)
        {
            return ByteArrayBuffer.Wrap(array, offset, count);
        }
    }
}
