using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.DTOs;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTypesController : ControllerBase
    {
        private readonly ISubTypeService _subTypeService;

        public SubTypesController(ISubTypeService subTypeService)
        {
            _subTypeService = subTypeService;
        }

        // GET: api/SubTypes
        // 取得所有小分類
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTypeDto>>> GetSubTypes()
        {
            var subTypes = await _subTypeService.GetAllSubTypesAsync();
            return Ok(subTypes);
        }

        // GET: api/SubTypes/{id}
        // 取得指定 ID 的小分類
        [HttpGet("{id}")]
        public async Task<ActionResult<SubTypeDto>> GetSubType(int id)
        {
            var subType = await _subTypeService.GetSubTypeByIdAsync(id);
            if (subType == null)
            {
                return NotFound();
            }
            return Ok(subType);
        }

        // GET: api/StoreTypes/{storeTypeId}/SubTypes
        // 取得指定大類型下所有小分類
        [HttpGet("/api/StoreTypes/{storeTypeId}/SubTypes")]
        public async Task<ActionResult<IEnumerable<SubTypeDto>>> GetSubTypesByStoreType(int storeTypeId)
        {
            var subTypes = await _subTypeService.GetSubTypesByStoreTypeIdAsync(storeTypeId);
            return Ok(subTypes);
        }

        // POST: api/SubTypes
        // 新增一筆小分類資料
        [HttpPost]
        public async Task<ActionResult<SubTypeDto>> CreateSubType([FromBody] SubTypeDto subTypeDto)
        {
            if (subTypeDto == null)
            {
                return BadRequest();
            }

            await _subTypeService.AddSubTypeAsync(subTypeDto);
            // 假設新增後 subTypeDto 的 SubTypeId 被賦值
            return CreatedAtAction(nameof(GetSubType), new { id = subTypeDto.SubTypeId }, subTypeDto);
        }

        // PUT: api/SubTypes/{id}
        // 更新指定小分類資料
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubType(int id, [FromBody] SubTypeDto subTypeDto)
        {
            if (id != subTypeDto.SubTypeId)
            {
                return BadRequest("ID 不一致");
            }

            await _subTypeService.UpdateSubTypeAsync(subTypeDto);
            return NoContent();
        }

        // DELETE: api/SubTypes/{id}
        // 刪除指定小分類
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubType(int id)
        {
            await _subTypeService.DeleteSubTypeAsync(id);
            return NoContent();
        }
    }
}
