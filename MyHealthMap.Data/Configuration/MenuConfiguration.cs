using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyHealthMap.Model;

namespace MyHealthMap.Data.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(500);

            builder.HasOne(x => x.Restaurant).WithMany(x => x.Menus).HasForeignKey(x => x.RestaurantId);

            builder.HasData(
               new Menu
               {
                   Id = 1,
                   Name = "舒肥雞胸餐盒",
                   Description = "低脂且高蛋白的雞胸肉\r\n不論是想大口吃肉又想減少身體負擔的你\r\n或者想增肌減脂的你\r\n都會是個不錯的選擇唷",
                   Price = 105,
                   Calories = 435,
                   RestaurantId = 1
               },
               new Menu
               {
                   Id = 2,
                   Name = "醬燒春雞餐盒",
                   Description = "無骨雞腿丁\r\n加入洋蔥木耳紅蘿蔔及杏鮑菇一起拌炒\r\n\r\n逼出蔬菜的鮮甜及雞腿丁的香氣加入調醬融合\r\n口感紮實爽脆還能補充大量膳食纖維\r\n吃起來鹹甜鹹甜像紅燒的味道",
                   Price = 115,
                   Calories = 558,
                   RestaurantId = 1
               },
               new Menu
               {
                   Id = 3,
                   Name = "薑汁燒肉豬",
                   Description = "店家獨門熬煮薑汁與豬肉大火快炒",
                   Price = 129,
                   Calories = 525,
                   RestaurantId = 2
               },
               new Menu
               {
                   Id = 4,
                   Name = "照燒嫩雞腿",
                   Description = "煮熟後的嫩雞腿，再用獨家照燒醬燉煮",
                   Price = 129,
                   Calories = 576,
                   RestaurantId = 2
               }
            );
        }
    }
}
