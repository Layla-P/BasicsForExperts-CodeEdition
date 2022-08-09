using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;

namespace BasicsForExperts.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WaffleOrderController : ControllerBase
{
    //private readonly WaffleCreationService _waffleCreationService;
    private readonly IWaffleCreationService _waffleCreationService;
    private readonly WaffleIngredientService _ingredientService;

    public WaffleOrderController(IWaffleCreationService waffleCreationService, WaffleIngredientService ingredientService)
    {
        _waffleCreationService = waffleCreationService ?? throw new ArgumentNullException(nameof(waffleCreationService)); ;
        _ingredientService =   ingredientService ?? throw new ArgumentNullException(nameof(ingredientService));
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

    //[HttpGet("/ingredients")]
    //public async Task<ActionResult> GetIngredients()
    //{
       
    //    var httpResponseMessage = await _ingredientService.GetIngredients();

       
    //    if (httpResponseMessage.IsSuccessStatusCode)
    //    {
    //        var ingredients = await httpResponseMessage.Content.ReadAsStringAsync();
    //        return Ok(ingredients);
    //    }


    //    return StatusCode((int)httpResponseMessage.StatusCode, httpResponseMessage.Content.ReadAsStringAsync());
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
