using AutoMapper;
using MyHealthMap.Data.Repository.IRepository;
using MyHealthMap.Model;

namespace MyHealthMap.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        private readonly MyHealthMapDbContext _db;
        private readonly IMapper _mapper;

        public RestaurantRepository(MyHealthMapDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}