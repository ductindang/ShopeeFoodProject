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
    public class StoreAddressRepository : GenericRepository<StoreAddress>, IStoreAddressRepository
    {
        private ApplicationDbContext _context;
        public StoreAddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StoreAddress>> GetAllStoreAddressByWardId(string wardId)
        {
            return await _context.StoreAddresses
                .Where(addr => addr.WardId == wardId)
                .OrderBy(addr => addr.StoreId)
                .ToListAsync();
        }

        //public async Task<StoreDetail> GetStoreAddressWithDetailAddress(int storeAddressId)
        //{
        //    var storeDetail = await (from sa in _context.StoreAddresses 
        //                             join w in _context.Wards on sa.WardId equals w.Id
        //                             join d in _context.Districts on w.DistrictId equals d.Id
        //                             join pr in _context.Provinces on d.ProvinceId equals pr.Id
        //                             where sa.Id == storeAddressId
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
    }
}
