using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryDto>> GetAllSubCategory();
        Task<SubCategoryDto> GetSubCategoryById(int id);

        Task<IEnumerable<SubCategoryDto>> GetSubCategoriesByCategoryId(int categoryId);
    }
}
