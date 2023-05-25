using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.DataAccessLayer
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<BlogIssue> BlogIssues { get; set; }
        public DbSet<BlogInstance> BlogInstances { get; set; }

    }
}
