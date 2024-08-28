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
    }
}
