using Front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json;

namespace Front_end.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            /*
            HttpClient client = new HttpClient();
            string url = "https://localhost:7252/customer/GetAllCountry/";
            string url1 = "https://localhost:7252/customer/PostCountry/";
            var store = JsonConvert.DeserializeObject<List<Country>>(await client.GetStringAsync(url));
            var country = new Country()
            {
                CountryName = "Bangladesh",
                Id = 1

            };
            await client.PostAsJsonAsync(url1,country);
            */
            return View();
        }

        public IActionResult Privacy()
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