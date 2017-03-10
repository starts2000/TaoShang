using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class UserSubAccountPageListQuery
    {
        [ProtoMember(1)]
        public string ProvinceName { get; set; }
        [ProtoMember(2)]
        public string CityName { get; set; }
        [ProtoMember(3)]
        public string DistrictName { get; set; }
    }
}