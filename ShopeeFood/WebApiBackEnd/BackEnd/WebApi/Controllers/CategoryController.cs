using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
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
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var cates = await _categoryService.GetAllCategories();
            return Ok(cates);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if(cate == null)
            {
                return NotFound();
            }
            return Ok(cate);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> InsertCategory([FromBody] CategoryDto categoryDto)
        {
            categoryDto.CreatedAt = DateTime.UtcNow;
            categoryDto.UpdatedAt = DateTime.UtcNow;
            var cate = await _categoryService.InsertCategory(categoryDto);
            return cate;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> InsertCategory([FromBody] CategoryDto categoryDto, int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if (cate == null)
            {
                return NotFound();
            }
            categoryDto.UpdatedAt = DateTime.UtcNow.AddHours(7);
            categoryDto.Id = id;
            cate = categoryDto;
            var result = await _categoryService.UpdateCategory(cate);
            return cate;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
        {
            var cate = await _categoryService.GetCategoryById(id);
            if(cate == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryById(id);
            return cate;
        }
    }
}
