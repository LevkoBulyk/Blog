using Blog.Data;
using Blog.IRepositories;
using Blog.Models;

namespace Blog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public bool Add(AppUser user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Delete(string id)
        {
            var user = GetUserById(id);
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
