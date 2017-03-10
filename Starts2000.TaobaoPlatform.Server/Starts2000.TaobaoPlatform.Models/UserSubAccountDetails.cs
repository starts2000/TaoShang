using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class UserSubAccountDetails : UserSubAccount
    {
        public UserSubAccountDetails()
        {
            OrderTypeDetails = new List<OrderTypeDetails>();
        }

        [ProtoMember(1)]
        public User User { get; set; }

        [ProtoMember(2)]
        public UserLoginState UserLoginState { get; set; }

        [ProtoMember(3)]
        public int? DayOrderCount
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public int? MonthOrderCount
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public IList<OrderTypeDetails> OrderTypeDetails { get; set; }
    }
}