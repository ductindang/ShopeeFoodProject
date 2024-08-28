using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryRequest>>> GetAllSubCategory()
        {
            var subCates = await _subCategoryService.GetAllSubCategories();
            return Ok(subCates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryRequest>> GetSubCategoryById(int id)
        {
            var subCate = await _subCategoryService.GetSubCategoryById(id);
            if(subCate == null)
            {
                return NotFound();
            }
            return Ok(subCate);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryRequest>> InsertSubCategory(BaseSubCategory subCategoryDto)
        {
            var subCate = await _subCategoryService.InsertSubCategory(subCategoryDto);
            if(subCate == null)
            {
                return NotFound();
            }

            return Ok(subCate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryRequest>> UpdateSubCategory(SubCategoryRequest subCategoryDto, int id)
        {
            var subCate = await _subCategoryService.GetSubCategoryById(id);
            if(subCate == null)
            {
                return NotFound();
            }
            subCate = subCategoryDto;
            await _subCategoryService.UpdateSubCategory(subCate);
            return subCate;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategoryRequest>> DeleteSubCategory(int id)
        {
            var subCate = await _subCategoryService.GetSubCategoryById(id);
            if(subCate == null)
            {
                return NotFound();
            }

            await _subCategoryService.DeleteSubCategory(subCate);
            return Ok(subCate);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SubCategoryRequest>>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCates = await _subCategoryService.GetSubCategoriesByCategoryId(categoryId);
            if(subCates == null || !subCates.Any())
            {
                return NotFound();
            }
            return Ok(subCates);
        }

        
    }
}
