using BasicsForExperts.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDbContext<WaffleDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultSql")));

            return services;
        }
    }
}
