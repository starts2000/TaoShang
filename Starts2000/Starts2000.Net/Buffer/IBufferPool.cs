namespace Starts2000.Net.Buffer
{
    public interface IBufferPool
    {
        IBuffer Allocate(int capacity);
    }
}
