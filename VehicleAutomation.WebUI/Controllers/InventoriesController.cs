using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VehicleAutomation.WebUI.Models;

namespace VehicleAutomation.WebUI.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public InventoriesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = configuration.GetValue<string>("apiGatewayUrl") + "/inventory";
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}");

            IEnumerable<Inventory> inventory = Enumerable.Empty<Inventory>();
            if (response.IsSuccessStatusCode)
            {
                // Read response content
                var responseData = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<IEnumerable<Inventory>>(responseData);

                if (res != null)
                {
                    inventory = res;
                }
            }

            return View(inventory);
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return await getById(id);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ComponentType,Quantity")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync<Inventory>($"{_baseUrl}/create", inventory);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await getById(id);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ComponentType,Quantity")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync<Inventory>($"{_baseUrl}/{id}", inventory);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return await getById(id);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> getById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");

            Inventory? inventory = null;
            if (response.IsSuccessStatusCode)
            {
                // Read response content
                var responseData = await response.Content.ReadAsStringAsync();
                inventory = JsonConvert.DeserializeObject<Inventory>(responseData);
            }

            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }
    }
}
