using System;
using System.Threading;
using Ninject;
using Ninject.Extensions.Logging;
using Starts2000.TaobaoPlatform.Core.Cache;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.Threading;

namespace Starts2000.TaobaoPlatform.Core
{
    class GoldCalculator : IDisposable
    {
        const int CalculatePeriod = 1000 * 60 * 5;
        readonly Timer _timer;
        readonly Func<int, int> _creator;
        readonly IUserSubAccountBll _subAccountBll;
        readonly IUserBll _userBll;
        readonly IHangUpTimeBll _hangUpTimeBll;
        int _isExecuted;

        [Inject]
        public GoldCalculator(IUserSubAccountBll subAccountBll, 
            IUserBll userBll, IHangUpTimeBll hangUpTimeBll)
        {
            _subAccountBll = subAccountBll;
            _userBll = userBll;
            _hangUpTimeBll = hangUpTimeBll;
            _creator = userId =>
            {
                return _subAccountBll.Count(userId);
            };

            _timer = new Timer(obj =>
            {
                if (InterlockedEx.IfThen(ref _isExecuted, 1, 1))
                {
                    return;
                }

                Interlocked.Increment(ref _isExecuted);

                try
                {
                    foreach (var sessionId in Global.GetConnectedClientUserId())
                    {
                        if (sessionId.LastCalcTime.Value.AddMinutes(10) <= DateTime.Now)
                        {
                            _hangUpTimeBll.Add(new HangUpTime
                            {
                                UserId = sessionId.Id,
                                Minutes = 10
                            });

                            var count = CacheManager.GetSubAccountCount(sessionId.Id, _creator);
                            int gold = 0;
                            if (count == 1)
                            {
                                gold = 5;
                            }
                            else if (count == 2)
                            {
                                gold = 8;
                            }
                            else if(count >= 3)
                            {
                                gold = 13;
                            }

                            if (gold != 0)
                            {
                                _userBll.UpdateGold(sessionId.Id, gold);
                            }

                            sessionId.LastCalcTime = sessionId.LastCalcTime.Value.AddMinutes(10);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Global.Resolve<ILoggerFactory>()
                        .GetCurrentClassLogger()
                        .ErrorException("GoldCalculator Timer Callback.", ex);
                }
                finally
                {
                    Interlocked.Decrement(ref _isExecuted);
                }
            }, null, Timeout.Infinite, CalculatePeriod);
        }

        internal void Start()
        {
            _timer.Change(60 * 1000, CalculatePeriod);
        }

        #region IDisposable 成员

        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion
    }
}