using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;

namespace BasicsForExperts.Web.Services
{
    public interface IWaffleCreationService
    {
        Task<(List<OrderTopping> toppings, List<string> bases)> StartWaffleCreation();
        Task<Order> CreateWaffle(Order order);

    }
}
