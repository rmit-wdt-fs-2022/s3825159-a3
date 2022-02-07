using AddressBook.Data;
using AddressBook.Models.Repository;

namespace AddressBook.Models.DataManager
{
    public class AddressesManager : IDataRepository<Addresses, int>
    {
        private readonly AddressBookContext _context;

        public AddressesManager(AddressBookContext context)
        {
            _context = context;
        }

        public Addresses Get(int id)
        {
            return _context.Addresses.Find(id);
        }

        public IEnumerable<Addresses> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public int Add(Addresses Addresses)
        {
            _context.Addresses.Add(Addresses);
            _context.SaveChanges();

            return Addresses.AddressID;
        }

        public int Delete(int id)
        {
            _context.Addresses.Remove(_context.Addresses.Find(id));
            _context.SaveChanges();

            return id;
        }

        public int Update(int id, Addresses Addresses)
        {
            _context.Update(Addresses);
            _context.SaveChanges();

            return id;
        }
    }
}
