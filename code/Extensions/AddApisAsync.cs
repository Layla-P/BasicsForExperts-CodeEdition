﻿using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicsForExperts.Web.Extensions;
public static partial class WebApplicationExtensions
{
    public static async Task<WebApplication> AddApisAsync(this WebApplication app)
    {
        //https://github.com/csharpfritz/InstantAPIs


        app.MapGet("/GetWaffleToppings", async (IWaffleCreationService wcs) => 
        {
            var response = await wcs.StartWaffleCreation();
           return new { toppings = response.toppings, bases = response.bases 
            };
        });

        return app;
    }
}

