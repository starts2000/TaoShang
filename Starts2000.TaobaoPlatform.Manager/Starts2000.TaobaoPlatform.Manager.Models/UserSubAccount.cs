using System;

namespace Starts2000.TaobaoPlatform.Manager.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserSubAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public UserSubAccount()
        {
            ///Todo
        }

        public int Id
        {
            get;
            set;
        }

        public string TaoBaoAccount
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string PayPassword
        {
            get;
            set;
        }

        public string HomePage
        {
            get;
            set;
        }

        public byte? Level
        {
            get;
            set;
        }

        public byte? ConsumptionLevel
        {
            get;
            set;
        }

        public string Province
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string District
        {
            get;
            set;
        }

        public byte? Age
        {
            get;
            set;
        }

        public bool Sex
        {
            get;
            set;
        }

        public int UpperLimitAmount
        {
            get;
            set;
        }

        public int UpperLimitNumber
        {
            get;
            set;
        }

        public int Commission
        {
            get;
            set;
        }

        public string ShippingAddress
        {
            get;
            set;
        }

        public bool IsRealName
        {
            get;
            set;
        }

        public bool IsBindingMobile
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }

        public bool IsAudit
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }
    }
}
