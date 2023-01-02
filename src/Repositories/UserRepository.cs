using Blog.Data;
using Blog.IRepositories;
using Blog.Models;

namespace Blog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(AppDbContext context,
                              IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
            var user = _context.Users.FirstOrDefault(u => u.Id.Equals(id));
            if (user != null && user.PhotoUrl == null)
            {
                user.PhotoUrl = _configuration.GetValue<string>("DefaultUserPhoto");
                //Save();
            }
            return user;
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
