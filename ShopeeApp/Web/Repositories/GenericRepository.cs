using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Repositories.Contrast;

namespace Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> objects = await _dbSet.ToListAsync();
            return objects;
        }

        public async Task<T> GetById(int Id)
        {
            var obj = await _dbSet.FindAsync();
            return obj;
        }

        public async Task<T> Insert(T model)
        {
            if (model == null)
            {
                return null;
            }

            await _dbSet.AddAsync(model);
            await Save();
            return model;
        }

        public async Task<T> Update(T model)
        {
            if(model == null)
            {
                return null;
            }

            _dbSet.Update(model);
            await Save();
            return model;
        }

        public async Task<T> DeleteById(T model)
        {
            if(model == null)
            {
                return null;
            }

            _dbSet.Remove(model);
            await Save();
            return model;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
