using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class LoginInfo
    {
        [ProtoMember(1)]
        public User User { get; set; }

         [ProtoMember(2)]
        public UpdateInfo UpdateInfo { get; set; }
    }
}
