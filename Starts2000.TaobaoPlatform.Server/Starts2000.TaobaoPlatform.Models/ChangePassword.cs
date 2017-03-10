using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class ChangePassword
    {
        [ProtoMember(1)]
        public int Id
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string OldPassword
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string NewPassword
        {
            get;
            set;
        }
    }
}