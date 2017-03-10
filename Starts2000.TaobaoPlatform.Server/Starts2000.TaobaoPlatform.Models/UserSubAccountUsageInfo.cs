using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class UserSubAccountUsageInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public UserSubAccountUsageInfo()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int UserSubAccountId
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public int DayOrderCount
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int MonthOrderCount
        {
            get;
            set;
        }
    }
}
