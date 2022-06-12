using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace BasicsForExperts.Web.Extensions;
public static partial class WebApplicationExtensions
{
    public static async Task<WebApplication> AddApisAsync(this WebApplication app)
    {
        //https://github.com/csharpfritz/InstantAPIs
        using (var scope = app.Services.CreateScope())
        {
            var waffleCreationService = scope.ServiceProvider.GetRequiredService<IWaffleCreationService>();
            var response = await waffleCreationService.StartWaffleCreation();

            app.MapGet("/GetWaffleToppings", () => new { toppings = response.toppings, bases = response.bases });

            app.MapGet("/users", async (WaffleDbContext context) =>
            {
                context.Database.EnsureCreated();
                return await context.Users.Include(u => u.Orders).ToListAsync();
            });
        }
        return app;
    }
}

