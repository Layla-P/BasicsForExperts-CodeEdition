using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions;

public static partial class IServiceCollectionExtensions
{
    public static IServiceCollection AddMarketingDependencies(this IServiceCollection services)
    {
        // adding dependencies in this way allows the IoC container to manage lifecycle and call dispose
        // see great blog series by Steve Collins - http://stevetalkscode.co.uk
        MarketingPrivateDependency pmd = new();
        MarketingEndpoints me = new(pmd);
        services.AddSingleton(me);
        return services;
    }

  
}