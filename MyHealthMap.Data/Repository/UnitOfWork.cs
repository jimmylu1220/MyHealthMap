using AutoMapper;
using MyHealthMap.Data.Repository.IRepository;

namespace MyHealthMap.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyHealthMapDbContext _db;
        private readonly IMapper _mapper;

        public IRestaurantRepository RestaurantRepository { get; private set; }
        public IMenuRepository MenuRepository { get; private set; }

        public UnitOfWork(MyHealthMapDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            RestaurantRepository = new RestaurantRepository(_db, mapper);
            MenuRepository = new MenuRepository(_db, mapper);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
