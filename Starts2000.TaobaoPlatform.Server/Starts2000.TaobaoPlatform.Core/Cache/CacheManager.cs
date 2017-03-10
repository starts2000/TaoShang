using System;
using System.Runtime.Caching;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaobaoPlatform.Core.Cache
{
    static class CacheManager
    {
        public static int GetSubAccountCount(int userId, Func<int, int> creator)
        {
            string key = string.Concat("SubAccountCount_", userId.ToString());
            var value = MemoryCache.Default.Get(key);
            if (value != null)
            {
                return (int)value;
            }

            var count = creator(userId);
            MemoryCache.Default.Add(new CacheItem(key, count), new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30)
            });

            return count;
        }

        public static UpdateInfo GetUpdateInfo(int clientType, Func<int, UpdateInfo> creator)
        {
            string key = string.Concat("UpdateInfo_", clientType.ToString());
            var value = MemoryCache.Default.Get(key);
            if (value != null)
            {
                return (UpdateInfo)value;
            }

            var updateInfo = creator(clientType);
            MemoryCache.Default.Add(new CacheItem(key, updateInfo), new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
            });

            return updateInfo;
        }
    }
}