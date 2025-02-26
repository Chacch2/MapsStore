using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.DTOs;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreTypesController : ControllerBase
    {
        private readonly IStoreTypeService _storeTypeService;

        public StoreTypesController(IStoreTypeService storeTypeService)
        {
            _storeTypeService = storeTypeService;
        }

        // GET: api/StoreTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreTypeDto>>> GetStoreTypes()
        {
            var storeTypes = await _storeTypeService.GetAllStoreTypesAsync();
            return Ok(storeTypes);
        }

        // GET: api/StoreTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreTypeDto>> GetStoreType(int id)
        {
            var storeType = await _storeTypeService.GetStoreTypeByIdAsync(id);
            if (storeType == null)
            {
                return NotFound();
            }
            return Ok(storeType);
        }

        // POST: api/StoreTypes
        [HttpPost]
        public async Task<ActionResult<StoreTypeDto>> CreateStoreType([FromBody] StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
            {
                return BadRequest();
            }
            await _storeTypeService.AddStoreTypeAsync(storeTypeDto);
            // 假設新增後 storeTypeDto.StoreTypeId 已被填入（或從 service 中回傳新增後的資料）
            return CreatedAtAction(nameof(GetStoreType), new { id = storeTypeDto.StoreTypeId }, storeTypeDto);
        }

        // PUT: api/StoreTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStoreType(int id, [FromBody] StoreTypeDto storeTypeDto)
        {
            if (id != storeTypeDto.StoreTypeId)
            {
                return BadRequest("ID 不一致");
            }
            await _storeTypeService.UpdateStoreTypeAsync(storeTypeDto);
            return NoContent();
        }

        // DELETE: api/StoreTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreType(int id)
        {
            await _storeTypeService.DeleteStoreTypeAsync(id);
            return NoContent();
        }
    }
}
