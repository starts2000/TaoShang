using System;
using Ninject;
using Starts2000.TaobaoPlatform.IBll;
using Starts2000.TaobaoPlatform.IDal;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaobaoPlatform.Utils;
using Starts2000.TaobaoPlatform.Utils.Security;

namespace Starts2000.TaobaoPlatform.Bll
{
    public class UserBll : IUserBll
    {
        readonly IUserDal _userDal;

        [Inject]
        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public RegisterState Register(User user)
        {
            if(!ValidateHelper.CheckUserName(user.Account))
            {
                return RegisterState.InvalidAccount;
            }

            if (!ValidateHelper.CheckPassword(user.Password))
            {
                return RegisterState.InvalidPassword;
            }

            if (!ValidateHelper.CheckEmail(user.Email))
            {
                return RegisterState.InvalidEmail;
            }

            if (!ValidateHelper.CheckQQ(user.QQ))
            {
                return RegisterState.InvalidQQ;
            }

            if (!ValidateHelper.CheckMobile(user.Mobile))
            {
                return RegisterState.InvalidMobile;
            }

            string salt;
            user.Password = PasswordEncrypt.GetEncryptPassword(user.Password, out salt);
            user.Salt = salt;
            user.Account = user.Account.ToLower();

            if(_userDal.Exists(user.Account))
            {
                return RegisterState.AccountExists;
            }

            if(!_userDal.Add(user))
            {
                return RegisterState.Failed;
            }

            return RegisterState.Successed;
        }

        public LoginState Login(User user)
        {
            if(!string.IsNullOrEmpty(user.Account))
            {
                user.Account = user.Account.ToLower();
            }

            var userInfo = _userDal.Get(user.Account);
            if (userInfo == null)
            {
                return LoginState.InvalidAccountOrPassword;
            }

            if(user.Id == int.MinValue)
            {
                if(!user.Password.Equals(userInfo.Password))
                {
                    return LoginState.InvalidAccountOrPassword;
                }
            }
            else
            {
                if(!PasswordEncrypt.CheckPassword(user.Password, userInfo.Salt, userInfo.Password))
                {
                    return LoginState.InvalidAccountOrPassword;
                }
            }

            if (!userInfo.IsAudit || userInfo.ExpireDate == null)
            {
                user.Id = userInfo.Id;
                return LoginState.NotAudit;
            }

            if (DateTime.UtcNow > userInfo.ExpireDate.Value)
            {
                return LoginState.Expired;
            }

            if (userInfo.Lock)
            {
                return LoginState.Locked;
            }

            user.Id = userInfo.Id;
            return LoginState.Successed;
        }

        public User GetInfo(int id)
        {
            return _userDal.GetInfo(id);
        }

        public int GetGold(int id)
        {
            return _userDal.GetGold(id);
        }

        public bool UpdateGold(int userId, int gold)
        {
            return _userDal.UpdateGold(userId, gold);
        }

        public bool UpdateClientLogin(UserLoginState state)
        {
            return _userDal.UpdateClientLogin(state);
        }

        public bool UpdateClientLogout(int userId)
        {
            return _userDal.UpdateClientLogout(userId);
        }

        public bool DeductionGold(int id, int gold)
        {
            return _userDal.DeductionGold(id, gold);
        }

        public ChangePasswordState ChangePassword(ChangePassword password)
        {
            if (!ValidateHelper.CheckPassword(password.NewPassword))
            {
                return ChangePasswordState.InvalidNewPassword;
            }

            var user = _userDal.Get(password.Id);
            if(user == null)
            {
                return ChangePasswordState.InvalidOpt;
            }

            if (!PasswordEncrypt.CheckPassword(password.OldPassword, user.Salt, user.Password))
            {
                return ChangePasswordState.InvalidOldPassword;
            }

            if(!_userDal.UpdatePassword(password.Id,
                PasswordEncrypt.GetEncryptPassword(password.NewPassword, user.Salt)))
            {
                return ChangePasswordState.Failed;
            }

            return ChangePasswordState.Successed;
        }
    }
}