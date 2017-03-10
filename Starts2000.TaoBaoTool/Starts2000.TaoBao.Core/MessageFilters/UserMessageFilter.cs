using System;
using Ninject;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.MessageFilters
{
    class UserMessageFilter : MessageFilterBase
    {
        readonly IUserBll _userBll;
        readonly IOnlineCheckBll _onlineCheckBll;

        [Inject]
        public UserMessageFilter(IUserBll userBll, IOnlineCheckBll onlineCheckBll)
        {
            _userBll = userBll;
            _onlineCheckBll = onlineCheckBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.RegisterResponse:
                        _userBll.RegisterResponse((RegisterState)msg.Obj);
                        break;
                    case MessageType.LoginResponse:
                    case MessageType.ClientLoginReponse:
                        _userBll.LoginResponse((LoginState)msg.Obj);
                        break;
                    case MessageType.ReLoginResponse:
                    case MessageType.ClientReLoginReponse:
                        _userBll.ReLoginResponse((LoginState)msg.Obj);
                        break;
                    case MessageType.CheckOnlineResponse:
                        _onlineCheckBll.CheckResponse((OnlineCheckState)msg.Obj);
                        break;
                    case MessageType.GetUserInfoResponse:
                        _userBll.GetInfoResponse(
                            msg.Obj as DataResponse<UserOptState, User>);
                        break;
                    case MessageType.ChangePasswordResponse:
                        _userBll.ChangePasswordResponse((ChangePasswordState)msg.Obj);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }
    }
}