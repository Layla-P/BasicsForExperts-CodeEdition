using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;
using BasicsForExperts.Web.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BasicsForExperts.Web.Extensions;
public static class WebApplicationExtensions
{
    public static async Task<WebApplication> AddApisAsync(this WebApplication app)
    {
        //https://github.com/csharpfritz/InstantAPIs


        app.MapGet("/GetWaffleToppings", async (IWaffleCreationService wcs) => 
        {
            var response = await wcs.StartWaffleCreation();
            var stringContent = await response.Content.ReadAsStringAsync();
            var content = JsonSerializer
                .Deserialize<IngredientsDto>(stringContent);

           return new { toppings = content.Toppings, bases = content.Bases};

        });

        app.MapPost("/GetWaffleToppings", (IWaffleCreationService wcs, [FromBody]Order order) =>
        {
            var o = order;
        });

        return app;
    }
}

