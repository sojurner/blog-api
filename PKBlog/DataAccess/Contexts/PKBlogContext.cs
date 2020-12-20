using Microsoft.EntityFrameworkCore;

namespace PKBlog.DataAccess
{
    public class PKBlogContext : DbContext
    {
        public PKBlogContext(DbContextOptions<PKBlogContext> options) : base(options) { }
        public PKBlogContext() { }

        public DbSet<Models.PageView> PageViews { get; set; }
    }
}
