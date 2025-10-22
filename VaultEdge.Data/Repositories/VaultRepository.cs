using System.Collections.Generic;
using System.Linq;
using VaultEdge.Core.Models;
using VaultEdge.Data;

namespace VaultEdge.Data.Repositories
{
    public class VaultRepository
    {
        private readonly VaultDbContext _context;

        public VaultRepository(VaultDbContext context)
        {
            _context = context;
        }

        public IEnumerable<VaultItem> GetByUserId(string userId) =>
            _context.VaultItems.Where(v => v.UserId == userId).ToList();

        public VaultItem GetById(string id) => _context.VaultItems.Find(id);

        public void Add(VaultItem item)
        {
            _context.VaultItems.Add(item);
            _context.SaveChanges();
        }

        public void Update(VaultItem item)
        {
            _context.VaultItems.Update(item);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var item = _context.VaultItems.Find(id);
            if (item != null)
            {
                _context.VaultItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
