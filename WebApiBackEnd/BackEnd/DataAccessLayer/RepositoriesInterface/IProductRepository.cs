using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, int page, int pageSize);
        Task<IEnumerable<Product>> GetProductsPerPage(int categoryId, int page = 1, int productPerPage = 9);
        Task<IEnumerable<Product>> GetProductsByStoreId(int storeId);
        Task<ProductDetail> GetProductWithDetailAddress(int productId);
        Task<IEnumerable<Product>> GetProductsByDiscount(int discountId);

        //Task<IEnumerable<Discount>> GetAllDiscountsFromProduct();

        Task<IEnumerable<Product>> GetProductsWithUniqueDiscounts();
        Task<Discount> GetDiscountByProduct(int productId);
        Task<IEnumerable<Product>> GetProductsBySubCategoryPerPage(int subCategoryId, int page, int pageSize);
        Task<IEnumerable<Product>> GetProductsBySubCategory(int subCategoryId);
    }
}
