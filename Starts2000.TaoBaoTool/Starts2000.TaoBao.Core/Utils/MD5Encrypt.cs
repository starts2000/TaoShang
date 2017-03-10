using System;
using System.Security.Cryptography;
using System.Text;

namespace Starts2000.TaoBao.Core.Utils
{
    internal static class MD5Encrypt
    {
        #region Const Fields

        private const byte FOUR_BITS = 4;
        private const byte HIGH_BITS_MASK = 240;
        private const byte LOW_BITS_MASK = 15;
        private const byte MD5_LENGTH = 0x20;

        #endregion

        static MD5Encrypt()
        {
        }

        public static string ByteArrayToHexadecimalString(byte[] array)
        {
            StringBuilder builder = new StringBuilder(MD5_LENGTH);
            for (int i = 0; i < array.Length; i++)
            {
                builder.Append(NibbleToHex((array[i] & HIGH_BITS_MASK) >> FOUR_BITS));
                builder.Append(NibbleToHex(array[i] & LOW_BITS_MASK));
            }
            return builder.ToString();
        }

        public static string GetMD5(string str)
        {
            return GetMD5(Encoding.UTF8.GetBytes(str));
        }

        public static string GetMD5(byte[] array)
        {
            if (array.Length < 1)
            {
                throw new ArgumentException("array should not be empty.");
            }
            return GetMD5(array, 0, array.Length);
        }

        public static string GetMD5(byte[] array, int offset, int count)
        {
            string str;
            MD5 md = null;
            try
            {
                md = new MD5CryptoServiceProvider();
                md.Initialize();
                str = ByteArrayToHexadecimalString(md.ComputeHash(array, offset, count));
            }
            finally
            {
                if (md != null)
                {
                    md.Clear();
                }
            }
            return str;
        }

        #region Helper Methods

        private static char NibbleToHex(int n)
        {
            if (n < 10)
            {
                return (char)(0x30 + n);
            }
            return (char)(0x61 + (n - 10));
        }

        #endregion
    }
}