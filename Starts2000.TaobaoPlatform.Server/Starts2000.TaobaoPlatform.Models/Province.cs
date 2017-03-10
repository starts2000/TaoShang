using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class Province
    {
        /// <summary>
        /// 
        /// </summary>
        public Province()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int ProvinceID
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string ProvinceName
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public DateTime DateCreated
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public DateTime DateUpdated
        {
            get;
            set;
        }
    }
}