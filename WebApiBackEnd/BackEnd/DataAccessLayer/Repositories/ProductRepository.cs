using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            var products = await _context.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId, int page, int pageSize)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsPerPage(int categoryId, int page, int productPerPage)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * productPerPage)
                .Take(productPerPage)
                .ToListAsync();
        }
        

        public async Task<IEnumerable<Product>> GetProductsByStoreId(int storeId)
        {
            return await _context.Products
                .Where(p => p.StoreId == storeId)
                .ToListAsync();
        }

        public async Task<ProductDetail> GetProductWithDetailAddress(int productId)
        {
            var productDetail = await (from p in _context.Products
                                       join s in _context.Stores on p.StoreId equals s.Id
                                       join sa in _context.StoreAddresses on s.Id equals sa.StoreId
                                       join w in _context.Wards on sa.WardId equals w.Id
                                       join d in _context.Districts on w.DistrictId equals d.Id
                                       join pr in _context.Provinces on d.ProvinceId equals pr.Id
                                       where p.Id == productId
                                       select new ProductDetail
                                       {
                                           ProductName = p.Name,
                                           ProductImage = p.Image,
                                           ProductPrice = p.Price,
                                           ProductDescription = p.Description,
                                           StoreName = s.Name,
                                           StoreImage = s.Image,
                                           StoreOpenTime = s.OpenTime,
                                           StoreCloseTime = s.CloseTime,
                                           StoreDescription = s.Description,
                                           StreetName = sa.Street,
                                           WardName = w.Name,
                                           DistrictName = d.Name,
                                           ProvinceName = pr.Name
                                       }).FirstOrDefaultAsync();

            return productDetail;
        }

        public async Task<IEnumerable<Product>> GetProductsByDiscount(int discountId)
        {
            var products = await _context.Products
                .Where(p => p.DiscountId == discountId)
                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsWithUniqueDiscounts()
        {
            var productsWithUniqueDiscounts = await _context.Products
            .Where(p => p.DiscountId.HasValue && p.Discount != null)
            .GroupBy(p => p.DiscountId)
            .Select(g => g.FirstOrDefault())
            .ToListAsync();

            return productsWithUniqueDiscounts;
        }

        public async Task<Discount?> GetDiscountByProduct(int productId)
        {
            var discount = await _context.Products
                .Where(p => p.Id == productId && p.Discount != null)
                .Select(p => p.Discount)
                .FirstOrDefaultAsync();

            return discount;
        }

        public async Task<IEnumerable<Product>> GetProductsBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            return await _context.Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySubCategory(int subCategoryId)
        {
            return await _context.Products
                .Where(p => p.SubCategoryId == subCategoryId)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

    }
}
