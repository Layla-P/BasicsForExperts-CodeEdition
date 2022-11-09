using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {

        // extend IServiceCollection
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IWaffleCreationService, WaffleCreationService>();
            //services.AddMarketingDependencies();
            
            return services;
        }
        
        
        private static IServiceCollection AddMarketingDependencies(this IServiceCollection services)
        {
            var mpd = new MarketingPrivateDependency();
            //var md = new MarketingEndpoints(mpd);
            // adding dependencies in this way allows the IoC container to manage lifecycle and call dispose
            // see great blog series by Steve Collins - http://stevetalkscode.co.uk/
            services.AddSingleton(ctx => new MarketingEndpoints(mpd));
            
            return services;
        }

        public static IServiceCollection AddLifecycles(this IServiceCollection services)
        {
            // singleton
            services.AddSingleton<Lifecycles>();
            // scoped
            //services.AddScoped<Lifecycles>();
            // transient
            //services.AddTransient<Lifecycles>();
            return services;
        }
    }
}



//services.AddSingleton(ctx => new MarketingEndpoints(mpd));