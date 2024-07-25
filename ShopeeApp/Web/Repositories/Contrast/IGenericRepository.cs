namespace Web.Repositories.Contrast
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int Id);
        public Task<T> Insert(T model);
        public Task<T> Update(T model);
        public Task<T> DeleteById(T model);
        public Task<int> Save();
    }
}
