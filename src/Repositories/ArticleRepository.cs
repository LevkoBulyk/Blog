using Blog.Data;
using Blog.IRepositories;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Article article)
        {
            _context.Articles.Add(article);
            return Save();
        }

        public async Task<bool> Delete(int id)
        {
            var article = await _context.Articles.AsNoTracking().FirstAsync(a => a.Id == id);
            _context.Articles.Remove(article);
            return Save();
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            return _context.Articles.ToList();
        }

        public async Task<IEnumerable<Article>> GetAllArticlesSorted()
        {
            return _context.Articles.OrderByDescending(a => a.LastEdition).ToList();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles.Include(a => a.Author).FirstAsync(a => a.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Article article)
        {
            _context.Articles.Update(article);
            return Save();
        }
    }
}
