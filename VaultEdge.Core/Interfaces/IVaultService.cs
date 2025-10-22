using System.Collections.Generic;
using VaultEdge.Core.Models;

namespace VaultEdge.Core.Interfaces
{
    public interface IVaultService
    {
        IEnumerable<VaultItem> GetItems(string userId);
        VaultItem AddItem(VaultItem item);
        VaultItem UpdateItem(string id, VaultItem item);
        bool DeleteItem(string id);
    }
}
