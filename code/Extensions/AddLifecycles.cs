using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions;

public static partial class  IServiceCollectionExtensions
{
    public static IServiceCollection AddLifecycles(this IServiceCollection services)
    {
        // singleton
        //services.AddSingleton<Lifecycles>();
        // scoped
        //services.AddScoped<Lifecycles>();
        // transient
        services.AddTransient<Lifecycles>();
        return services;
    }
}