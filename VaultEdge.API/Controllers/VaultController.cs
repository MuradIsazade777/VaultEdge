using Microsoft.AspNetCore.Mvc;
using VaultEdge.Core.Interfaces;
using VaultEdge.Core.Models;

namespace VaultEdge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultController : ControllerBase
    {
        private readonly IVaultService _vaultService;

        public VaultController(IVaultService vaultService)
        {
            _vaultService = vaultService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetVaultItems(string userId)
        {
            var items = _vaultService.GetItems(userId);
            return Ok(items);
        }

        [HttpPost]
        public IActionResult AddVaultItem([FromBody] VaultItem item)
        {
            var result = _vaultService.AddItem(item);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVaultItem(string id, [FromBody] VaultItem item)
        {
            var result = _vaultService.UpdateItem(id, item);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVaultItem(string id)
        {
            var result = _vaultService.DeleteItem(id);
            return Ok(result);
        }
    }
}
