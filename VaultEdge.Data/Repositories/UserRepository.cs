using System.Collections.Generic;
using System.Linq;
using VaultEdge.Core.Models;
using VaultEdge.Data;

namespace VaultEdge.Data.Repositories
{
    public class UserRepository
    {
        private readonly VaultDbContext _context;

        public UserRepository(VaultDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(string id) => _context.Users.Find(id);

        public User GetByUsername(string username) =>
            _context.Users.FirstOrDefault(u => u.Username == username);

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
