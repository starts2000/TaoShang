namespace Starts2000.TaobaoPlatform.Manager.Utils
{
    public static class PasswordEncrypt
    {
        static readonly string Key1;
        static readonly string Key2;

        static PasswordEncrypt()
        {
            string key = MD5Encrypt.GetMD5("SAD~FIU_23$5987.sd^f|45qQE");
            Key1 = key.Substring(22, 10);
            Key2 = key.Substring(0, 22);
        }

        /// <summary>
        /// 获取最终加密后的密码密文。
        /// </summary>
        /// <param name="passwordMd5">明文密码MD5后的密文密码。</param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static string EncryptPassword(string passwordMd5, out string seed)
        {
            seed = MD5Encrypt.GetSeed(8);
            string str = string.Format("{0}{1}{2}{3}",
                Key1, passwordMd5.Substring(0, 22), Key2, passwordMd5.Substring(22, 10));
            return MD5Encrypt.GetMD5(MD5Encrypt.GetMD5(str) + seed);
        }

        /// <summary>
        /// 获取最终加密后的密码密文。
        /// </summary>
        /// <param name="passwordMd5">明文密码MD5后的密文密码。</param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static string EncryptPassword(string passwordMd5, string seed)
        {
            string str = string.Format("{0}{1}{2}{3}",
                Key1, passwordMd5.Substring(0, 22), Key2, passwordMd5.Substring(22, 10));
            return MD5Encrypt.GetMD5(MD5Encrypt.GetMD5(str) + seed);
        }

        /// <summary>
        /// 获取最终加密后的密码密文。
        /// </summary>
        /// <param name="password">明文密码。</param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static string GetEncryptPassword(string password, out string seed)
        {
            return EncryptPassword(MD5Encrypt.GetMD5(password), out seed);
        }

        /// <summary>
        /// 获取最终加密后的密码密文。
        /// </summary>
        /// <param name="password">明文密码。</param>
        /// <param name="seed">密码加密随机字符串。</param>
        /// <returns></returns>
        public static string GetEncryptPassword(string password, string seed)
        {
            return EncryptPassword(MD5Encrypt.GetMD5(password), seed);
        }

        /// <summary>
        /// 密码校验。
        /// </summary>
        /// <param name="passwordMd5">MD5加密后的密码字符串。</param>
        /// <param name="seed">密码加密随机字符串。</param>
        /// <param name="encPassword">最终加密后的密码字符串。</param>
        /// <returns></returns>
        public static bool CheckPassword(string passwordMd5, string seed, string encPassword)
        {
            return EncryptPassword(passwordMd5, seed).Equals(encPassword);
        }
    }
}
