using ReportManager.Domain.Entities;
using ReportManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.Cache
{
    public class FirstMemoryCache<T> : ICache<T> where T: BaseEntity
    {
        private volatile Dictionary<int, T> _cache;
        public FirstMemoryCache()
        {
            CreateNewDict();
        }

        public Task<bool> TryGet(int id, out T result)
        {
            return Task.FromResult(_cache.TryGetValue(id, out result));
            //if (_cache.TryGetValue(id, out var item))
            //{
            //    return Task.FromResult(item);
            //}
            //else 
            //{
            //    throw new ArgumentException($"item with this id not found, type({nameof(T)})");
            //}
        }
        public Task Add(T item)
        {
            _cache.TryAdd(item.Id, item);
            return Task.CompletedTask;
        }

        public Task ClearCache()
        {
            CreateNewDict();
            return Task.CompletedTask;
        }
        private void CreateNewDict() 
        {
            _cache = new Dictionary<int, T>();
        }
    }
}
