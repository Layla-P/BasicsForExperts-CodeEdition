using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;

namespace BasicsForExperts.Web.Services
{
    public class AnotherWaffleCreationService : IWaffleCreationService
    {
        public Task<Order> CreateWaffle(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<(List<OrderTopping> toppings, List<string> bases)> StartWaffleCreation()
        {
            return null;
        }
    }
}
