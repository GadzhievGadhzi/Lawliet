﻿using Lawliet.Data;
using Lawliet.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Lawliet.Services {
    public class CachingService {
        private UserDataContext context;
        public IMemoryCache cache;

        public CachingService(UserDataContext context, IMemoryCache cache) {
            this.context = context;
            this.cache = cache;
        }

        public async Task AddObjectFromCache<TEntity>(TEntity user, MemoryCacheEntryOptions? options = null) where TEntity : class, IDataModel {
            DataRepository<TEntity> repository = new DataRepository<TEntity>(context);
            var _user = repository.Get(search => search.Id == user.Id);
            if (_user.Count() > 0) {
                cache.Set(user.Id, _user.First(), options);
            } else {
                await repository.CreateAsync(user);
                cache.Set(user.Id, user, options);
            }
        }

        public async Task<TEntity> GetObjectFromCache<TEntity>(string id, MemoryCacheEntryOptions? options = null) where TEntity : class, IDataModel {
            TEntity? user;
            if (!cache.TryGetValue(id, out user)) {
                DataRepository<TEntity> repository = new DataRepository<TEntity>(context);
                user = await repository.FindById(id);
                if (user != null) {
                    cache.Set(user.Id, user, options);
                }
            }
            return user!;
        }
    }
}