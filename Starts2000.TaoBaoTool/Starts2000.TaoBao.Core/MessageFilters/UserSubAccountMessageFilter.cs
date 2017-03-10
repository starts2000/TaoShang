using System;
using System.Collections.Generic;
using Ninject;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.MessageFilters
{
    class UserSubAccountMessageFilter : MessageFilterBase
    {
        readonly IUserSubAccountBll _userSubAccountBll;

        [Inject]
        public UserSubAccountMessageFilter(IUserSubAccountBll userSubAccountBll)
        {
            _userSubAccountBll = userSubAccountBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.AddUserSubAccountResponse:
                        _userSubAccountBll.AddResponse((UserSubAccountOptState)msg.Obj);
                        break;
                    case MessageType.UpdateUserSubAccountResponse:
                        _userSubAccountBll.UpdateResponse((UserSubAccountOptState)msg.Obj);
                        break;
                    case MessageType.DeleteUserSubAccountResponse:
                        _userSubAccountBll.DeleteResponse((UserSubAccountOptState)msg.Obj);
                        break;
                    case MessageType.GetUserSubAccountListResponse:
                        _userSubAccountBll.GetListResponse(
                            msg.Obj as DataResponse<UserSubAccountOptState, IList<UserSubAccount>>);
                        break;
                    case MessageType.GetSubAccountPageListResponse:
                        _userSubAccountBll.GetPageListResponse(
                            msg.Obj as DataResponse<UserSubAccountOptState, Page<UserSubAccountDetails>>);
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