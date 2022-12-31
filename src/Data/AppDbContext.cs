using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ArticleText> ArticleTexts { get; set; }
        public DbSet<ArticleMedia> ArticleMedias { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
