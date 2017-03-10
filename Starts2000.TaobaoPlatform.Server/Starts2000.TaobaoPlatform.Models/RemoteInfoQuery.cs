using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class RemoteInfoQuery
    {
        [ProtoMember(1)]
        public int UserId { get; set; }

        [ProtoMember(2)]
        public string UserAccount { get; set; }

        [ProtoMember(3)]
        public int SubAccountId { get; set; }

        [ProtoMember(4)]
        public string SubAccount { get; set; }
    }
}