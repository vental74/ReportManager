using ReportManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.Cache
{
    public class FirstMeroryCache<T> : ICache<T>
    {
        private Dictionary<int, T> _cache;
        public FirstMeroryCache()
        {
            CreateNewDict();
        }

        public Task<T> Get(int id)
        {
            if (_cache.TryGetValue(id, out var item))
            {
                return Task.FromResult(item);
            }
            else 
            {
                throw new ArgumentException($"item with this id not found, type({nameof(T)})");
            }
        }
        public Task Add(int id, T item)
        {
            _cache.Add(id, item);//try add 
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
