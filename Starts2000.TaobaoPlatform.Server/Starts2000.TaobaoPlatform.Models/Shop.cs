using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class Shop
    {
        /// <summary>
        /// 
        /// </summary>
        public Shop()
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
        public string WangWangAccount
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string ShopName
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public string ShopLevel
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public string ShopUrl
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public bool Audit
        {
            get;
            set;
        }

        [ProtoMember(7)]
        public int UserId
        {
            get;
            set;
        }
    }
}