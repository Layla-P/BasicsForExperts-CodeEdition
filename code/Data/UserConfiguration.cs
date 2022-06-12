using BasicsForExperts.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicsForExperts.Web.Data
{
    public class UserConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(128);
                b.Property(c => c.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(64);
                b.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(128);

            });
        }
    }
}
