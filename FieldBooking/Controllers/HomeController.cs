using FieldBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FieldBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
        [NonAction]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}