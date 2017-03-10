using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;

namespace Starts2000.TaoBao.Core
{
    internal class MessageFilterInfo
    {
        internal Type Type { get; set; }
        internal IMessageFilter Filter { get; set; }
    }

    internal interface IMessageFilter
    {
        void MessageHandler(IMessage msg, SessionEventArgs e);
    }
}
