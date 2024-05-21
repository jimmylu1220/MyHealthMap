using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthMap.Data.Repository.IRepository;
using MyHealthMap.Model;

namespace MyHealthMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _unitOfWork.RestaurantRepository.GetAllAsync();
            return Ok(restaurants);
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _unitOfWork.RestaurantRepository.GetAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, UpdateRestaurantDto updateRestaurantDto)
        {
            if (id != updateRestaurantDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _unitOfWork.RestaurantRepository.Update(id, updateRestaurantDto);
                await _unitOfWork.Save();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = await _unitOfWork.RestaurantRepository.AddAsync<CreateRestaurantDto, GetRestaurantDto>(createRestaurantDto);
            await _unitOfWork.Save();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            await _unitOfWork.RestaurantRepository.DeleteAsync(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
