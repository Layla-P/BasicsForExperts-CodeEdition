using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicsForExperts.Web.Controllers;

[ApiController]
[Route("api/layla")]
public class WaffleOrderController : ControllerBase
{
    //private readonly WaffleCreationService _waffleCreationService;
    private readonly IWaffleCreationService _waffleCreationService;

    public WaffleOrderController(IWaffleCreationService waffleCreationService)
    {
        _waffleCreationService = waffleCreationService ?? throw new ArgumentNullException(nameof(waffleCreationService)); ;

    }

    //public WaffleOrderController(WaffleCreationService waffleCreationService)
    //{
    //    _waffleCreationService = waffleCreationService ?? throw new ArgumentNullException(nameof(waffleCreationService); ;

    //}

    //public WaffleOrderController(IEnumerable<IWaffleCreationService> waffleCreationServiceCollection)
    //{
    //    _waffleCreationService = waffleCreationServiceCollection
    //        .First(x => x.GetType() == typeof(WaffleCreationService)) ?? throw new ArgumentNullException("WaffleCreationService"); ;

    //}

    [HttpGet]
    //[Route("Options")]
    public async Task<JsonResult> Get()
    {
        var response = await _waffleCreationService.StartWaffleCreation();

        return new JsonResult(new { toppings = response.toppings, bases = response.bases });
    }

    [HttpPost]
    //[Route("Options")]
    public void Post([FromBody] WaffleOrder waffleOrder)
    {
        var toppings = waffleOrder.Toppings;
        //do stuff with the waffle order
    }
}
