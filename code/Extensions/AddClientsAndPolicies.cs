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
       
        services.AddHttpClient();

        // Instead of just using services.AddHttpClient()

        // named HTTP client

        
        // Polly is one of the best options for HTTP resiliency
            IAsyncPolicy<HttpResponseMessage> wrapOfRetryAndFallback =
            Policy.WrapAsync(FallbackPolicy, GetRetryPolicy, CircuitBreakerPolicy);
        
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

    static IAsyncPolicy<HttpResponseMessage> FallbackPolicy =
        Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .FallbackAsync(FallbackAction, OnFallbackAsync);

    static Task OnFallbackAsync(DelegateResult<HttpResponseMessage> response, Context context)
    {
        Console.WriteLine(">>>>>>>>>>>>> About to call the fallback action. This is a good place to do some logging");
        return Task.CompletedTask;
    }

    static Task<HttpResponseMessage> FallbackAction(DelegateResult<HttpResponseMessage> responseToFailedRequest, Context context, CancellationToken cancellationToken)
    {
        Console.WriteLine(">>>>>>>>>>>>> Fallback action is executing");

        HttpResponseMessage httpResponseMessage = new HttpResponseMessage(responseToFailedRequest.Result.StatusCode)
        {
            Content = new StringContent($"The fallback executed, the original error was {responseToFailedRequest.Result.ReasonPhrase}")
        };
        return Task.FromResult(httpResponseMessage);
    }

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
