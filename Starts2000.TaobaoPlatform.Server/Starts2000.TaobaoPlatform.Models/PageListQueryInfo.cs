using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class PageListQueryInfo<T> : PageListInfo
    {
        [ProtoMember(1)]
        public T Query
        {
            get;
            set;
        }
    }
}