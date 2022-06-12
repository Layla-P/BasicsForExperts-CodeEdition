using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            
            services.AddSingleton<IWaffleCreationService, WaffleCreationService>();
            //services.AddSingleton<IWaffleCreationService, AnotherWaffleCreationService>();

            services.AddMarketingDependencies();
            return services;
        }

        private static IServiceCollection AddMarketingDependencies(this IServiceCollection services)
        {
            var mpd = new MarketingPrivateDependency();

            services.AddSingleton(ctx => new MarketingEndpoints(mpd));
            return services;
        }
    }
}
