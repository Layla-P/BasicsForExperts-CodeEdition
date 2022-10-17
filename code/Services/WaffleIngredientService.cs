using BasicsForExperts.Web.DTOs;
using System.Text.Json;

namespace BasicsForExperts.Web.Services;

public class WaffleIngredientService
{
    private readonly HttpClient _httpClient;
    
    public WaffleIngredientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ToppingDto>> GetIngredients()
    { 
        
        var response = await _httpClient.GetAsync("http://localhost:7071/api/GetIngredients");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(">>>>>>>>>>>>> response is A-okay!");
            string responseBody = await response.Content.ReadAsStringAsync();
            var toppings = JsonSerializer.Deserialize<List<ToppingDto>>(responseBody);
            return toppings;
        }
        //handle error here
        return new List<ToppingDto>();
        
    }
}

