using System;
using System.Collections.Generic;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.MessageFilters
{
    internal class ShopMessageFilter : MessageFilterBase
    {
        readonly IShopBll _shopBll;

        public ShopMessageFilter(IShopBll shopBll)
        {
            _shopBll = shopBll;
        }

        public override void MessageHandler(IMessage msg, SessionEventArgs e)
        {
            try
            {
                switch ((MessageType)msg.Header.Type)
                {
                    case MessageType.AddShopRequest:
                        OnAddShopRequest(msg, e);
                        break;
                    case MessageType.DeleteShopRequest:
                        OnDeleteShopRequest(msg, e);
                        break;
                    case MessageType.GetShopListRequest:
                        OnGetShopListRequest(msg, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(msg.Header.Type, ex);
            }

            base.MessageHandler(msg, e);
        }

        void OnAddShopRequest(IMessage msg, SessionEventArgs e)
        {
            var shop = msg.Obj as Shop;
            var state = ShopOptState.Failed;

            if (e.Session.SessionId == null)
            {
                state = ShopOptState.InvalidOpt;
            }
            else
            {
                if (shop != null)
                {
                    try
                    {
                        shop.UserId = (e.Session.SessionId as UserSessionIdMetaData).Id;
                        state = _shopBll.Add(shop);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(state, MessageType.AddShopResponse);
        }

        void OnDeleteShopRequest(IMessage msg, SessionEventArgs e)
        {
            var shop = msg.Obj as Shop;
            ShopOptState state = ShopOptState.Failed;

            if (e.Session.SessionId == null)
            {
                state = ShopOptState.InvalidOpt;
            }
            else
            {
                if (shop != null)
                {
                    try
                    {
                        state = _shopBll.Delete(shop);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog(msg.Header.Type, ex);
                    }
                }
            }
            e.Session.Send(state, MessageType.DeleteShopResponse);
        }

        void OnGetShopListRequest(IMessage msg, SessionEventArgs e)
        {
            bool isAudit = (bool)msg.Obj;
            var state = ShopOptState.Failed;
            IList<Shop> shopList = null;
            if (e.Session.SessionId != null)
            {
                try
                {
                    shopList = _shopBll.GetList(
                        (e.Session.SessionId as UserSessionIdMetaData).Id, isAudit);
                    state = ShopOptState.Successed;
                }
                catch (Exception ex)
                {
                    ErrorLog(msg.Header.Type, ex);
                }
            }
            else
            {
                state = ShopOptState.InvalidOpt;
            }

            e.Session.Send(new DataResponse<ShopOptState, IList<Shop>>
            {
                State = state,
                Data = shopList
            }, MessageType.GetShopListResponse);
        }
    }
}