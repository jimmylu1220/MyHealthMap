using System.ComponentModel.DataAnnotations;

namespace MyHealthMap.Model
{
    public abstract class BaseRestaurantDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
