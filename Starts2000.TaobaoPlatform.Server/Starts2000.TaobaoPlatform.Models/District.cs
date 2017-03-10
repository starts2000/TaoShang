using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [ProtoContract]
    public class District
    {
        /// <summary>
        /// 
        /// </summary>
        public District()
        {
            ///Todo
        }

        [ProtoMember(1)]
        public int DistrictID
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public string DistrictName
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int CityID
        {
            get;
            set;
        }

        [ProtoMember(4)]
        public DateTime DateCreated
        {
            get;
            set;
        }

        [ProtoMember(5)]
        public DateTime DateUpdated
        {
            get;
            set;
        }
    }
}