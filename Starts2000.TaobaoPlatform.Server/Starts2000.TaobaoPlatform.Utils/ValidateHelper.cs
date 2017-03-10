using System.Text.RegularExpressions;

namespace Starts2000.TaobaoPlatform.Utils
{
    /// <summary>
    /// 验证辅助类。
    /// </summary>
    public static class ValidateHelper
    {
        static readonly Regex UserNameReg = new Regex("^[a-z][a-z0-9_]{4,19}$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static readonly Regex EmaiReg = new Regex(
            @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static readonly Regex MobileReg = new Regex(@"^1\d{10}$", RegexOptions.Compiled);
        static readonly Regex QQReg = new Regex(@"^[1-9]\d{3,}$", RegexOptions.Compiled);

        /// <summary>
        /// 用户名验证。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns></returns>
        public static bool CheckUserName(string userName)
        {
            if (userName.Length < 5 || userName.Length > 20)
            {
                return false;
            }

            return UserNameReg.IsMatch(userName);
        }

        /// <summary>
        /// 邮箱地址验证。
        /// </summary>
        /// <param name="email">邮箱地址。</param>
        /// <returns></returns>
        public static bool CheckEmail(string email)
        {
            return email.Length <= 64 && EmaiReg.IsMatch(email);
        }

        /// <summary>
        /// 用户密码验证。
        /// </summary>
        /// <param name="password">用户密码。</param>
        /// <returns></returns>
        public static bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                return false;
            }

            return true;
        }

        public static bool CheckMobile(string mobile)
        {
            return MobileReg.IsMatch(mobile);
        }

        public static bool CheckQQ(string qq)
        {
            return QQReg.IsMatch(qq);
        }
    }
}
