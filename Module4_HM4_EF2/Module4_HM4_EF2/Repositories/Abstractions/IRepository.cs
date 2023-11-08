namespace Module4_HM4_EF2.Repositories.Abstractions
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task CreateAsync(T item);
            Task<bool> UpdateAsync(T item);
            Task<bool> DeleteAsync(int id);
        }
    }
}
