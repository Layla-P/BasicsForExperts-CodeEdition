using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;

namespace BasicsForExperts.Web.Services
{
    public interface IWaffleCreationService
    {
        Task<HttpResponseMessage> StartWaffleCreation();
        Task<Order> CreateWaffle(Order order);

    }
}
