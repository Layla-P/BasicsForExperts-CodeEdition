using BasicsForExperts.Web.Services;
using System.Net;
using Polly;
using Polly.Extensions.Http;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        //https://github.com/App-vNext/Polly
        public static IServiceCollection AddClientsAndPolicies(this IServiceCollection services)
        {
            // Instead of just using services.AddHttpClient()
            services.AddHttpClient();

            // Add a named client

            // We can also create a strongly typed HttpClient, such as this one
            services.AddHttpClient<WaffleIngredientService>()
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy())
                .AddPolicyHandler(GetFallbackPolicy());

          

            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 5,
                durationOfBreak: TimeSpan.FromSeconds(30));
        }

        static IAsyncPolicy<HttpResponseMessage> GetFallbackPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .FallbackAsync(FallbackAction, OnFallbackAsync);
        }



        //https://www.twilio.com/blog/polly-fallbacks-dot-net-service-communication
        private static Task OnFallbackAsync(DelegateResult<HttpResponseMessage> response, Context context)
        {
            Console.WriteLine("About to call the fallback action. This is a good place to do some logging");
            return Task.CompletedTask;
        }

        private static Task<HttpResponseMessage> FallbackAction(DelegateResult<HttpResponseMessage> responseToFailedRequest, Context context, CancellationToken cancellationToken)
        {
            Console.WriteLine("Fallback action is executing");

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(responseToFailedRequest.Result.StatusCode)
            {
                Content = new StringContent($"The fallback executed, the original error was {responseToFailedRequest.Result.ReasonPhrase}")
            };
            return Task.FromResult(httpResponseMessage);
        }
    }
}
