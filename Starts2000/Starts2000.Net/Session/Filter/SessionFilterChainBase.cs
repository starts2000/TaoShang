using System;
using System.Reflection;
using Starts2000.Logging;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public abstract class SessionFilterChainBase : ISessionFilterChain
    {
        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);
        static readonly ISessionFilter NullFilter = new NullFilter();

        #region Properties

        protected abstract ISessionFilter NextFilter { get; }

        public abstract ISession Session { get; }

        #endregion

        #region Constructor

        protected SessionFilterChainBase()
        {
        }

        #endregion

        #region Methods

        public void ObjectReceived(object obj)
        {
            try
            {
                Next().ObjectReceived(this, obj);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void ObjectSent(object obj)
        {
            try
            {
                Next().ObjectSent(this, obj);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void PacketReceived(IPacket packet)
        {
            try
            {
                Next().PacketReceived(this, packet);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
                throw;
            }
        }

        public void PacketSend(IPacket packet)
        {
            try
            {
                Next().PacketSend(this, packet);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void PacketSent(IPacket packet)
        {
            try
            {
                Next().PacketSent(this, packet);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void SessionStateChanged()
        {
            try
            {
                Next().SessionStateChanged(this);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void SessionTimeout()
        {
            try
            {
                Next().SessionTimeout(this);
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void ExceptionCaught(Exception exception)
        {
            try
            {
                Next().ExceptionCaught(this, exception);
            }
            catch (Exception ex)
            {
                if (_log.IsWarnEnabled)
                {
                    _log.Warn("Exception caught failed.", ex);
                }
            }
        }

        protected void CaughtException(Exception exception)
        {
            Session.GetSessionFilterChain(FilterChainMode.Receive).ExceptionCaught(exception);
        }

        ISessionFilter Next()
        {
            ISessionFilter nextFilter = NextFilter;

            if (nextFilter != null)
            {
                return nextFilter;
            }

            return NullFilter;
        }

        #endregion
    }
}
