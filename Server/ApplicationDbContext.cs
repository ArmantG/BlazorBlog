using BlazorBlog.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorBlog.Server;

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options)
        {

        }
    
        public DbSet<BlogPost>? BlogPosts { get; set; }
 
    }
