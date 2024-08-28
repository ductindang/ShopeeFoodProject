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
    public class WardRepository : GenericRepository<Ward>, IWardRepository
    {
        private readonly ApplicationDbContext _context;
        public WardRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ward> GetWardById(string id)
        {
            return await _context.Wards.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Ward>> GetWardsByDistrict(string districtId)
        {
            return await _context.Wards
                .Where(ward => ward.DistrictId == districtId)
                .OrderBy(ward => ward.Id)
                .ToListAsync();
        }
    }
}
