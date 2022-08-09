using Microsoft.Extensions.DependencyInjection;
using Polly.Extensions.Http;
using Polly;
using System.Net;
using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Services;
using Polly.Timeout;
using Moq;

namespace BasicsForExperts.Tests;

[TestFixture]
public class CircuitBreakerTests
{

    private bool _isRetryCalled;
    //private Mock<WaffleIngredientService> _sut;



    [Test]
    public async Task Given_A_Retry_Policy_Has_Been_Registered_For_A_HttpClient_When_The_HttpRequest_Fails_Then_The_Request_Is_Retried()
    {
        IServiceCollection services = new ServiceCollection();
        _isRetryCalled = false;

        services.AddHttpClient<WaffleIngredientService>()
            .AddPolicyHandler(GetRetryPolicy());
            //.AddHttpMessageHandler(() => new StubDelegatingHandler());

        WaffleIngredientService sut =
            services
                .BuildServiceProvider()
                .GetRequiredService<WaffleIngredientService>();

        // Act
        var result = await sut.GetIngredients();

        // Assert
        Assert.True(_isRetryCalled);
        //Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    }

    
    //[Test]
    //public void Should_Return_999_When_TimeoutRejectedException_Thrown()
    //{
    //    //Arrange 
    //    var httpMessage = new HttpResponseMessage
    //    {
    //        StatusCode = HttpStatusCode.BadRequest,
    //        Content = new StringContent("some error")
    //    };
    //    Mock<WaffleIngredientService> mockedErrorProneCode = new Mock<WaffleIngredientService>();
    //    mockedErrorProneCode.Setup(e => e.GetIngredients()).ReturnsAsync(httpMessage);

    //    Mock<ISyncPolicy> mockedPolicy = new Mock<ISyncPolicy>();
    //    mockedPolicy.Setup(p => p.Execute(It.IsAny<Func<int>>())).Throws(new TimeoutRejectedException("Mocked Timeout Exception"));

    //    IBusinessLogic businessLogic = new BusinessLogic(mockedPolicy.Object, mockedErrorProneCode.Object);

    //    //Act
    //    // if there is a TimeoutRejectedException in this CallSomeSlowBadCode it will return 999
    //    int num = businessLogic.CallSomeSlowBadCode();

    //    //Assert
    //    Assert.Equal(999, num);
    //}






    public IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions.HandleTransientHttpError()
            .WaitAndRetryAsync(
                2,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetryAsync: OnRetryAsync);
    }

    private async Task OnRetryAsync(DelegateResult<HttpResponseMessage> outcome, TimeSpan timespan, int retryCount, Context context)
    {
        //Log result
        _isRetryCalled = true;
    }
}

//public class StubDelegatingHandler : DelegatingHandler
//{
//    private int _count = 0;

//    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
//        CancellationToken cancellationToken)
//    {
//        if (_count == 0)
//        {
//            _count++;
//            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
//        }

//        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
//    }
//}

