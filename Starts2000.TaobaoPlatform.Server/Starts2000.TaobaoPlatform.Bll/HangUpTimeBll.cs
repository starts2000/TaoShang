using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class HangUpTimeBll : IHangUpTimeBll
    {
        readonly IHangUpTimeDal _hangupDal;

        public HangUpTimeBll(IHangUpTimeDal hangupDal)
        {
            _hangupDal = hangupDal;
        }

        public bool Add(HangUpTime hangUpTime)
        {
            return _hangupDal.Add(hangUpTime);
        }

        public int TotalMinutes(int userId)
        {
            return _hangupDal.TotalMinutes(userId);
        }
    }
}
