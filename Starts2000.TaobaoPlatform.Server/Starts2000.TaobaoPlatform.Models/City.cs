using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class City
    {
        /// <summary>
        /// 
        /// </summary>
        public City()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int CityID
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string CityName
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public string ZipCode
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public int ProvinceID
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public DateTime DateCreated
        {
            get;
            set;
        }

        [ProtoMember(6)]
        public DateTime DateUpdated
        {
            get;
            set;
        }
    }
}
