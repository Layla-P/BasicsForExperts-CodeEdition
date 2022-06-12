using BasicsForExperts.Web.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicsForExperts.Web.Entities
{
    public class Order
    {
        public int Id { get; set; }
        //foreign key
        public int UserId { get; set; }
        //public virtual User User { get; set; }
        public virtual List<Waffle> Waffles { get; set; }
        public decimal Price { get; set; }
    }
}
