using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class UserLoginState
    {
        /// <summary>
        /// 
        /// </summary>
        public UserLoginState()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int UserId
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string ClientLastLoginIpAddress
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string OptLastLoginIpAddress
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public bool ClientLogin
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public DateTime? OptLastLoginTime
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public DateTime? ClientLastLoginTime
        {
            get;
            set;
        }
    }
}
