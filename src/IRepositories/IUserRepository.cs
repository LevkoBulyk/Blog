using Blog.Models;

namespace Blog.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(string id);
        bool Add(AppUser user);
        bool Delete(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
