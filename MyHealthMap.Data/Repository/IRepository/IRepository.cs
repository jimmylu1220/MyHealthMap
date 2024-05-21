namespace MyHealthMap.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        void Update(T entity);
        Task Update<TSource>(int id, TSource source);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
