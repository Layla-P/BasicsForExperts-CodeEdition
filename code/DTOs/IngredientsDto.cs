using BasicsForExperts.Web.Entities;

namespace BasicsForExperts.Web.DTOs
{
    public class IngredientsDto
    {
        public IngredientsDto() { }

        public IngredientsDto(List<OrderTopping> toppings, List<string> bases) {
            Toppings = toppings;
            Bases = bases;
        }
        public List<OrderTopping> Toppings { get; set; }
        public List<string> Bases { get; set; }
    }
}
