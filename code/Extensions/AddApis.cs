using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;
using BasicsForExperts.Web.Services;
using System.Text.Json;

namespace BasicsForExperts.Web.Extensions;

public static class WebApplicationExtensions
{
   public static WebApplication AddApis(this WebApplication app)
    {
        app.MapGet("/GetWaffleToppings", async ([FromKeyedServices("waffleCreationService")] IWaffleCreationService wcs) =>
        {
            var response = await wcs.StartWaffleCreation();
            var stringContent = await response.Content.ReadAsStringAsync();
            var content = JsonSerializer
                .Deserialize<IngredientsDto>(stringContent);

            return new { toppings = content.Toppings, bases = content.Bases };

        });


        app.MapPost("/GetWaffleToppings", async ([FromKeyedServices("waffleCreationService")] IWaffleCreationService wcs, Order order) =>
        {
            // do something here!

        });
        return app;
    }
}