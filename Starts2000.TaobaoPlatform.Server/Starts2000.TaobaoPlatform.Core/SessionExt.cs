using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;
using Starts2000.Net.Session.Future;

namespace Starts2000.TaobaoPlatform.Core
{
    internal static class SessionExt
    {
        internal static IFuture Send(this ISession session, object data, MessageType type,
            ushort subType = 0, bool zip = false, bool encrypted = false)
        {
            if (session.IsOpened)
            {
                return session.Send(new DefaultMessage(data, (ushort)type, subType, zip, encrypted));
            }

            return null;
        }
    }
}
