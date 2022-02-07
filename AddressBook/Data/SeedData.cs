using AddressBook.Models;
namespace AddressBook.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AddressBookContext>();

            //Looking for Contacts

            if(context.Contacts.Any())
            {
                return; //Already Seeded
            }

            //HardCodded Seed Data
            context.Contacts.AddRange(new Contacts
            {
                FirstName = "Kowsar",
                LastName = "Rahman",
                Email = "saditsnigdho@gmail.com",
                MobilePhone = "0413532785",
                HomeAddressID = 1,
                WorkAddressID = 2
            },
            new Contacts
            {
                FirstName = "Sannidhyan",
                LastName = "Shom",
                Email = "samitsannidhyan@gmail.com",
                MobilePhone = "0413532786",
                HomeAddressID = 3,
                WorkAddressID = 4
            },
            new Contacts
            {
                FirstName = "Matthew",
                LastName = "Bolger",
                Email = "matrmit@gmail.com",
                MobilePhone = "0413532789"
            },
            new Contacts
            {
                FirstName = "Shekher",
                LastName = "Kalra",
                Email = "shekhar@gmail.com",
                MobilePhone = "0413532710",
            });

            context.Addresses.AddRange(new Addresses
            {
                Street = "120 Mason Street",
                Suburb = "Newport",
                PostCode = "3125",
                State = "VIC",
            },
            new Addresses
            {
                Street = "39 Lonsdale Street",
                Suburb = "Melbourne",
                PostCode = "3000",
                State = "VIC",
            },
            new Addresses
            {
                Street = "50 La Trobe Street",
                Suburb = "Melbourne",
                PostCode = "3000",
                State = "VIC",
            },
            new Addresses
            {
                Street = "120 King Street",
                Suburb = "Mountain Hills",
                PostCode = "5000",
                State = "QLD",
            });

            context.SaveChanges();
        }
    }
}
