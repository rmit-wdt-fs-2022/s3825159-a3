using System.Text;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using Newtonsoft.Json;

namespace AddressBook.Controllers;

public class ContactsApiController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private HttpClient Client => _clientFactory.CreateClient();

    public ContactsApiController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    // GET: Movies/Index
    public async Task<IActionResult> Index()
    {
        var response = await Client.GetAsync("api/contacts");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        // Storing the response details received from web api.
        var result = await response.Content.ReadAsStringAsync();

        // Deserializing the response received from web api and storing into a list.
        var movies = JsonConvert.DeserializeObject<List<ContactsDto>>(result);

        return View(movies);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ContactsDto movie)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

            var response = Client.PostAsync("api/contacts", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
        }

        return View(movie);
    }

    // GET: Movies/Edit/1
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await Client.GetAsync($"api/contacts/{id}");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var result = await response.Content.ReadAsStringAsync();
        var movie = JsonConvert.DeserializeObject<ContactsDto>(result);

        return View(movie);
    }

    // POST: Movies/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ContactsDto movie)
    {
        if (id != movie.ContactID)
            return NotFound();

        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(movie), Encoding.UTF8, "application/json");

            var response = Client.PutAsync("api/contacts", content).Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
        }

        return View(movie);
    }

    // GET: Movies/Delete/1
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await Client.GetAsync($"api/contacts/{id}");

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var result = await response.Content.ReadAsStringAsync();
        var movie = JsonConvert.DeserializeObject<ContactsDto>(result);

        return View(movie);
    }

    // POST: Movies/Delete/1
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var response = Client.DeleteAsync($"api/contacts/{id}").Result;

        if (response.IsSuccessStatusCode)
            return RedirectToAction("Index");

        return NotFound();
    }
}
