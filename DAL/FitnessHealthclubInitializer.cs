using FitnessClubManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.DAL
{
    public class FitnessHealthclubInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FitnessClubContext>
    {
        protected override void Seed(FitnessClubContext context)
        {
           
            var clubList = new List<Club>

            {
                new Club() {clubId=1,clubStAddress="First Gulf",clubCity="Brampton ",clubProvince="ON",clubPostal="LS69V6"},
                new Club() {clubId=2,clubStAddress="Humber",clubCity="Etobicoke ",clubProvince="ON",clubPostal="LS85B5"},
                new Club() {clubId=3,clubStAddress="Silverstone",clubCity="Toronto ",clubProvince="ON",clubPostal="M9V1B7"},
                new Club() {clubId=4,clubStAddress="Square One",clubCity="Mississauga ",clubProvince="ON",clubPostal="M9V1B9"},


            };
            clubList.ForEach(s => context.clubs.Add(s));
            context.SaveChanges();

            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------

            var cityList = new List<City>
                {
                new City() {Title = "Brampton", Lat = 43.731500, Lng = -79.7624},
                new City() {Title = "Mississauga", Lat = 43.5890, Lng = -79.6441 },
                new City() {Title = "Etobicoke", Lat = 43.6205, Lng = -79.5132 },        
                new City() { Title = "Toronto", Lat = 43.6532, Lng = -79.3832},          
            };
            cityList.ForEach(s => context.Cities.Add(s));
            context.SaveChanges();

            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------


            var eventList = new List<Event>
                {
                new Event() { EventId =1,Subject="Yoga session",Description="Build strength, restore flexibility and de-stress body and mind with classes suited to yogis of all levels. Enjoy our yoga classes in club, on demand or via livestream — they are all included with membership",Start=DateTime.Parse("2021-04-25 12:00:00"),End=DateTime.Parse("2021-04-25 13:30:00"),ThemeColor="Green",IsFullDay=false},
                new Event() { EventId =2,Subject="Zumba",Description="Zumba is a fitness program that combines Latin and international music with dance moves. Zumba routines incorporate interval training — alternating fast and slow rhythms — to help improve cardiovascular fitness.",Start=DateTime.Parse("2021-04-26 12:00:00"),End=DateTime.Parse("2021-04-26 13:30:00"),ThemeColor="Blue",IsFullDay=false },
                new Event() { EventId =3,Subject="Bhangra",Description="Not just fun, Bhangra also has many health benefits and the biggest of them all is weight loss. Yes, this dance form can help you lose weight in an extremely fun way. Masala Bhangra is believed to be a big calorie burner.",Start=DateTime.Parse("2021-04-27 12:00:00"),End=DateTime.Parse("2021-04-27 13:30:00"),ThemeColor="Green",IsFullDay=false},
                new Event() { EventId =4,Subject="HIIT",Description="HIIT (high-intensity interval training) is a form of exercise that has been proven to boost metabolism and build strength, packing in the same benefits of lower and moderate-intensity aerobic workouts in a much shorter time.",Start=DateTime.Parse("2021-04-26 12:00:00"),End=DateTime.Parse("2021-04-26 13:30:00"),ThemeColor="Blue",IsFullDay=false }
            };
            eventList.ForEach(s => context.Events.Add(s));
            context.SaveChanges();

            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------


            var membershipPlans = new List<MembershipPackages>
                {
                new MembershipPackages() {packageId = 1, name ="Gold", description = "Everthing", price=50},
                 new MembershipPackages() {packageId = 2, name ="Silver", description = "Half", price=40},
                  new MembershipPackages() {packageId = 3, name ="Platinum", description = "Half", price=60},

            };
            membershipPlans.ForEach(s => context.membershipPackages.Add(s));
            context.SaveChanges();



            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------


            var customer = new List<Customer>
                        {
                   new Customer() {customerId=1,customerName="Sarb", password="Sarb@1993", customerphone="9876543210",customerEmail="Sarbjot@gmail.com" , dateofbirth=DateTime.Parse("1993-01-02"),customerAddress="8 Jeffery st"},
                   new Customer() {customerId=2,customerName="Karan", password="Karan@1993", customerphone="9873343210",customerEmail="Karan@gmail.com" , dateofbirth=DateTime.Parse("1994-01-02"),customerAddress="8 Jeffery st"},
                   new Customer() {customerId=3,customerName="Davi", password="Davi@1993", customerphone="9876599210",customerEmail="Davi@gmail.com" , dateofbirth=DateTime.Parse("1996-01-02"),customerAddress="8 Jeffery st"},
                   new Customer() {customerId=4,customerName="Himanshu", password="Himanshu@1993", customerphone="9899543210",customerEmail="Himanshu@gmail.com" , dateofbirth=DateTime.Parse("2020-01-02"),customerAddress="8 Jeffery st"},
                   new Customer() {customerId=5,customerName="Sumeet", password="Sumeet@1993", customerphone="9876548810",customerEmail="Sumeet@gmail.com" , dateofbirth=DateTime.Parse("2020-01-02"),customerAddress="8 Jeffery st"} ,    
                    };
                    customer.ForEach(s => context.customers.Add(s));
                    context.SaveChanges();

            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------


            var enrollments = new List<Enrollment>
                        {
                        new Enrollment() {enrolementId=1,packageId=1, numberofmonths=1, clubId=1,customerId=1},
                         new Enrollment() {enrolementId=2,packageId=2, numberofmonths=1, clubId=2,customerId=2},
                          new Enrollment() {enrolementId=3,packageId=3, numberofmonths=1, clubId=3,customerId=3},
                           new Enrollment() {enrolementId=4,packageId=1, numberofmonths=1, clubId=4,customerId=4},
                            new Enrollment() {enrolementId=5,packageId=2, numberofmonths=1, clubId=1,customerId=5},
                            
                    };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            //---------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------

            var payment = new List<Payment>
                        {
                        new Payment() {transactionId=1,amount=50, cardNumber="9874000012346543", expiryDate=DateTime.Parse("2025-01-02"),CVV="356",customerId=1,enrolementId=1},
                         new Payment() {transactionId=2,amount=50, cardNumber="9874000012347543", expiryDate=DateTime.Parse("2025-01-02"),CVV="376",customerId=2,enrolementId=2},
                          new Payment() {transactionId=3,amount=50, cardNumber="9874000012348543", expiryDate=DateTime.Parse("2025-01-02"),CVV="346",customerId=3,enrolementId=3},
                           new Payment() {transactionId=4,amount=50, cardNumber="9874000012396543", expiryDate=DateTime.Parse("2025-01-02"),CVV="396",customerId=4,enrolementId=4},
                            new Payment() {transactionId=5,amount=50, cardNumber="9874000012356543", expiryDate=DateTime.Parse("2025-01-02"),CVV="326",customerId=5,enrolementId=5},
                    };
            payment.ForEach(s => context.payments.Add(s));
            context.SaveChanges();


        }
    }
}