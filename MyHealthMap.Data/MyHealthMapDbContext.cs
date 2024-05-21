using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyHealthMap.Data.Configuration;
using MyHealthMap.Model;

namespace MyHealthMap.Data
{
    public class MyHealthMapDbContext : DbContext
    {
        public MyHealthMapDbContext(DbContextOptions<MyHealthMapDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
        }

    }

    public class MyHealthMapDbContextFactory : IDesignTimeDbContextFactory<MyHealthMapDbContext>
    {
        public MyHealthMapDbContext CreateDbContext(string[] args)
        {
            //Get the connection string from appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MyHealthMapDbContext>();
            var conn = config.GetConnectionString("MyHealthMapDbConnectionString");
            optionsBuilder.UseSqlServer(conn);

            return new MyHealthMapDbContext(optionsBuilder.Options);
        }
    }
}
