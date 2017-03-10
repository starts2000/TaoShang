using System;

namespace Starts2000.TaoBaoTool.IBll
{
    interface IOnlineCheckBll
    {
        void Check(Action<OnlineCheckState> checkResponse);

        void CheckResponse(OnlineCheckState state);
    }
}
