using AddressBook.Models;
using AddressBook.Models.DataManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressesManager _repo;

        public AddressesController(AddressesManager repo)
        {
            _repo = repo;
        }

        // GET: api/Addressess
        [HttpGet]
        public IEnumerable<Addresses> Get()
        {
            return _repo.GetAll();
        }

        // GET api/Addressess/1
        [HttpGet("{id}")]
        public Addresses Get(int id)
        {
            return _repo.Get(id);
        }

        // POST api/Addressess
        [HttpPost]
        public void Post([FromBody] Addresses Addresses)
        {
            _repo.Add(Addresses);
        }

        // PUT api/Addressess
        [HttpPut]
        public void Put([FromBody] Addresses Addresses)
        {
            _repo.Update(Addresses.AddressID, Addresses);
        }

        // DELETE api/Addressess/1
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
