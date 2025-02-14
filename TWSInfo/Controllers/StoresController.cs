using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stores>>> GetStores()
        {
            var stores = await _storeService.GetAllStoresAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stores>> GetStore(int id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound();
            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult> AddStore([FromBody] Stores store)
        {
            await _storeService.AddStoreAsync(store);
            return CreatedAtAction(nameof(GetStore), new { id = store.StoreId }, store);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStore(int id, [FromBody] Stores store)
        {
            if (id != store.StoreId)
                return BadRequest();
            await _storeService.UpdateStoreAsync(store);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStore(int id)
        {
            await _storeService.DeleteStoreAsync(id);
            return NoContent();
        }

        [HttpGet("bychain/{id}")]
        public async Task<IActionResult> GetStoresByChain(int id)
        {
            var stores = await _storeService.GetStoresByChainIdAsync(id);
            if (stores == null || !stores.Any())
            {
                return NotFound();
            }
            return Ok(stores);
        }
    }
}
