using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IUserDal
    {
        bool Exists(string account);

        bool Add(User user);

        User Get(string account);

        User Get(int id);

        User GetInfo(int id);

        int GetGold(int id);

        bool UpdateGold(int userId, int gold);

        bool UpdateClientLogin(UserLoginState state);

        bool UpdateClientLogout(int userId);

        bool DeductionGold(int id, int gold);

        bool UpdatePassword(int id, string password);
    }
}
