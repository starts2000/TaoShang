using System;

namespace Starts2000.TaobaoPlatform.Manager.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        public User()
        {
            ///Todo
        }

        public int Id
        {
            get;
            set;
        }

        public string Account
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string QQ
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Mobile
        {
            get;
            set;
        }

        public string ReferrerAccount
        {
            get;
            set;
        }

        public string Salt
        {
            get;
            set;
        }

        public bool Lock
        {
            get;
            set;
        }

        public int Gold
        {
            get;
            set;
        }

        public bool IsAudit
        {
            get;
            set;
        }

        public DateTime? ExpireDate
        {
            get;
            set;
        }

        public int? MemberLevelId
        {
            get;
            set;
        }
    }
}
