using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId);
        //Task<IEnumerable<ProductDto>> GetProductsByName(string name);

        //Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId, int page, int pageSize);
        Task<ProductDetailDto> GetProductWithDetailAddress(int productId);
        Task<IEnumerable<ProductDto>> GetProductsBySubCategory(int subCategoryId);
    }
}
