using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc;
using BasicsForExperts.Web.Entities;
using System.Text.Json;

namespace BasicsForExperts.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WaffleOrderController: ControllerBase
{
    private readonly IWaffleCreationService _waffleCreationService;
    private readonly IWaffleCreationService _anotherWaffleCreationService;

    private readonly HttpClient _httpClient;

    // New feature! Primary Constructors - below is the old way, which you can still use.
    public WaffleOrderController(IHttpClientFactory fac)
    {
        _httpClient = fac.CreateClient(".NET Conf");
    }

    
    public WaffleOrderController(IEnumerable<IWaffleCreationService> waffleCreationServiceCollection)
    {
        _waffleCreationService = waffleCreationServiceCollection
            .First(x => x.GetType() == typeof(WaffleCreationService));

        _anotherWaffleCreationService = waffleCreationServiceCollection
           .First(x => x.GetType() == typeof(AnotherWaffleCreationService));
    }


    // New feature! Keyed DI services in use - N.B. this is very contrived and not a good use of this feature.
    public WaffleOrderController(
        [FromKeyedServices("waffleService")] IWaffleCreationService waffleCreationService, 
        [FromKeyedServices("anotherWaffleService")] IWaffleCreationService anotherWaffleCreationService)
    {
        _waffleCreationService = waffleCreationService;
        _anotherWaffleCreationService = anotherWaffleCreationService;
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
