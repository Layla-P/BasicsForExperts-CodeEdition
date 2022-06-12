using BasicsForExperts.Web.DTOs;
using BasicsForExperts.Web.Entities;
using Microsoft.EntityFrameworkCore;


namespace BasicsForExperts.Web.Data
{
    public class DbInitializer
    {

        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;

        }

        public void Seed()
        {

            modelBuilder.Entity<User>().HasData(
                   new User()
                   {
                       Id = 1,
                       Name = "Jakub",                       
                       Email = "Test@test.com",
                       PhoneNumber = "01234564565"

                   },
                   new User()
                   {
                       Id = 2,
                       Name = "Layla",                      
                       Email = "Test2@test.com",
                       PhoneNumber = "012345256465"
                   }
            );
            modelBuilder.Entity<Order>().HasData(
                   new Order() { 
                       Id = 1, 
                       UserId = 1, 
                       Price = 15M },
                   new Order() { 
                       Id = 2, 
                       UserId = 2, 
                       Price = 17M }
                        );

            modelBuilder.Entity<Waffle>().HasData(
               waffleOne,
               waffleTwo,
               waffleThree
                );
        }

        private static Waffle waffleOne = new()
        { Id = 1, OrderId = 1, Base = "round"};
        private static Waffle waffleTwo = new()
        { Id = 2, OrderId = 2, Base = "square"};
        private static Waffle waffleThree = new()
        { Id = 3, OrderId = 2, Base = "square" };

        private static List<OrderTopping> ingredientsListOne =
             new()
             {
                 new OrderTopping { Id = 1, WaffleId = 1, Name = "Vanilla icecream", WaffleType = WaffleTypeEnum.Standard, Price = 2M },
                 new OrderTopping { Id = 5, WaffleId = 1, Name = "Chocolate sauce", WaffleType = WaffleTypeEnum.Standard, Price = 1M },
                 new OrderTopping { Id = 7, WaffleId = 1, Name = "Fresh bananas", WaffleType = WaffleTypeEnum.LowFat, Price = 2.5M }
             };
        private static List<OrderTopping> ingredientsListTwo =
            new()
            {
                new OrderTopping { Id = 11, WaffleId = 2, Name = "Cheddar cheese", WaffleType = WaffleTypeEnum.Savoury, Price = 3M },
                new OrderTopping { Id = 13, WaffleId = 2, Name = "Bacon", WaffleType = WaffleTypeEnum.Savoury, Price = 4M },
            };
        private static List<OrderTopping> ingredientsListThree =
             new()
             {
                 new OrderTopping { Id = 11, WaffleId = 3, Name = "Cheddar cheese", WaffleType = WaffleTypeEnum.Savoury, Price = 3M },
                 new OrderTopping { Id = 13, WaffleId = 3, Name = "Bacon", WaffleType = WaffleTypeEnum.Savoury, Price = 4M },
             };

    }
}
