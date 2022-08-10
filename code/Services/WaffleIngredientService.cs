using BasicsForExperts.Web.DTOs;
using System.Text.Json;

namespace BasicsForExperts.Web.Services
{
    public class WaffleIngredientService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://gist.githubusercontent.com/Layla-P/022fafeec13bf17cea3ac0c7bd515e94/raw/bf009d953a9df8a0f7932885b374eff51500c04f/waffleIngredients.json";
        public WaffleIngredientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ToppingDto>> GetIngredients()
        { 
            
            var response = await _httpClient.GetAsync("http://localhost:7198/api/GetIngredients");

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
}
