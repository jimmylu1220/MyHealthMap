using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyHealthMap.Data.Repository.IRepository;

namespace MyHealthMap.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyHealthMapDbContext _db;
        internal DbSet<T> dbSet;
        private readonly IMapper _mapper;

        public Repository(MyHealthMapDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            this.dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
        {
            var entity = _mapper.Map<T>(source);

            await _db.AddAsync(entity);

            return _mapper.Map<TResult>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            dbSet.Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<TResult>> GetAllAsync<TResult>()
        {
            return await dbSet
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await dbSet.FindAsync(id);
        }

        public async Task<TResult> GetAsync<TResult>(int? id)
        {
            var result = await dbSet.FindAsync(id);
            if (result is null)
            {
                throw new Exception();
            }

            return _mapper.Map<TResult>(result);
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }

        public async Task Update<TSource>(int id, TSource source)
        {
            var entity = await GetAsync(id);

            if (entity == null)
            {
                throw new Exception();
            }

            _mapper.Map(source, entity);
            _db.Update(entity);
        }
    }
}
