using Blog.Models;

namespace Blog.IRepositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<IEnumerable<Article>> GetAllArticlesSorted();
        Task<Article> GetArticleById(int id);
        bool Create(Article article);
        bool Update(Article article);
        Task<bool> Delete(int id);
        bool Save();
    }
}
