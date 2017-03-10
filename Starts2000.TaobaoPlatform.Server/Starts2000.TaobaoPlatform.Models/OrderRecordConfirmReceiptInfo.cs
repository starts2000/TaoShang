using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class OrderRecordConfirmReceiptInfo
    {
        [ProtoMember(1)]
        public string ClientUserSubAccount
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string OrderNum
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string PayPassWord
        {
            get;
            set;
        }
    }
}
