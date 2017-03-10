using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    [ProtoInclude(100, typeof(UserSubAccountDetails))]
    public class UserSubAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public UserSubAccount()
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
        public string TaoBaoAccount
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string Password
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public string PayPassword
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public string HomePage
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public byte? Level
        {
            get;
            set;
        }

        [ProtoMember(7)]
        public byte? ConsumptionLevel
        {
            get;
            set;
        }

        [ProtoMember(8)]
        public string Province
        {
            get;
            set;
        }

        [ProtoMember(9)]
        public string City
        {
            get;
            set;
        }

        [ProtoMember(10)]
        public string District
        {
            get;
            set;
        }

        [ProtoMember(11)]
        public byte? Age
        {
            get;
            set;
        }

        [ProtoMember(12)]
        public bool? Sex
        {
            get;
            set;
        }

        [ProtoMember(13)]
        public int? UpperLimitAmount
        {
            get;
            set;
        }

        [ProtoMember(14)]
        public int? UpperLimitNumber
        {
            get;
            set;
        }

        [ProtoMember(15)]
        public int? Commission
        {
            get;
            set;
        }

        [ProtoMember(16)]
        public string ShippingAddress
        {
            get;
            set;
        }

        [ProtoMember(17)]
        public bool IsRealName
        {
            get;
            set;
        }

        [ProtoMember(18)]
        public bool IsBindingMobile
        {
            get;
            set;
        }

        [ProtoMember(19)]
        public bool IsEnabled
        {
            get;
            set;
        }

        [ProtoMember(20)]
        public bool IsAudit
        {
            get;
            set;
        }

        [ProtoMember(21)]
        public int UserId
        {
            get;
            set;
        }
    }
}