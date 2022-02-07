using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Data;
using AddressBook.Models.DataManager;
using AddressBook.Models;

namespace AddressBook.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsManager _repo;

        public ContactsController(ContactsManager repo)
        {
            _repo = repo;
        }

        // GET: api/Contactss
        [HttpGet]
        public IEnumerable<Contacts> Get()
        {
            return _repo.GetAll();
        }

        // GET api/Contactss/1
        [HttpGet("{id}")]
        public Contacts Get(int id)
        {
            return _repo.Get(id);
        }

        // POST api/Contactss
        [HttpPost]
        public void Post([FromBody] Contacts Contacts)
        {
            _repo.Add(Contacts);
        }

        // PUT api/Contactss
        [HttpPut]
        public void Put([FromBody] Contacts Contacts)
        {
            _repo.Update(Contacts.ContactID, Contacts);
        }

        // DELETE api/Contactss/1
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
