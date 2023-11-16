using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
       // services.AddSingleton<IWaffleCreationService, WaffleCreationService>();
        services.AddKeyedSingleton<IWaffleCreationService, WaffleCreationService>("waffleCreationService");
        services.AddKeyedSingleton<IWaffleCreationService, AnotherWaffleCreationService>("anotherWaffleCreationService");

        return services;
    }
}