using System;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.Bll
{
    internal class OnlineCheckBll : IOnlineCheckBll
    {
        Action<OnlineCheckState> _checkResponse;

        #region IOnlineCheckBll 成员

        public void Check(Action<OnlineCheckState> checkResponse)
        {
            _checkResponse = checkResponse;

            var future = Global.SendToServer("CheckOnline", MessageType.CheckOnlineRequest);
            if(future == null)
            {
                CheckResponse(OnlineCheckState.CannotConnectServer);
            }
        }

        public void CheckResponse(OnlineCheckState state)
        {
            if(_checkResponse != null)
            {
                _checkResponse(state);
            }
        }

        #endregion
    }
}
