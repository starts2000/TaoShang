using System.Collections.Generic;
namespace Starts2000.TaobaoPlatform.Models
{
    public class UserSubAccountPageListVM
    {
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

        public bool? Sex
        {
            get;
            set;
        }

        public int? UpperLimitAmount
        {
            get;
            set;
        }

        public int? UpperLimitNumber
        {
            get;
            set;
        }

        public int? Commission
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

        public int UserId
        {
            get;
            set;
        }

        public string UserAccount
        {
            get;
            set;
        }

        public bool ClientLogin
        {
            get;
            set;
        }

        public string IpAddress
        {
            get;
            set;
        }

        public int? DayOrderCount
        {
            get;
            set;
        }

        public int? MonthOrderCount
        {
            get;
            set;
        }

        public IList<OrderTypeDetails> OrderTypeDetails
        {
            get;
            set;
        }
    }
}