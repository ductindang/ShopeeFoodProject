using DataAccessLayer.Data;
using DataAccessLayer.Repositories.Contrast;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> objects = await _dbSet.ToListAsync();
            return objects;
        }

        public async Task<T> GetById(int id)
        {
            var obj = await _dbSet.FindAsync(id);
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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingEntity = await _context.Set<T>().FindAsync(GetKey(model));
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            _context.Set<T>().Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            await Save();
            return model;
        }

        private object GetKey(T model)
        {
            var keyName = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();
            return model.GetType().GetProperty(keyName).GetValue(model, null);
        }

        public async Task<T> Delete(T model)
        {
            if (model == null)
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
