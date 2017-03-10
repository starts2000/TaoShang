using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class Page<TModel>
    {
        [ProtoMember(1)]
        public PageListInfo Info { get; set; }

        [ProtoMember(2)]
        public IList<TModel> List { get; set; }
    }
}
