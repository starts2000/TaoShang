using System;
using System.Threading;
using Ninject.Extensions.Logging;
using Starts2000.TaoBao.Views;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Core
{
    class OfflineCheckManager : IOfflineCheckManager
    {
        readonly Timer _timer;
        readonly IOnlineCheckBll _onlineCheckBll;
        readonly IUserBll _userBll;
        int _isTimmerCallbacking;

        public OfflineCheckManager(IUserBll userBll, IOnlineCheckBll onlineCheckBll)
        {
            _onlineCheckBll = onlineCheckBll;
            _userBll = userBll;
            _timer = new Timer(TimerCallback, null, Timeout.Infinite, 15 * 1000);
        }

        public void Start()
        {
            _timer.Change(1000, 15000);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, 0);
            _timer.Dispose();
        }

        void TimerCallback(object state)
        {
            if (Interlocked.CompareExchange(ref _isTimmerCallbacking, 1, 1) == 1)
            {
                return;
            }

            try
            {
                LogInfo("begin check online state.");
                _onlineCheckBll.Check(checksSate =>
                {
                    LogInfo("check online state, OnlineState:{0}.", checksSate);

                    switch (checksSate)
                    {
                        case OnlineCheckState.CannotConnectServer:
                            LogInfo("Cannot Connect Server!");
                            break;
                        case OnlineCheckState.InvalidOpt:
                            if (Global.ApplicationData.User != null)
                            {
                                _userBll.ReLogin(new LoginInfo
                                {
                                    User = Global.ApplicationData.User,
                                    UpdateInfo = Global.ApplicationData.UpdateInfo
                                }, loginState =>
                                {
                                    LogInfo("ReLogin to server, LoginState:{0}.", loginState);
                                });
                            }
                            break;
                        case OnlineCheckState.Successed:
                        case OnlineCheckState.Failed:
                            break;
                    }
                });
            }
            catch (Exception ex)
            {
                LogError("Check online state Error.", ex);
            }
            finally
            {
                LogInfo("end check online state.");
                Interlocked.Exchange(ref _isTimmerCallbacking, 0);
            }
        }

        void LogError(string message, Exception ex)
        {
            try
            {
                var logger = Global.Resolve<ILoggerFactory>().GetCurrentClassLogger();
                logger.ErrorException(message, ex);
            }
            catch
            {

            }
        }

        void LogInfo(string format, params object[] args)
        {
            try
            {
                var logger = Global.Resolve<ILoggerFactory>().GetCurrentClassLogger();
                logger.Info(format, args);
            }
            catch
            {

            }
        }

        void LogInfo(string message)
        {
            try
            {
                var logger = Global.Resolve<ILoggerFactory>().GetCurrentClassLogger();
                logger.Info(message);
            }
            catch
            {

            }
        }
    }
}
