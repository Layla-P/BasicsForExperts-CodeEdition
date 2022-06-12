using BasicsForExperts.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicsForExperts.Web.Data
{
    public class OrderConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.UserId)
                    .IsRequired();

                b.Property(c => c.Price)
                   .HasColumnType("decimal");
            });
        }
    }
}
