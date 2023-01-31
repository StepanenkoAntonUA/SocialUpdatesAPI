using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialUpdatesAPI.Store;
using System.Diagnostics.CodeAnalysis;


namespace SocialUpdatesAPI.Models
{
    public class SocialUpdatesContext : DbContext, IUpdateStore
    {
        IUpdateStore _updateStore;
        public SocialUpdatesContext(DbContextOptions<SocialUpdatesContext> options, IUpdateStore updateStore)
            : base(options)
        {
            _updateStore = updateStore;
        }
        public DbSet<PostItem> SocialUpdateItems { get; set; } = null!;

        public async Task SaveAsync(PostItem postItem)
        { 
           await _updateStore.SaveAsync(postItem);
        }
    }
}



