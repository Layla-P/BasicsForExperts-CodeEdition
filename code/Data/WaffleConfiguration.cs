using BasicsForExperts.Web.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicsForExperts.Web.Data
{
    public class WaffleConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Waffle>(b =>
            {
                b.HasKey(c => c.Id);
            });

        }
    }
}
