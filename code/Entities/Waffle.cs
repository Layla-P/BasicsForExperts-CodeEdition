using System.ComponentModel.DataAnnotations.Schema;

namespace BasicsForExperts.Web.Entities
{
    public class Waffle
    {
        // primary key
        public int Id { get; set; }
        // foreign key        
        public int OrderId { get; set; }
        public string Base { get; set; }
        public virtual List<OrderTopping> OrderToppings { get; set; }
    }
}
