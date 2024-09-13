using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryRequest>>> GetAllCategories()
        {
            try
            {
                var cates = await _categoryService.GetAllCategories();
                return Ok(cates);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryRequest>> GetCategoryById(int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if (cate == null)
            {
                return NotFound();
            }
            return Ok(cate);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryRequest>> InsertCategory([FromBody] BaseCategory baseCategory)
        {
            var cate = await _categoryService.InsertCategory(baseCategory);
            return cate;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CategoryRequest>> UpdateCategory([FromBody] BaseCategory baseCategory, int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if (cate == null)
            {
                return NotFound();
            }
            cate.Name = baseCategory.Name;
            var result = await _categoryService.UpdateCategory(cate);
            return cate;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CategoryRequest>> DeleteCategory(int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if (cate == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryById(id);
            return cate;
        }
    }
}
