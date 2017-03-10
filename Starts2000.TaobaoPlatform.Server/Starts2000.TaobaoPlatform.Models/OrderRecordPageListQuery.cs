using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class OrderRecordPageListQuery
    {
        [ProtoMember(1)]
        public int? ShopId { get; set; }

        [ProtoMember(2)]
        public int? OrderStateId { get; set; }
    }
}