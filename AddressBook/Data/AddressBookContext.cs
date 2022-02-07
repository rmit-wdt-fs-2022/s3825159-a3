using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;

namespace AddressBook.Data
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        { }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        
    }
}
