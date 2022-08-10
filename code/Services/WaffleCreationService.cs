using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;
using BasicsForExperts.Web.Extensions;
using Polly.CircuitBreaker;
using System.Text.Json;

namespace BasicsForExperts.Web.Services
{
    public class WaffleCreationService : IWaffleCreationService
    {
        private readonly WaffleIngredientService _waffleIngredientService;
        private readonly Order _defaultOrder;

        public WaffleCreationService(WaffleIngredientService waffleIngredientService)
        {
            _waffleIngredientService =

                waffleIngredientService
                ?? throw new ArgumentNullException(nameof(waffleIngredientService));

            _defaultOrder = new Order
            {
                Id = 0,
                UserId = 0
            };
        }

        public async Task<HttpResponseMessage> StartWaffleCreation()
        {
            List<ToppingDto> ingedients = new();
            HttpResponseMessage response = new();

            if (IServiceCollectionExtensions.CircuitBreakerPolicy.CircuitState == CircuitState.Open)
            {
                response.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
                response.Content = new StringContent("The service is currently unavailable, try again in a few moments");
                return response;
            }
            else
            {
                ingedients = await _waffleIngredientService.GetIngredients();
            }

            var toppings = ingedients
                .Select(i => new OrderTopping { Id = i.Id, Name = i.Name, WaffleType = i.Type }).ToList();

            List<string> bases = new() { "round", "square", "heart" };

            var content = JsonSerializer.Serialize(new IngredientsDto(toppings, bases));

            response.Content = new StringContent(content);
            //named tuples
            return response;
        }

        public Task<Order> CreateWaffle(Order order)
        {

            if (order == null)
            {
                order = _defaultOrder;
            }

            // do some waffling
            throw new NotImplementedException();
        }

    }
}
