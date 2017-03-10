using System;
using System.Collections.Generic;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    internal class UserSubAccountMessageFilter : MessageFilterBase
    {
        readonly IUserSubAccountBll _subAccountBll;
        readonly IShopBll _shopBll;

        public UserSubAccountMessageFilter(IUserSubAccountBll subAccountBll, IShopBll shopBll)
        {
            _subAccountBll = subAccountBll;
            _shopBll = shopBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.AddUserSubAccountRequest:
                        OnAddUserSubAccountRequest(msg, e);
                        break;
                    case MessageType.UpdateUserSubAccountRequest:
                        OnUpdateUserSubAccountRequest(msg, e);
                        break;
                    case MessageType.DeleteUserSubAccountRequest:
                        OnDeleteUserSubAccountRequest(msg, e);
                        break;
                    case MessageType.GetUserSubAccountListRequest:
                        OnGetUserSubAccountListRequest(msg, e);
                        break;
                    case MessageType.GetSubAccountPageListRequest:
                        OnGetSubAccountPageListRequest(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnAddUserSubAccountRequest(IMessage msg, SessionEventArgs e)
        {
            var subAccount = msg.Obj as UserSubAccount;
            var state = UserSubAccountOptState.Failed;

            if (e.Session.SessionId == null)
            {
                state = UserSubAccountOptState.InvalidOpt;
            }
            else
            {
                if (subAccount != null)
                {
                    try
                    {
                        subAccount.UserId = (e.Session.SessionId as UserSessionIdMetaData).Id;
                        state = _subAccountBll.Add(subAccount);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(state, MessageType.AddUserSubAccountResponse);
        }

        void OnUpdateUserSubAccountRequest(IMessage msg, SessionEventArgs e)
        {
            var subAccount = msg.Obj as UserSubAccount;
            var state = UserSubAccountOptState.Failed;

            if (e.Session.SessionId == null)
            {
                state = UserSubAccountOptState.InvalidOpt;
            }
            else
            {
                if (subAccount != null)
                {
                    try
                    {
                        state = _subAccountBll.Update(subAccount);
                        if(state == UserSubAccountOptState.Successed)
                        {
                            var userId = (e.Session.SessionId as UserSessionIdMetaData).Id;
                            _shopBll.AuditShop(userId, false);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(state, MessageType.UpdateUserSubAccountResponse);
        }

        void OnDeleteUserSubAccountRequest(IMessage msg, SessionEventArgs e)
        {
            var subAccount = msg.Obj as UserSubAccount;
            var state = UserSubAccountOptState.Failed;

            if (e.Session.SessionId == null)
            {
                state = UserSubAccountOptState.InvalidOpt;
            }
            else
            {
                if (subAccount != null)
                {
                    try
                    {
                        state = _subAccountBll.Delete(subAccount);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(state, MessageType.DeleteUserSubAccountResponse);
        }

        void OnGetUserSubAccountListRequest(IMessage msg, SessionEventArgs e)
        {
            var state = UserSubAccountOptState.Failed;
            IList<UserSubAccount> subAccountList = null;
            if (e.Session.SessionId != null)
            {
                try
                {
                    subAccountList = _subAccountBll.GetList((e.Session.SessionId as UserSessionIdMetaData).Id);
                    state = UserSubAccountOptState.Successed;
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = UserSubAccountOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<UserSubAccountOptState, IList<UserSubAccount>>
            {
                State = state,
                Data = subAccountList
            }, MessageType.GetUserSubAccountListResponse);
        }

        void OnGetSubAccountPageListRequest(IMessage msg, SessionEventArgs e)
        {
            var pageListInfo = msg.Obj as PageListQueryInfo<UserSubAccountPageListQuery>;
            var state = UserSubAccountOptState.Failed;
            Page<UserSubAccountDetails> page = null;
            if (e.Session.SessionId == null)
            {
                state = UserSubAccountOptState.InvalidOpt;
            }
            else
            {
                if (pageListInfo != null)
                {
                    try
                    {
                        var userId = (e.Session.SessionId as UserSessionIdMetaData).Id;
                        page = _subAccountBll.GetPageList(userId, pageListInfo);
                        state = UserSubAccountOptState.Successed;
                    }
                    catch(Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }

            e.Session.Send(new DataResponse<UserSubAccountOptState, Page<UserSubAccountDetails>>
            {
                State = state,
                Data = page
            }, MessageType.GetSubAccountPageListResponse);
        }
    }
}