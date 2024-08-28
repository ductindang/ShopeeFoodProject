using AutoMapper;
using Azure;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductRequest>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<ProductRequest> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            if(product == null)
            {
                return null;
            }

            return _mapper.Map<ProductRequest>(product);
        }

        public async Task<ProductRequest> InsertProduct(BaseProduct productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.CreatedAt = DateTime.UtcNow.AddHours(7);
            product.UpdatedAt = DateTime.UtcNow.AddHours(7);
            await _productRepository.Insert(product);
            return _mapper.Map<ProductRequest>(product);
        }

        public async Task<ProductRequest> UpdateProduct(ProductRequest productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.UpdatedAt = DateTime.UtcNow.AddHours(7);
            await _productRepository.Update(product);
            return productDto;
        }

        public async Task<ProductRequest> DeleteProduct(ProductRequest productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.Delete(product);
            return productDto;
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsByName(string name)
        {
            var products = await _productRepository.GetProductsByName(name);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsByCategoryId(int categoryId, int page, int pageSize)
        {
            var products = await _productRepository.GetProductsByCategoryId(categoryId, page, pageSize);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsPerPage(int categoryId, int page, int productPerPage)
        {
            var products = await _productRepository.GetProductsPerPage(categoryId, page, productPerPage); ;
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsByStoreId(int storeId)
        {
            var produts = await _productRepository.GetProductsByStoreId(storeId);
            return _mapper.Map<IEnumerable<ProductRequest>>(produts);
        }

        public async Task<ProductDetailDto> GetProductWithDetailAdress(int productId)
        {
            var product = await _productRepository.GetProductWithDetailAddress(productId);
            return _mapper.Map<ProductDetailDto>(product);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsByDiscount(int discountId)
        {
            var products = await _productRepository.GetProductsByDiscount(discountId);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        //public async Task<IEnumerable<DiscountRequest>> GetAllDiscountsFromProduct()
        //{
        //    var discounts = await _productRepository.GetAllDiscountsFromProduct();
        //    return _mapper.Map<IEnumerable<DiscountRequest>>(discounts);
        //}

        public async Task<IEnumerable<ProductRequest>> GetProductsWithUniqueDiscounts()
        {
            var products = await _productRepository.GetProductsWithUniqueDiscounts();
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<DiscountRequest?> GetDiscountByProduct(int productId)
        {
            var discount = await _productRepository.GetDiscountByProduct(productId);
            return _mapper.Map<DiscountRequest?>(discount);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            var products = await _productRepository.GetProductsBySubCategoryPerPage(subCategoryId, page, pageSize);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }

        public async Task<IEnumerable<ProductRequest>> GetProductsBySubCategory(int subCategoryId)
        {
            var products = await _productRepository.GetProductsBySubCategory(subCategoryId);
            return _mapper.Map<IEnumerable<ProductRequest>>(products);
        }
    }
}
