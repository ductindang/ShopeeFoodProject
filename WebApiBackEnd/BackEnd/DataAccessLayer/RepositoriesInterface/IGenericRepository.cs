using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.RepositoriesInterface
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int Id);
        public Task<T> Insert(T model);
        public Task<T> Update(T model);
        public Task<T> Delete(T model);
        public Task<int> Save();
    }
}
