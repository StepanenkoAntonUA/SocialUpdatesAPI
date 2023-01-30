using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace SocialUpdatesAPI.Models
{
    public class SocialUpdatesContext : DbContext
    {
        public SocialUpdatesContext(DbContextOptions <SocialUpdatesContext> options) 
            : base(options)
        {
        }
            public DbSet<PostItem> SocialUpdateItems { get; set; } = null!;
    }
}



