using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class RemoteClientInfo
    {
        [ProtoMember(1)]
        public string RemoteId
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string RemotePassword
        {
            get;
            set;
        }
    }
}