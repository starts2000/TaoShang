using System;
using System.Security.Cryptography;
using System.Text;

namespace Starts2000.TaoBao.Views.Utils
{
    internal static class TripleDES
    {
        readonly static TripleDESCryptoServiceProvider
            _tripleDESProvider = new TripleDESCryptoServiceProvider();

        static TripleDES()
        {
            _tripleDESProvider.Key = Encoding.UTF8.GetBytes("$jI<%D$674K-@d4g8k9ca92]");
            _tripleDESProvider.IV = Encoding.UTF8.GetBytes("&sdgf0^2");
        }

        public static string Encrypt3DES(string content)
        {
            ICryptoTransform tansform = _tripleDESProvider.CreateEncryptor();
            byte[] inputBytes = Encoding.UTF8.GetBytes(content);
            byte[] outBytes = tansform.TransformFinalBlock(
                inputBytes, 0, inputBytes.Length);
            return Convert.ToBase64String(outBytes);
        }

        public static string Decrypt3DES(string content)
        {
            ICryptoTransform tansform = _tripleDESProvider.CreateDecryptor();
            byte[] inputBytes = Convert.FromBase64String(content);
            byte[] outBytes = tansform.TransformFinalBlock(
                inputBytes, 0, inputBytes.Length);
            return Encoding.UTF8.GetString(outBytes);
        }
    }
}