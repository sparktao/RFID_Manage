using Microsoft.Extensions.Caching.Memory;
using System;

namespace Org.Tao.FW.Application.Utils
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c) 2018-2021
    /// 创建人：Tao
    /// 日 期：2018.06.15 10:45
    /// 描 述：缓存操作
    /// </summary>
    public class Cache : ICache
    {
        private static MemoryCache _cache = null;

        protected static MemoryCache cache
        {
            get
            {
                if (_cache == null)
                {
                    _cache = new MemoryCache(new MemoryCacheOptions() { });
                }
                return _cache;
            }
            private set
            {
                _cache = value;
            }
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T GetCache<T>(string cacheKey) where T : class
        {
            if (cache.Get(cacheKey) != null)
            {
                return (T)cache.Get(cacheKey);
            }
            return default(T);
        }
        /// <summary>
        /// 写入缓存,永不过期
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            cache.Set(cacheKey, value, new MemoryCacheEntryOptions());
            //cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            cache.Set(cacheKey, value, new MemoryCacheEntryOptions { AbsoluteExpiration = expireTime });
            //cache.Insert(cacheKey, value, null, expireTime, System.Web.Caching.Cache.NoSlidingExpiration);
        }
        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }
        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveCache()
        {
            //You should not call dispose on the Default member of the MemoryCache if you want to be able to use it anymore:
            (cache as MemoryCache).Dispose();
            cache = null;
        }
    }
}
