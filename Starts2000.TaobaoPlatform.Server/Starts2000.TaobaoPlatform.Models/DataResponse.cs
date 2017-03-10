using System;
using ProtoBuf;

namespace Starts2000.TaobaoPlatform.Models
{
    [Serializable]
    [ProtoContract]
    public class DataResponse<TState, TData>
    {
        [ProtoMember(1)]
        public TState State
        {
            get;
            set;
        }

        [ProtoMember(2)]
        public TData Data
        {
            get;
            set;
        }
    }
}
