using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class OrderState
    {
        [ProtoMember(1)]
        public int Id
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string Name
        {
            get;
            set;
        }
    }
}
