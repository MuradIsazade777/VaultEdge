using Xunit;
using VaultEdge.Core.Services;
using VaultEdge.Core.Models;
using System.Linq;

namespace VaultEdge.Tests
{
    public class VaultTests
    {
        [Fact]
        public void Should_Add_And_Retrieve_VaultItem()
        {
            var vaultService = new VaultService();

            var item = new VaultItem
            {
                UserId = "user123",
                Title = "My Secret",
                Content = "Encrypted content"
            };

            var added = vaultService.AddItem(item);
            Assert.NotNull(added);
            Assert.Equal("My Secret", added.Title);

            var items = vaultService.GetItems("user123").ToList();
            Assert.Single(items);
            Assert.Equal("Encrypted content", items[0].Content);
        }

        [Fact]
        public void Should_Update_And_Delete_VaultItem()
        {
            var vaultService = new VaultService();

            var item = vaultService.AddItem(new VaultItem
            {
                UserId = "user456",
                Title = "Old Title",
                Content = "Old Content"
            });

            item.Title = "New Title";
            item.Content = "New Content";
            var updated = vaultService.UpdateItem(item.Id, item);

            Assert.Equal("New Title", updated.Title);

            var deleted = vaultService.DeleteItem(item.Id);
            Assert.True(deleted);
        }
    }
}
