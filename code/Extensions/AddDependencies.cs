using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            
            return services;
        }

        private static IServiceCollection AddMarketingDependencies(this IServiceCollection services)
        {
            var mpd = new MarketingPrivateDependency();
            // adding dependencies in this way allows the Ioc container to manage lifecycle and call dispose
            // see great blog series by Steve Collins - http://stevetalkscode.co.uk/
            services.AddSingleton(ctx => new MarketingEndpoints(mpd));
            return services;
        }
    }
}
