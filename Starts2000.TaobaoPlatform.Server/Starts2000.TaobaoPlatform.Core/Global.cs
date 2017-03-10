using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using log4net.Config;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Bll;
using Starts2000.TaobaoPlatform.Core.MessageFilters;
using Starts2000.TaobaoPlatform.Dal;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core
{
    internal static class Global
    {
        static readonly Communication _tcpServer;

        static Global()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);
            _tcpServer = new Communication(port);
        }

        internal static void Init()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo("Configs/Log4Net.xml"));
            InitNinject();
            InitMessageFilters();
            _tcpServer.Start();
            Resolve<GoldCalculator>().Start();
        }

        internal static void UnInit()
        {
            _tcpServer.Close();
            Resolve<GoldCalculator>().Dispose();
            NinjectCommon.Stop();
        }

        internal static ISession GetSession(ISessionIdMetaData sessionId)
        {
            if(_tcpServer == null || 
                _tcpServer.SessionAcceptor == null ||
                !_tcpServer.SessionAcceptor.Started)
            {
                return null;
            }

            return _tcpServer.SessionAcceptor.GetConnectedSession(sessionId);
        }

        internal static IEnumerable<UserSessionIdMetaData> GetConnectedClientUserId()
        {
            if (_tcpServer == null ||
                _tcpServer.SessionAcceptor == null ||
                !_tcpServer.SessionAcceptor.Started)
            {
                return null;
            }

            return _tcpServer.SessionAcceptor.GetConnectedSessionMetaData(session =>
            {
                if (session.IsOpened)
                {
                    var sessionId = session.SessionId as UserSessionIdMetaData;
                    if (sessionId != null && sessionId.IsClient)
                    {
                        return true;
                    }
                }

                return false;
            }).Select(session => {
                return session.SessionId as UserSessionIdMetaData;
            });
        }

        internal static T Resolve<T>()
        {
            return NinjectCommon.Resolve<T>();
        }

        internal static T Resolve<T>(string name)
        {
            return NinjectCommon.Resolve<T>(name);
        }

        static void InitNinject()
        {
            NinjectCommon.Start(bindingRoot =>
            {
                bindingRoot.Bind<IDbFactory>().ToConstant(DbFactory.Instance);

                bindingRoot.Bind<IUserDal>().To<UserDal>();
                bindingRoot.Bind<IUserBll>().To<UserBll>();

                bindingRoot.Bind<IShopDal>().To<ShopDal>();
                bindingRoot.Bind<IShopBll>().To<ShopBll>();

                bindingRoot.Bind<IUserSubAccountDal>().To<UserSubAccountDal>();
                bindingRoot.Bind<IUserSubAccountBll>().To<UserSubAccountBll>();

                bindingRoot.Bind<IOrderRecordDal>().To<OrderRecordDal>();
                bindingRoot.Bind<IOrderRecordBll>().To<OrderRecordBll>();

                bindingRoot.Bind<IOrderTypeDal>().To<OrderTypeDal>();
                bindingRoot.Bind<IOrderTypeBll>().To<OrderTypeBll>();

                bindingRoot.Bind<IHangUpTimeDal>().To<HangUpTimeDal>();
                bindingRoot.Bind<IHangUpTimeBll>().To<HangUpTimeBll>();

                bindingRoot.Bind<IUserSubAccountUsageInfoDal>().To<UserSubAccountUsageInfoDal>();
                bindingRoot.Bind<IUserSubAccountUsageInfoBll>().To<UserSubAccountUsageInfoBll>();

                bindingRoot.Bind<IUserSubAccountOrderTypeInfoDal>().To<UserSubAccountOrderTypeInfoDal>();
                bindingRoot.Bind<IUserSubAccountOrderTypeInfoBll>().To<UserSubAccountOrderTypeInfoBll>();

                bindingRoot.Bind<IUpdateInfoDal>().To<UpdateInfoDal>();
                bindingRoot.Bind<IUpdateInfoBll>().To<UpdateInfoBll>();

                bindingRoot.Bind<GoldCalculator>().ToSelf().InSingletonScope();

                bindingRoot.Bind<UserMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<ShopMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<UserSubAccountMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<RemoteOperationMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<OrderRecordMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<OrderTypeMessageFilter>().ToSelf().InSingletonScope();
            });
        }

        static void InitMessageFilters()
        {
            AddMessageFilter<User, UserMessageFilter>(MessageType.RegisterRequest);
            AddMessageFilter<LoginInfo, UserMessageFilter>(MessageType.LoginRequest);
            AddMessageFilter<LoginInfo, UserMessageFilter>(MessageType.ClientLoginRequest);
            AddMessageFilter<LoginInfo, UserMessageFilter>(MessageType.ReLoginRequest);
            AddMessageFilter<LoginInfo, UserMessageFilter>(MessageType.ClientReLoginRequest);
            AddMessageFilter<string, UserMessageFilter>(MessageType.CheckOnlineRequest);
            AddMessageFilter<int, UserMessageFilter>(MessageType.GetUserInfoRequest);
            AddMessageFilter<ChangePassword, UserMessageFilter>(MessageType.ChangePasswordRequest);

            AddMessageFilter<Shop, ShopMessageFilter>(MessageType.AddShopRequest);
            AddMessageFilter<Shop, ShopMessageFilter>(MessageType.DeleteShopRequest);
            AddMessageFilter<bool, ShopMessageFilter>(MessageType.GetShopListRequest);

            AddMessageFilter<UserSubAccount, UserSubAccountMessageFilter>(MessageType.AddUserSubAccountRequest);
            AddMessageFilter<UserSubAccount, UserSubAccountMessageFilter>(MessageType.UpdateUserSubAccountRequest);
            AddMessageFilter<UserSubAccount, UserSubAccountMessageFilter>(MessageType.DeleteUserSubAccountRequest);
            AddMessageFilter<int, UserSubAccountMessageFilter>(MessageType.GetUserSubAccountListRequest);
            AddMessageFilter<PageListQueryInfo<UserSubAccountPageListQuery>, 
                UserSubAccountMessageFilter>(MessageType.GetSubAccountPageListRequest);

            AddMessageFilter<TransmitData<RemoteInfoQuery>, 
                RemoteOperationMessageFilter>(MessageType.RemoteOperationRequest);
            AddMessageFilter<TransmitData<DataResponse<RemoteOperationState, RemoteClientInfo>>,
               RemoteOperationMessageFilter>(MessageType.RemoteOperationResponse);

            AddMessageFilter<OrderRecord, OrderRecordMessageFilter>(MessageType.GetOrderRecordRequest);
            AddMessageFilter<OrderRecord, OrderRecordMessageFilter>(MessageType.AddOrderRecordRequest);
            AddMessageFilter<OrderRecord, OrderRecordMessageFilter>(MessageType.UpdateOrderRecordRequest);
            AddMessageFilter<PageListQueryInfo<OrderRecordPageListQuery>,
                OrderRecordMessageFilter>(MessageType.GetOrderRecordListRequest);
            AddMessageFilter<OrderRecord,
                OrderRecordMessageFilter>(MessageType.GetGetConfirmReceiptInfoRequest);

            AddMessageFilter<int, OrderTypeMessageFilter>(MessageType.GetOrderTypeListRequest);
        }

        static void AddMessageFilter<TModel, TFilter>(MessageType msgType)
            where TFilter : IMessageFilter
        {
            _tcpServer.AddFilter((ushort)msgType, new MessageFilterInfo
            {
                Type = typeof(TModel),
                Filter = NinjectCommon.Resolve<TFilter>()
            });
        }
    }
}