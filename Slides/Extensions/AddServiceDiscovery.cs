using Steeltoe.Discovery.Client;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDiscovery(this IServiceCollection services)
        {
            services.AddDiscoveryClient();
            return services;
        }
    }
}
