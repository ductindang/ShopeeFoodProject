using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductRequest>> GetAllProducts();
        Task<ProductRequest> GetProductById(int id);
        Task<ProductRequest> InsertProduct(BaseProduct productDto);
        Task<ProductRequest> UpdateProduct(ProductRequest productDto);
        Task<ProductRequest> DeleteProduct(ProductRequest productDto);

        Task<IEnumerable<ProductRequest>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<ProductRequest>> GetProductsByName(string name);
        Task<IEnumerable<ProductRequest>> GetProductsByCategoryId(int categoryId, int page, int pageSize);
        Task<IEnumerable<ProductRequest>> GetProductsPerPage(int categoryId, int page, int productPerPage);
        Task<IEnumerable<ProductRequest>> GetProductsByStoreId(int storeId);
        Task<ProductDetailDto> GetProductWithDetailAdress(int productId);
        Task<IEnumerable<ProductRequest>> GetProductsByDiscount(int discountId);
        //Task<IEnumerable<DiscountRequest>> GetAllDiscountsFromProduct();
        Task<IEnumerable<ProductRequest>> GetProductsWithUniqueDiscounts();
        Task<DiscountRequest?> GetDiscountByProduct(int productId);
        Task<IEnumerable<ProductRequest>> GetProductsBySubCategoryPerPage(int subCategoryId, int page, int pageSize);
        Task<IEnumerable<ProductRequest>> GetProductsBySubCategory(int subCategoryId);
    }
}
