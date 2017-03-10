using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Account { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; }

        [ProtoMember(4)]
        public string Name { get; set; }

        [ProtoMember(5)]
        public string QQ { get; set; }

        [ProtoMember(6)]
        public string Email { get; set; }

        [ProtoMember(7)]
        public string Mobile { get; set; }

        [ProtoMember(8)]
        public string ReferrerAccount { get; set; }

        [ProtoMember(9)]
        public string Salt { get; set; }

        [ProtoMember(10)]
        public bool Lock { get; set; }

        [ProtoMember(11)]
        public int Gold { get; set; }

        [ProtoMember(12)]
        public bool IsClient
        {
            get;
            set;
        }

        [ProtoMember(13)]
        public bool IsAudit
        {
            get;
            set;
        }

        [ProtoMember(14)]
        public DateTime? ExpireDate
        {
            get;
            set;
        }

        [ProtoMember(15)]
        public int? MemberLevelId
        {
            get;
            set;
        }
    }
}