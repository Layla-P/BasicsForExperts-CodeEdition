﻿using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions
{
    public static class DependencyServiceCollectionExtensions
    {

        // extend IServiceCollection

        
        
        private static IServiceCollection AddMarketingDependencies(this IServiceCollection services)
        {
            var mpd = new MarketingPrivateDependency();
            var md = new MarketingEndpoints(mpd);
            // adding dependencies in this way allows the IoC container to manage lifecycle and call dispose
            // see great blog series by Steve Collins - http://stevetalkscode.co.uk/
           
            return services;
        }
    }
}



//services.AddSingleton(ctx => new MarketingEndpoints(mpd));