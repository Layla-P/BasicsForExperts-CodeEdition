using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddWaffleDependencies(this IServiceCollection services)
    {
        services.AddWaffleHttpClients();
        return services;
    }
    
    //httpclients
    //private
}