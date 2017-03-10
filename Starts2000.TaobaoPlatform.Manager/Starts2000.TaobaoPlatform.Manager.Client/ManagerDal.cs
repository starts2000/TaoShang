using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Starts2000.TaobaoPlatform.Manager.Client.Properties;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public class ManagerDal
    {
        readonly Uri _baseAddress = new Uri(Settings.Default.ServerUrl);

        public Task<Tuple<int, IList<User>>> GetUsers(string account, int pageIndex, int pageSize)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(string.Format("user/list/{0}/{1}/{2}", pageIndex, pageSize, account)).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<Tuple<int, IList<User>>>();
        }

        public Task<IList<Shop>> GetShops(int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.GetAsync(string.Format("shop/list/{0}", userId)).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<IList<Shop>>();
        }

        public Task<IList<UserSubAccount>> GetSubAccounts(int userId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.GetAsync(string.Format("subaccount/list/{0}", userId)).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<IList<UserSubAccount>>();
        }

        public Task<bool> UserAudit(User user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("user/audit", user).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> AddHangupTime(int userId, int minutes)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("hangupTime/add", new
            {
                UserId = userId,
                Minutes = minutes
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> AddGold(int userId, int gold)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("user/addgold", new
            {
                UserId = userId,
                Gold = gold
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> ResetPassword(int userId, string password, string salt)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("user/resetpwd", new
            {
                UserId = userId,
                Password = password,
                Salt = salt
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> ShopAudit(int id, bool audit)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("shop/audit", new Shop
            {
                Id = id,
                Audit = audit,
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> UpdateShop(Shop shop)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("shop/update", shop).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> DeleteShop(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("shop/delete", new
            {
                ShopId = id
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> SubAccountAudit(int id, bool audit)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("subaccount/audit", new UserSubAccount
            {
                Id = id,
                IsAudit = audit,
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }

        public Task<bool> DeleteSubAccount(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = _baseAddress;

            var response = client.PostAsJsonAsync("subaccount/delete", new
            {
                SubAccountId = id
            }).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<bool>();
        }
    } 
}
