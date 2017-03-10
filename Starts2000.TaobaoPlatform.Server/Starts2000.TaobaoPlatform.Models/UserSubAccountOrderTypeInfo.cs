using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class UserSubAccountOrderTypeInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public UserSubAccountOrderTypeInfo()
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
        public int OrderTypeId
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int Count
        {
            get;
            set;
        }
    }
}