using Microsoft.AspNetCore.Mvc.Filters;
using SocialUpdatesAPI.Store;
using System.Diagnostics.CodeAnalysis;


namespace SocialUpdatesAPI.Models
{
    public class SocialUpdatesContext : IUpdateStore
    {
        IUpdateStore _updateStore;
        public SocialUpdatesContext(IUpdateStore updateStore)
        {
            _updateStore = updateStore;
        }

        public async Task SaveAsync(PostItem postItem)
        { 
           await _updateStore.SaveAsync(postItem);
        }
    }
}



