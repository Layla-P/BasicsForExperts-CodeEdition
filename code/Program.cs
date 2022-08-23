using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Services;
using System.Text.Json;

// most of the general using statements are now implicit.
// Use a global usings file for anything you wish to be globally scoped
var builder = WebApplication.CreateBuilder(args);


builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args)
    .Build();
// we have everything that we need, and nothing that we don't

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding dependencies
// Add an HttpClient that's available to any class 
// requesting HttpClient,this will be managed by the HttpClientFactory


// Add any services to the IoC container
// Different lifecycles and implementations
// Disposing of things correctly


//builder.Services.AddDatabases(builder.Configuration);


// If there are a lot of dependencies, the program file will become unmanageable, so we can abstract it out into an extension
builder.Services.AddDependencies();
//builder.Services.AddCustomSerializers();

// Add typed HttpClients and configure policies, circuit breaks and failovers
builder.Services.AddClientsAndPolicies();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();



// Minimal APIs architecture allows us to add lightweight 
// api endpoints directly to the WebApplication without the 
// need for a controller

app.MapGet("/GetWaffleToppings", async (IWaffleCreationService wcs) =>
{
    var response = await wcs.StartWaffleCreation();
    var stringContent = await response.Content.ReadAsStringAsync();
    var content = JsonSerializer
        .Deserialize<IngredientsDto>(stringContent);

    return new { toppings = content.Toppings, bases = content.Bases };

});

// If we have a lot of apis, the program file could get messy, 
// so just like everything else, we can pull it out into an extension method
//await app.AddApisAsync();

// The following extension method shows how to access 
// Eureka to get registered apps.


app.Run();

public partial class Program { }