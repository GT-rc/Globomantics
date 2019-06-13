using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlobomanticsProductCatalog.Models;
using GlobomanticsProductCatalog.Data;
using Microsoft.EntityFrameworkCore;
using GlobomanticsProductCatalog.Services;

namespace GlobomanticsProductCatalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appContext;
        private readonly OrderApiClient orderApiClient;

        public HomeController(AppDbContext appContext, OrderApiClient orderApiClient)
        {
            this.appContext = appContext;
            this.orderApiClient = orderApiClient;
        }

        public IActionResult Index()
        {
            var categories = appContext.Categories.ToArray();
            return View(categories);
        }

        public IActionResult Category(int id)
        {
            var category = appContext.Categories
                .Include(x => x.Products)
                .Single(x => x.Id == id);

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Order(OrderForm form)
        {
            var order = new Order
            {
                ProductId = form.ProductId
            };

            await this.orderApiClient.PlaceOrder(order);

            return RedirectToAction("OrderSuccess");
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
