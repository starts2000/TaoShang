using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Starts2000.TaobaoPlatform.Utils.Security;
using Xunit;

namespace Starts2000.TaobaoPlatform.Server.Tests
{
    public class MD5EncryptTest
    {
        [Fact]
        public void SeedTest()
        {
            HashSet<string> set = new HashSet<string>();
            int i = 0;
            while (i < 100)
            {
                set.Add(MD5Encrypt.GetSeed(8));
                Thread.Sleep(1);
                i++;
            }
        }

        [Fact]
        public void Password()
        {
            var pwd = PasswordEncrypt.GetEncryptPassword("888888", "6223171d");
            var ss = pwd;
        }
    }
}
