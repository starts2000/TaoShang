using System;

namespace Starts2000
{
    /// <summary>
    /// 实现 <see cref="IDisposable"/> 接口标准模式的抽象类。
    /// </summary>
    public abstract class DisposableBase : IDisposable
    {
        bool _isDisposed;

        /// <summary>
        /// 获取资源是否已经释放。
        /// </summary>
        /// <returns>如果资源已经释放，则为：true，否则为：false。</returns>
        protected bool IsDisposed
        {
            get { return _isDisposed; }
        }

        /// <summary>
        /// 实例化 <see cref="DisposableBase"/>。
        /// </summary>
        protected DisposableBase()
        {
        }

        ~DisposableBase()
        {
            try
            {
                Dispose(false);
                GC.SuppressFinalize(true);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// 执行与释放或重置非托管资源相关的应用程序定义的任务。
        /// </summary>
        /// <param name="isDisposing">表示是否释放托管资源，如果是，则为：true，否则为：false。</param>
        protected void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    ReleaseManagedResources();
                }

                ReleaseUnManagedResources();
                _isDisposed = true;
            }
        }

        /// <summary>
        /// 释放或重置托管资源。
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
        }

        /// <summary>
        /// 释放或重置非托管资源。
        /// </summary>
        protected abstract void ReleaseUnManagedResources();
    }
}