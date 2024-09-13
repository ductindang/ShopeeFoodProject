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
    public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public UserAddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAddress>> GetAllUserAddressesByUser(int id)
        {
            var userAddresses = await _context.UserAddresses.Where(ud => ud.UserId == id).ToListAsync();
            return userAddresses;
        }

        public async Task<UserAddressDetail> GetUserAddressDetailById(int id)
        {
            var userAddressDetail = await (from ud in _context.UserAddresses
                                           join w in _context.Wards on ud.WardId equals w.Id
                                           join d in _context.Districts on w.DistrictId equals d.Id
                                           join p in _context.Provinces on d.ProvinceId equals p.Id
                                           where (ud.Id == id)
                                           select new UserAddressDetail
                                           {
                                               NameReminiscent = ud.NameReminiscent,
                                               PhoneNumber = ud.PhoneNumber,
                                               StreetName = ud.Street,
                                               WardName = w.Name,
                                               DistrictName = d.Name,
                                               ProvinceName = d.Name
                                           }).FirstOrDefaultAsync();

            return userAddressDetail;
        }
    }
}
