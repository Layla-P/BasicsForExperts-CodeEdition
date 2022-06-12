using Microsoft.EntityFrameworkCore;
using BasicsForExperts.Web.Entities;

namespace BasicsForExperts.Web.Data
{
    // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    public class WaffleDbContext : DbContext
    {
        public WaffleDbContext(DbContextOptions<WaffleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            OrderConfiguration.Configure(modelBuilder);
            UserConfiguration.Configure(modelBuilder);
            WaffleConfiguration.Configure(modelBuilder);
            OrderToppingsConfiguration.Configure(modelBuilder);  
            
            new DbInitializer(modelBuilder).Seed();            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Waffle> Waffles { get; set; }

    }



}
