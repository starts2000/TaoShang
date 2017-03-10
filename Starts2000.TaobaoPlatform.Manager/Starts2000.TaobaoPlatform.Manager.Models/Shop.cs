using System;

namespace Starts2000.TaobaoPlatform.Manager.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Shop
    {
        /// <summary>
        /// 
        /// </summary>
        public Shop()
        {
            ///Todo
        }

        public int Id
        {
            get;
            set;
        }

        public string WangWangAccount
        {
            get;
            set;
        }

        public string ShopName
        {
            get;
            set;
        }

        public string ShopLevel
        {
            get;
            set;
        }

        public string ShopUrl
        {
            get;
            set;
        }

        public bool Audit
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
