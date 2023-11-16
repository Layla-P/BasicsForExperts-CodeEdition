using BasicsForExperts.Web.Services;
using System.Net;
using Polly;
using Polly.CircuitBreaker;

namespace BasicsForExperts.Web.Extensions;

public static partial class IServiceCollectionExtensions
{

    //https://github.com/App-vNext/Polly
    public static IServiceCollection AddClientsAndPolicies(this IServiceCollection services)
    {
        // Instead of just using services.AddHttpClient()

        // named HTTP client

        services.AddHttpClient();
        //services.AddHttpClient<WaffleIngredientService>();
        services.AddHttpClient("dotnet conf", client =>
        {
            client.BaseAddress = new("https://dotnet.conf");
        });


        // Polly is one of the best options for HTTP resiliency

        IAsyncPolicy<HttpResponseMessage> wrapOfRetryAndFallback =
            Policy.WrapAsync(GetRetryPolicy, CircuitBreakerPolicy);

        // Strongly typed HTTP client

        services.AddHttpClient<WaffleIngredientService>()
            .AddPolicyHandler(wrapOfRetryAndFallback);


        return services;
    }



    public static readonly AsyncCircuitBreakerPolicy<HttpResponseMessage> CircuitBreakerPolicy =
        Policy
            .HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.InternalServerError)
            .CircuitBreakerAsync(3, TimeSpan.FromMinutes(1), OnBreak, OnReset, OnHalfOpen);


    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy =
        Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    

    static void OnHalfOpen()
    {
        Console.WriteLine(">>>>>>>>>>>>> Circuit in test mode, one request will be allowed.");
    }

    static void OnReset()
    {
        Console.WriteLine(">>>>>>>>>>>>> Circuit closed, requests flow normally.");
    }

    static void OnBreak(DelegateResult<HttpResponseMessage> result, TimeSpan ts)
    {
        Console.WriteLine(">>>>>>>>>>>>> Circuit cut, requests will not flow.");
    }
}


