using System.ComponentModel.DataAnnotations.Schema;

namespace MyHealthMap.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public double Calories { get; set; }
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}