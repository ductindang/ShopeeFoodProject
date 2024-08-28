using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface ISubCategoryService
    {
        public Task<IEnumerable<SubCategoryRequest>> GetAllSubCategories();
        public Task<SubCategoryRequest> GetSubCategoryById(int id);
        public Task<SubCategoryRequest> InsertSubCategory(BaseSubCategory subCategoryDto);
        public Task<SubCategoryRequest> UpdateSubCategory(SubCategoryRequest subCategoryDto);
        public Task<SubCategoryRequest> DeleteSubCategory(SubCategoryRequest subCategoryDto);

        public Task<IEnumerable<SubCategoryRequest>> GetSubCategoriesByCategoryId(int categoryId);
    }
}
