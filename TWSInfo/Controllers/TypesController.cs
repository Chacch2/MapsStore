using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.EFModels;
using TWSInfo.Service;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreTypes>>> GetTypes()
        {
            var types = await _typeService.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StoreTypes>>> GetTypes(int id)
        {
            var types = await _typeService.GetTypeByIdAsync(id);
            if (types == null)
                return NotFound();
            return Ok(types);
        }
    }

}
