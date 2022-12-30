using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<ArticleText> ArticleTexts { get; set; }
        public IEnumerable<ArticleMedia> ArticleMedias { get; set; }
    }
}
