using System.Collections.Generic;
using System.Linq;
using VaultEdge.Core.Interfaces;
using VaultEdge.Core.Models;

namespace VaultEdge.Core.Services
{
    public class VaultService : IVaultService
    {
        private readonly List<VaultItem> _items = new();

        public IEnumerable<VaultItem> GetItems(string userId)
        {
            return _items.Where(i => i.UserId == userId);
        }

        public VaultItem AddItem(VaultItem item)
        {
            item.Id = Guid.NewGuid().ToString();
            item.CreatedAt = DateTime.UtcNow;
            item.UpdatedAt = DateTime.UtcNow;
            _items.Add(item);
            return item;
        }

        public VaultItem UpdateItem(string id, VaultItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == id);
            if (existing == null) return null;

            existing.Title = item.Title;
            existing.Content = item.Content;
            existing.UpdatedAt = DateTime.UtcNow;
            return existing;
        }

        public bool DeleteItem(string id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
