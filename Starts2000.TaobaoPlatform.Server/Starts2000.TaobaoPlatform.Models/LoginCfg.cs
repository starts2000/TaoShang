using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class LoginCfg
    {
        /// <summary>
        /// 
        /// </summary>
        public LoginCfg()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public string Account
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string Password
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public bool RememberPassword
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public bool AutoLogin
        {
            get;
            set;
        }
    }
}