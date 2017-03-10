using System;
using System.Collections.Generic;
using Ninject;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core.MessageFilters
{
    class ShopMessageFilter : MessageFilterBase
    {
        readonly IShopBll _shopBll;

        [Inject]
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
                    case MessageType.AddShopResponse:
                        _shopBll.AddResponse((ShopOptState)msg.Obj);
                        break;
                    case MessageType.DeleteShopResponse:
                        _shopBll.DeleteResponse((ShopOptState)msg.Obj);
                        break;
                    case MessageType.GetShopListResponse:
                        _shopBll.GetListResponse(msg.Obj as DataResponse<ShopOptState, IList<Shop>>);
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