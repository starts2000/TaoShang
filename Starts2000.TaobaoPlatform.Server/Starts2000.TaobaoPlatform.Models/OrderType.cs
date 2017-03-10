using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class OrderType
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderType()
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
        public string Name
        {
            get;
            set;
        }
    }


    [Serializable]
    [ProtoContract]
    public class OrderTypeDetails
    {
        [ProtoMember(1)]
        [Column(Name = "OrderTypeDetails_Id")]
        public int? Id
        {
            get;
            set;
        }

        [ProtoMember(2)]
        [Column(Name = "OrderTypeDetails_Name")]
        public string Name
        {
            get;
            set;
        }

        [ProtoMember(3)]
        [Column(Name = "OrderTypeDetails_Count")]
        public int Count
        {
            get;
            set;
        }
    }
}
