using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using VehicleAutomation.Domain.ViewModel;
using VehicleAutomation.WebUI.Enum;
using VehicleAutomation.WebUI.Models;

namespace VehicleAutomation.WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string? _baseUrl;

        public OrdersController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _baseUrl = configuration.GetValue<string>("apiGatewayUrl") + "/orders";
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}");

            IEnumerable<Order> orders = Enumerable.Empty<Order>();
            if (response.IsSuccessStatusCode)
            {
                // Read response content
                var responseData = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<IEnumerable<Order>>(responseData);

                if(res != null)
                {
                    orders = res;
                }
            }

            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return await getById(id);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var orderStatuses = System.Enum.GetValues<OrderStatusEnum>();
            ViewBag.OrderStatusList = orderStatuses;
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync<OrderVM>($"{_baseUrl}/create", new OrderVM
                {
                    CustomerName = order.CustomerName,
                    Status = order.Status.ToString()
                });

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            var orderStatuses = System.Enum.GetValues<OrderStatusEnum>();
            ViewBag.OrderStatusList = orderStatuses;
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await getById(id);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,Status")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync<Order>($"{_baseUrl}/{id}", order);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return await getById(id);
        }

        // POST: Orders/Delete/5
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

            Order? order = null;
            if (response.IsSuccessStatusCode)
            {
                // Read response content
                var responseData = await response.Content.ReadAsStringAsync();
                order = JsonConvert.DeserializeObject<Order>(responseData);
            }

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

    }
}
