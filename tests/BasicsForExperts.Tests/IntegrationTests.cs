

using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Polly.Extensions.Http;
using Polly;
using Steeltoe.Extensions.Configuration;

namespace BasicsForExperts.Tests;
// https://dotnetthoughts.net/dotnet-minimal-api-integration-testing/
// https://codereview.stackexchange.com/questions/227596/simple-httpclient-usage-for-integration-tests-in-net-core
// https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0


public class BasicsForExpertsWebApplication : WebApplicationFactory<Program>
{
    private bool _isRetryCalled { get; set; } = false;
    protected override IHost CreateHost(IHostBuilder builder)
    {
        
    builder.ConfigureServices(services =>
        {
            services.AddHttpClient<WaffleIngredientService>()
                .AddPolicyHandler(GetRetryPolicy());

        });

        return base.CreateHost(builder);
    }

    IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(
                6,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetryAsync: OnRetryAsync);
    }

    async Task OnRetryAsync(DelegateResult<HttpResponseMessage> outcome, TimeSpan timespan, int retryCount, Context context)
    {
        //Log result
       _isRetryCalled = true;
    }
    public bool GetRetry()
    {
        return _isRetryCalled;
    }
}

[TestFixture]
public class CircuitBreakerTest
{
    

    [Test]
    public async Task CircuitBreaker_Is_Called()
    {
        await using var application = new BasicsForExpertsWebApplication();
      

        using (var scope = application.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var ingredientsService = provider.GetRequiredService<WaffleIngredientService>();

            // Act
            var result = await ingredientsService.GetIngredients();
            var istried = application.GetRetry();
            // Assert
            Assert.True(istried);

        }

       
    }
} 