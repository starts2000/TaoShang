using System.Net.Sockets;
using Starts2000.Net.Buffer;

namespace Starts2000.Net.Pool
{
    /// <summary>
    /// 定义用于异步套接字操作的 <see cref="SocketAsyncEventArgs"/> 对象缓存池的基本功能。
    /// </summary>
    public interface ISocketAsyncEventArgsPool
    {
        int AllocatedCount { get; }
        int PooledCount { get; }
        int WeakPooledCount { get; }

        /// <summary>
        /// 从缓存池中获取一个用于异步套接字操作的 <see cref="SocketAsyncEventArgs"/> 对象。
        /// </summary>
        /// <returns>一个用于异步套接字操作的 <see cref="SocketAsyncEventArgs"/> 对象。</returns>
        SocketAsyncEventArgs Take();

        /// <summary>
        /// 异步套接字操作的 <see cref="SocketAsyncEventArgs"/> 对象返回缓存池。
        /// </summary>
        /// <param name="saea"></param>
        void Return(SocketAsyncEventArgs saea);
    }
}
