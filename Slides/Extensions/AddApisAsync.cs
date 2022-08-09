using BasicsForExperts.Web.Data;
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

        app.MapGet("/users", async (WaffleDbContext context) =>
        {
            context.Database.EnsureCreated();
            return await context.Users.Include(u => u.Orders).ToListAsync();
        });
        return app;
    }
}

