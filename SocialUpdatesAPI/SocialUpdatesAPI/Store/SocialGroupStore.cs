﻿using SocialUpdatesAPI.Models;
using System.Collections.Generic;

namespace SocialUpdatesAPI.Store
{
    public class SocialGroupStore : ISocialGroupStore
    {
        private Dictionary<Guid, SocialGroup> _socialPostDic = new Dictionary<Guid, SocialGroup>();

        public async Task<SocialGroup> GetByIdAsync(Guid id)
        {
            {
                SocialGroup socialGroupItem = null;
                _socialPostDic.TryGetValue(id, out socialGroupItem);
                return socialGroupItem;
            }
        }

        public async Task<IEnumerable<SocialGroup>> GetAllAsync()
        {
            return _socialPostDic.Values.ToList();
        }

        public async Task<SocialGroup> SaveAsync(SocialGroup data)
        {
            _socialPostDic.TryAdd(data.Id, data);
            return _socialPostDic[data.Id];
        }

    }
}