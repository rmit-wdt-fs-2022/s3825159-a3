using AddressBook.Data;
using AddressBook.Models.Repository;

namespace AddressBook.Models.DataManager
{
    public class ContactsManager : IDataRepository<Contacts, int>
    {
        private readonly AddressBookContext _context;

        public ContactsManager(AddressBookContext context)
        {
            _context = context;
        }

        public Contacts Get(int id)
        {
            return _context.Contacts.Find(id);
        }

        public IEnumerable<Contacts> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public int Add(Contacts Contacts)
        {
            _context.Contacts.Add(Contacts);
            _context.SaveChanges();

            return Contacts.ContactID;
        }

        public int Delete(int id)
        {
            _context.Contacts.Remove(_context.Contacts.Find(id));
            _context.SaveChanges();

            return id;
        }

        public int Update(int id, Contacts Contacts)
        {
            _context.Update(Contacts);
            _context.SaveChanges();

            return id;
        }
    }
}
