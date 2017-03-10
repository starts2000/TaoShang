using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class OrderRecordDetails : OrderRecord
    {
        [ProtoMember(1)]
        public string UserShopWangWangAccount
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string ClientUserAccount
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public bool ClientUserLogin
        {
            get;
            set;
        }
    }
}
