using BasicsForExperts.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BasicsForExperts.Web.DTOs
{
    public record struct WaffleDto(int Id, string Base, List<OrderTopping> Toppings);

    public class WaffleViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }  
        public Decimal Price { get; set; }
    }
}
