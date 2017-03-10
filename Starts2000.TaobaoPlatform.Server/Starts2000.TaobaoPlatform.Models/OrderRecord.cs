using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    [ProtoInclude(100, typeof(OrderRecordDetails))]
    public class OrderRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderRecord()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int Id
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public int UserId
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int? UserShopId
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public int ClientUserId
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public int ClientUserSubAccountId
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public string ClientUserSubAccount
        {
            get;
            set;
        }

        [ProtoMember(7)]
        public string OrderNum
        {
            get;
            set;
        }

        [ProtoMember(8)]
        public int OrderStateId
        {
            get;
            set;
        }

        [ProtoMember(9)]
        public int? OrderTypeId
        {
            get;
            set;
        }

        [ProtoMember(10)]
        public DateTime StartDateTime
        {
            get;
            set;
        }

        [ProtoMember(11)]
        public DateTime LastUpdateDateTime
        {
            get;
            set;
        }

        [ProtoMember(12)]
        public string OrderIp
        {
            get;
            set;
        }
    }
}