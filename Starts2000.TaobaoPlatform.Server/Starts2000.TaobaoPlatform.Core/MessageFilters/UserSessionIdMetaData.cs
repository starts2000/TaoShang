using System;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    class UserSessionIdMetaData : ISessionIdMetaData
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public bool IsClient { get; set; }
        public UpdateInfo UpdateInfo { get; set; }
        public DateTime? LastCalcTime { get; set; }

        #region IEquatable<ISessionIdMetaData> 成员

        public bool Equals(ISessionIdMetaData other)
        {
            var otherUser = other as UserSessionIdMetaData;
            if (otherUser == null)
            {
                return false;
            }

            if(object.ReferenceEquals(this, other))
            {
                return true;
            }

            if((otherUser.Id == this.Id || string.Equals(otherUser.Account, 
                this.Account, StringComparison.CurrentCultureIgnoreCase)) && 
                otherUser.IsClient == this.IsClient)
            {
                return true;
            }

            return false;
        }

        #endregion

        public override bool Equals(object obj)
        {
            var user = obj as ISessionIdMetaData;
            return Equals(user);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Account.GetHashCode() ^ IsClient.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Id:{0}, Account:{1}, IsClient:{2}.", Id, Account, IsClient);
        }
    }
}