using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class UpdateInfo
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public int ClientType { get; set; }

        [ProtoMember(3)]
        public DateTime LastUpdateTime { get; set; }

        [ProtoMember(4)]
        public string Version { get; set; }
    }
}