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
    public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
    {
        private readonly ApplicationDbContext _context;
        public ProvinceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Province> GetProvinceById(string id)
        {
            return await _context.Provinces
                .FirstOrDefaultAsync(pro => pro.Id == id);
        }
    }
}
