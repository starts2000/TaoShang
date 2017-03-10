using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Logging;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    abstract class MessageFilterBase : IMessageFilter
    {
        [Inject]
        public ILoggerFactory LoggerFactory {protected get; set; }

        protected MessageFilterBase()
        {

        }

        public virtual void MessageHandler(IMessage msg, SessionEventArgs e)
        {            
            try
            {
                LoggerFactory.GetCurrentClassLogger().Info("MessageType: [{0}], RemoteIP:[{1}], {2}",
                    (MessageType)msg.Header.Type, e.Session.RemoteEndPoint, e.Session.SessionId);
            }
            catch
            {

            }
        }

        protected void ErrorLog(ushort type, Exception ex)
        {
            LoggerFactory.GetCurrentClassLogger().ErrorException(string.Format(
                   "MessageType: [{0}].", (MessageType)type), ex);
        }
    }
}