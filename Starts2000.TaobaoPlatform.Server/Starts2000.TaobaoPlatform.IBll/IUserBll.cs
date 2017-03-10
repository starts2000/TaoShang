using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IBll
{
    public interface IUserBll
    {
        RegisterState Register(User user);

        LoginState Login(User user);

        User GetInfo(int id);

        int GetGold(int id);

        bool UpdateGold(int userId, int gold);

        bool UpdateClientLogin(UserLoginState state);

        bool UpdateClientLogout(int userId);

        bool DeductionGold(int id, int gold);

        ChangePasswordState ChangePassword(ChangePassword password);
    }
}
