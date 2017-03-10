using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IHangUpTimeBll
    {
        bool Add(HangUpTime hangUpTime);

        int TotalMinutes(int userId);
    }
}
