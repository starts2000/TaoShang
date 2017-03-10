using System;
using System.Threading;

namespace Starts2000.Threading
{
    public sealed class LightLock : IDisposable
    {
        bool _isDisposed = false;
        int _lockState;

        readonly Semaphore _waiterLock = new Semaphore(0, int.MaxValue);

        const int LockIsFree = 0;
        const int LockIsOwned = 1;
        const int WaitersCountBase = 2;

        public void Enter()
        {
            Enter(-1);
        }

        public void Enter(int timeout)
        {
            CheckDisposed();
            Thread.BeginCriticalRegion();

            while (true)
            {
                int ifThisEqualsToValue = InterlockedEx.Or(ref _lockState, LockIsOwned);

                if ((ifThisEqualsToValue & LockIsOwned) == LockIsFree)
                {
                    return;
                }

                if (InterlockedEx.CompareAndExchange(
                    ref _lockState, ifThisEqualsToValue, ifThisEqualsToValue + WaitersCountBase))
                {
                    _waiterLock.WaitOne(timeout, false);
                }
            }
        }

        public void Exit()
        {
            CheckDisposed();

            int num = InterlockedEx.And(ref _lockState, -2);
            if (num != 1)
            {
                num &= -2;
                if (InterlockedEx.CompareAndExchange(ref _lockState, num & -2, num - 2))
                {
                    _waiterLock.Release(1);
                }
            }

            Thread.EndCriticalRegion();
        }

        public void Dispose()
        {
            CheckDisposed();

            try
            {
                _waiterLock.Close();
            }
            finally
            {
                _isDisposed = true;
            }
        }

        void CheckDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(null);
            }
        }
    }
}
