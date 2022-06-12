
namespace BasicsForExperts.Web.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
