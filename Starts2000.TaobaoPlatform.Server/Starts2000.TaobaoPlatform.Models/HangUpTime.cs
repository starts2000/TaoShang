using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class HangUpTime
    {
        /// <summary>
        /// 
        /// </summary>
        public HangUpTime()
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
        public int UserId
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int Minutes
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public DateTime DateTime
        {
            get;
            set;
        }
    }
}