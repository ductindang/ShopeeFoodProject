using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly ApplicationDbContext _context;

        public StoreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetStoresByCategoryId(int categoryId)
        {
            var stores = await _context.Stores
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
            return stores;
        }

        public async Task<IEnumerable<Store>> GetStoresByName(string name)
        {
            var stores = await _context.Stores
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
            return stores;
        }
        

        //public async Task<IEnumerable<Store>> GetAllStoresByWardId(string wardId)
        //{
        //    var stores = await _context.Stores
        //        .Where(str => str.WardId == wardId)
        //        .ToListAsync();
        //    return stores;
        //}

        //public async Task<StoreDetail> GetStoreWithDetailAddress(int storeId)
        //{
        //    var storeDetail = await (from s in _context.Stores
        //                             join sa in _context.StoreAddresses on s.Id equals sa.StoreId
        //                             join w in _context.Wards on sa.WardId equals w.Id
        //                             join d in _context.Districts on w.DistrictId equals d.Id
        //                             join pr in _context.Provinces on d.ProvinceId equals pr.Id
        //                             where s.Id == storeId
        //                             select new StoreDetail
        //                             {
        //                                 StoreName = s.Name,
        //                                 StoreMaxPrice = s.MaxPrice,
        //                                 StoreImage = s.Image,
        //                                 StoreOpenTime = s.OpenTime,
        //                                 StoreCloseTime = s.CloseTime,
        //                                 StoreDescription = s.Description,
        //                                 StreetName = sa.Street,
        //                                 WardName = w.Name,
        //                                 DistrictName = d.Name,
        //                                 ProvinceName = pr.Name
        //                             }).FirstOrDefaultAsync();

        //    return storeDetail;
        //}

        public async Task<StoreDetail> GetStoreWithDetailAddress(int storeId, int storeAddressId, string wardId)
        {
            var storeDetail = await (from s in _context.Stores
                                     join sa in _context.StoreAddresses on s.Id equals sa.StoreId
                                     join w in _context.Wards on sa.WardId equals w.Id
                                     join d in _context.Districts on w.DistrictId equals d.Id
                                     join pr in _context.Provinces on d.ProvinceId equals pr.Id
                                     where (s.Id == storeId && sa.Id == storeAddressId && sa.WardId == wardId)
                                     select new StoreDetail
                                     {
                                         StoreName = s.Name,
                                         StoreMaxPrice = s.MaxPrice,
                                         StoreImage = s.Image,
                                         StoreOpenTime = s.OpenTime,
                                         StoreCloseTime = s.CloseTime,
                                         StoreDescription = s.Description,
                                         StreetName = sa.Street,
                                         WardName = w.Name,
                                         DistrictName = d.Name,
                                         ProvinceName = pr.Name
                                     }).FirstOrDefaultAsync();

            return storeDetail;
        }

        public async Task<IEnumerable<Store>> GetStoresBySubCategoryPerPage(int subCategoryId, int page, int pageSize)
        {
            return await _context.Stores
                .Where(p => p.SubCategoryId == subCategoryId)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Store>> GetStoresBySubCategory(int subCategoryId)
        {
            return await _context.Stores
                .Where(p => p.SubCategoryId == subCategoryId)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<StoreMenuProductDetail>> GetStoreMenuProductDetails(int storeId)
        {
            var result = await (from store in _context.Stores
                                join menu in _context.Menus on store.Id equals menu.StoreId
                                join menuProduct in _context.MenuProducts on menu.Id equals menuProduct.MenuId
                                join product in _context.Products on menuProduct.ProductId equals product.Id
                                where store.Id == storeId
                                select new StoreMenuProductDetail
                                {
                                    StoreName = store.Name,
                                    MenuName = menu.Name,
                                    ProductName = product.Name,
                                    ProductPrice = product.Price,
                                    ProductDescription = menuProduct.Description
                                }).ToListAsync();

            return result;
        }
    }
}
