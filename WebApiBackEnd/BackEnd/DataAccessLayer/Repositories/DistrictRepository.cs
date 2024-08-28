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
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<District> GetDistrictById(string id)
        {
            return await _context.Districts
                .FirstOrDefaultAsync(dis => dis.Id == id);
        }

        public async Task<IEnumerable<District>> GetDistrictsByProvince(string provinceId)
        {
            return await _context.Districts
                .Where(dis => dis.ProvinceId == provinceId)
                .OrderBy(dis => dis.Id)
                .ToListAsync();
        }
    }
}
