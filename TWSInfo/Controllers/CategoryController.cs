using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWSInfo.Models.DTOs;
using TWSInfo.Service.IService;

namespace TWSInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        // 回傳完整分類樹狀結構，包括 StoreTypes、SubTypes 與 Chains
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoryTree()
        {
            var tree = await _categoryService.GetCategoryTreeAsync();
            return Ok(tree);
        }
    }
}
