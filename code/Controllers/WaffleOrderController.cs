using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using Polly.CircuitBreaker;
using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Entities;
using System.Text.Json;

namespace BasicsForExperts.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WaffleOrderController : ControllerBase
{
    //private readonly WaffleCreationService _waffleCreationService;
    private readonly IWaffleCreationService _waffleCreationService;

    public WaffleOrderController(IHttpClientFactory fac)
    {
        var client = fac.CreateClient("vslive");
    }
    
    // public WaffleOrderController(IWaffleCreationService waffleCreationService)
    // {
    //     _waffleCreationService = waffleCreationService ?? throw new ArgumentNullException(nameof(waffleCreationService)); ;
    //     
    // }

    //public WaffleOrderController(WaffleCreationService waffleCreationService)
    //{
    //    _waffleCreationService = waffleCreationService ?? throw new ArgumentNullException(nameof(waffleCreationService); ;

    //}

    public WaffleOrderController(IEnumerable<IWaffleCreationService> waffleCreationServiceCollection)
    {
        _waffleCreationService = waffleCreationServiceCollection
            .First(x => x.GetType() == typeof(WaffleCreationService)) ?? throw new ArgumentNullException("WaffleCreationService"); ;

    }




    [HttpGet]
    //[Route("Options")]
    public async Task<JsonResult> Get()
    {
        var response = await _waffleCreationService.StartWaffleCreation();
        var stringContent = await response.Content.ReadAsStringAsync();
        var content = JsonSerializer
            .Deserialize<(List<OrderTopping> toppings, List<string> bases)>(stringContent);
        return new JsonResult(new { toppings = content.toppings, bases = content.bases });
    }

    [HttpPost]
    //[Route("Options")]
    public void Post([FromBody] WaffleOrder waffleOrder)
    {
        var toppings = waffleOrder.Toppings;
        //do stuff with the waffle order
    }
}
