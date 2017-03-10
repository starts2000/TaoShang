using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    [ProtoInclude(100, typeof(PageListQueryInfo<UserSubAccountPageListQuery>))]
    [ProtoInclude(200, typeof(PageListQueryInfo<OrderRecordPageListQuery>))]
    public class PageListInfo
    {
        public PageListInfo()
        {

        }

        [ProtoMember(1)]
        public int PageSize
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public int PageIndex
        {
            get;
            set;
        }

        [ProtoMember(3)]
        public int Count
        {
            get;
            set;
        }
    }
}