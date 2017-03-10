using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using log4net.Config;
using Starts2000.Net.Session.Future;
using Starts2000.TaoBao.Core.Bll;
using Starts2000.TaoBao.Core.Dal;
using Starts2000.TaoBao.Core.MessageFilters;
using Starts2000.TaoBao.Core.Resource;
using Starts2000.TaoBao.Views;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core
{
    internal static class Global
    {
        static readonly Communication _tcpClient;
        static readonly ApplicationData _applicationData = new ApplicationData();

        static Global()
        {
            var serverInfo = Resources.Server;
            if(string.IsNullOrEmpty(serverInfo))
            {
                throw new ApplicationException("程序配置信息错误！");
            }

            var arr = serverInfo.Split('|');
            if(arr.Length != 2)
            {
                throw new ApplicationException("程序配置信息错误！");
            }

            int port;
            if(!int.TryParse(arr[1], out port))
            {
                throw new ApplicationException("程序配置信息错误！");
            }

            _tcpClient = new Communication(arr[0], port);
        }

        internal static ApplicationData ApplicationData
        {
            get { return _applicationData; }
        }

        internal static void Init()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo("Configs/Log4Net.xml"));
            InitNinject();
            InitMessageFilters();
        }

        internal static void Uinit()
        {
            try
            {
                _applicationData.UserExit = true;
                Resolve<IOfflineCheckManager>().Stop();
                _tcpClient.Close();
                NinjectCommon.Stop();
                if (_applicationData.IsClient)
                {
                    AnyDesk.CloseServer();
                }
                else
                {
                    AnyDesk.CloseClient();
                }

                AnyDesk.Stop();
            }
            catch(Exception)
            {
                
            }
        }

        internal static T Resolve<T>()
        {
            return NinjectCommon.Resolve<T>();
        }

        internal static T Resolve<T>(string name)
        {
            return NinjectCommon.Resolve<T>(name);
        }

        internal static IFuture SendToServer(object data, MessageType type, 
            ushort subType = 0, bool zip = false, bool encrypted = false)
        {
            return _tcpClient.Send(data, (ushort)type, subType, zip, encrypted);
        }

        static void InitNinject()
        {
            NinjectCommon.Start(bindingRoot =>
            {
                bindingRoot.Bind<IDbFactory>().ToConstant<DbFactory>(DbFactory.Instance);

                bindingRoot.Bind<ILoginCfgDal>().To<LoginCfgDal>();
                bindingRoot.Bind<ILoginCfgBll>().To<LoginCfgBll>();

                bindingRoot.Bind<IAreaDal>().To<AreaDal>();
                bindingRoot.Bind<IAreaBll>().To<AreaBll>();

                bindingRoot.Bind<IUpdateInfoDal>().To<UpdateInfoDal>();
                bindingRoot.Bind<IUpdateInfoBll>().To<UpdateInfoBll>();

                bindingRoot.Bind<IOrderStateDal>().To<OrderStateDal>();
                bindingRoot.Bind<IOrderStateBll>().To<OrderStateBll>();

                bindingRoot.Bind<IUserBll>().To<UserBll>().InSingletonScope();
                bindingRoot.Bind<IShopBll>().To<ShopBll>().InSingletonScope();
                bindingRoot.Bind<IOnlineCheckBll>().To<OnlineCheckBll>().InSingletonScope();

                bindingRoot.Bind<IUserSubAccountBll>().To<UserSubAccountBll>().InSingletonScope();

                bindingRoot.Bind<IRemoteOperationBll>().To<RemoteOperationBll>().InSingletonScope();

                bindingRoot.Bind<IOrderTypeBll>().To<OrderTypeBll>().InSingletonScope();
                bindingRoot.Bind<IOrderRecordBll>().To<OrderRecordBll>().InSingletonScope();

                bindingRoot.Bind<UserMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<ShopMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<UserSubAccountMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<RemoteOperrationMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<OrderTypeMessageFilter>().ToSelf().InSingletonScope();
                bindingRoot.Bind<OrderRecordMessageFilter>().ToSelf().InSingletonScope();

                bindingRoot.Bind<IGlobalApplicationData>().To<GlobalApplicationData>();
                bindingRoot.Bind<IOfflineCheckManager>().To <OfflineCheckManager>().InSingletonScope();

                //Views Binding
                bindingRoot.Bind<INotifyIconMagager>().To<NotifyIconManager>().InSingletonScope();
                //bindingRoot.Bind<ViewLogin>().ToSelf();
                //bindingRoot.Bind<ViewRegister>().ToSelf();
                //bindingRoot.Bind<ViewOptMain>().ToSelf();
                bindingRoot.Bind<IViewFactory>().ToConstant<ViewFactory>(ViewFactory.Instance);
                bindingRoot.Bind<ApplicationContext>().To<OperationMainContext>().Named("Operation");
                bindingRoot.Bind<ApplicationContext>().To<ClientMainContext>().Named("Client");
            });
        }

        static void InitMessageFilters()
        {
            AddMessageFilter<RegisterState, UserMessageFilter>(MessageType.RegisterResponse);
            AddMessageFilter<LoginState, UserMessageFilter>(MessageType.LoginResponse);
            AddMessageFilter<LoginState, UserMessageFilter>(MessageType.ClientLoginReponse);
            AddMessageFilter<LoginState, UserMessageFilter>(MessageType.ReLoginResponse);
            AddMessageFilter<LoginState, UserMessageFilter>(MessageType.ClientReLoginReponse);
            AddMessageFilter<OnlineCheckState, UserMessageFilter>(MessageType.CheckOnlineResponse);
            AddMessageFilter<DataResponse<UserOptState, User>,
                UserMessageFilter>(MessageType.GetUserInfoResponse);
            AddMessageFilter<ChangePasswordState, UserMessageFilter>(MessageType.ChangePasswordResponse);

            AddMessageFilter<ShopOptState, ShopMessageFilter>(MessageType.AddShopResponse);
            AddMessageFilter<ShopOptState, ShopMessageFilter>(MessageType.DeleteShopResponse);
            AddMessageFilter<DataResponse<ShopOptState, IList<Shop>>,
                ShopMessageFilter>(MessageType.GetShopListResponse);

            AddMessageFilter<UserSubAccountOptState,
                UserSubAccountMessageFilter>(MessageType.AddUserSubAccountResponse);
            AddMessageFilter<UserSubAccountOptState, 
                UserSubAccountMessageFilter>(MessageType.DeleteUserSubAccountResponse);
            AddMessageFilter<UserSubAccountOptState,
                UserSubAccountMessageFilter>(MessageType.UpdateUserSubAccountResponse);
            AddMessageFilter<DataResponse<UserSubAccountOptState, IList<UserSubAccount>>,
                UserSubAccountMessageFilter>(MessageType.GetUserSubAccountListResponse);
            AddMessageFilter<DataResponse<UserSubAccountOptState, Page<UserSubAccountDetails>>,
                UserSubAccountMessageFilter>(MessageType.GetSubAccountPageListResponse);

            AddMessageFilter<RemoteInfoQuery,
                RemoteOperrationMessageFilter>(MessageType.RemoteOperationRequest);
            AddMessageFilter<DataResponse<RemoteOperationState, RemoteClientInfo>,
                RemoteOperrationMessageFilter>(MessageType.RemoteOperationResponse);

            AddMessageFilter<DataResponse<OrderTypeOptState, IList<OrderType>>,
                OrderTypeMessageFilter>(MessageType.GetOrderTypeListResponse);

            AddMessageFilter<DataResponse<OrderRecordOptState, OrderRecord>,
                OrderRecordMessageFilter>(MessageType.GetOrderRecordResponse);
            AddMessageFilter<OrderRecordOptState,
                OrderRecordMessageFilter>(MessageType.AddOrderRecordResponse);
            AddMessageFilter<OrderRecordOptState,
                OrderRecordMessageFilter>(MessageType.UpdateOrderRecordResponse);
            AddMessageFilter<DataResponse<OrderRecordOptState, Page<OrderRecordDetails>>,
                OrderRecordMessageFilter>(MessageType.GetOrderRecordListResponse);
            AddMessageFilter<DataResponse<OrderRecordOptState, OrderRecordConfirmReceiptInfo>,
                OrderRecordMessageFilter>(MessageType.GetGetConfirmReceiptInfoResponse);
        }

        static void AddMessageFilter<TModel, TFilter>(MessageType msgType)
            where TFilter : IMessageFilter
        {
            _tcpClient.AddFilter((ushort)msgType, new MessageFilterInfo
            {
                Type = typeof(TModel),
                Filter = Resolve<TFilter>()
            });
        }
    }
}