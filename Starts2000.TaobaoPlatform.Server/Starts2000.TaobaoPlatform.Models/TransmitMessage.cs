using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class TransmitData<TData>
    {
        [ProtoMember(1)]
        public User ToUser
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public TData Data
        {
            get;
            set;
        }
    }
}