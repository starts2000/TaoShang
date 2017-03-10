using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starts2000.TaoBao.Core.Utils;
using Starts2000.TaobaoPlatform.Models;
using Xunit;

namespace Starts2000.TaoBao.Core.Tests
{
    public class SerializeHelperTest
    {
        [Fact]
        public void ProtoBufferTest()
        {
            var user = new User()
            {
                Account = "Starts2000",
                Password = "123456",
                Name = "梁香元",
                QQ = "13929619",
                Email = "Starts2000@qq.com",
                Mobile = "13768235640",
                Salt = "12345",
                ReferrerAccount = "Test"
            };

            byte[] data = SerializeHelper.Serialize(user);
            var user1 = SerializeHelper.Deserialize(data, 0, data.Length, typeof(User)) as User;
            //var user1 = obj as User;

            Assert.Equal(user.Account, user1.Account);
        }
    }
}
