using Microsoft.AspNetCore.Mvc;

namespace FieldBooking.Controllers
{
    public class FieldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
