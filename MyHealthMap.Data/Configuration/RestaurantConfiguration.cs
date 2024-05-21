using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealthMap.Model;

namespace MyHealthMap.Data.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);

            builder.HasMany(x => x.Menus).WithOne(x => x.Restaurant).HasForeignKey(x => x.RestaurantId);

            builder.HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "勁請享用健康廚房-鳳山五甲店",
                    City = "高雄市",
                    Address = "830高雄市鳳山區五甲三路27號",
                    PhoneNumber = "078210715"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "懂吃健康餐廚-五甲店",
                    City = "高雄市",
                    Address = "830高雄市鳳山區忠誠路27號",
                    PhoneNumber = "0971708796"
                }
            );
        }
    }
}
