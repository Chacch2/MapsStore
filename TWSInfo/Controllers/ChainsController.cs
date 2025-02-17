using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChainsController : ControllerBase
    {
        private readonly IChainService _chainService;

        public ChainsController(IChainService chainService)
        {
            _chainService = chainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chains>>> GetChains()
        {
            var chains = await _chainService.GetAllChainsAsync();
            return Ok(chains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chains>> GetChain(int id)
        {
            var chain = await _chainService.GetChainByIdAsync(id);
            if (chain == null)
                return NotFound();
            return Ok(chain);
        }



        [HttpPost]
        public async Task<ActionResult> AddChain([FromBody] Chains chain)
        {
            await _chainService.AddChainAsync(chain);
            return CreatedAtAction(nameof(GetChain), new { id = chain.ChainId }, chain);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChain(int id, [FromBody] Chains chain)
        {
            if (id != chain.ChainId)
                return BadRequest();
            await _chainService.UpdateChainAsync(chain);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChain(int id)
        {
            await _chainService.DeleteChainAsync(id);
            return NoContent();
        }

        [HttpGet("GetChainsByTypeId/{typeId}")]
        public async Task<ActionResult<IEnumerable<GetChainsByTypeIdDto>>> GetChainsByTypeId(int typeId)
        {
            var result = await _chainService.GetChainsByTypeIdAsync(typeId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
