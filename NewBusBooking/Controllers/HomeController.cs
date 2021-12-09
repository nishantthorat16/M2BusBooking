using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace M2BusBooking.Controllers
{
    [Route("/")]
    [Authorize]
    public class HomeController : Controller
    {
        static List<string> buses = new List<string>();

        public HomeController()
        {
           /* if (buses.Count == 0)
            {
                buses.Add("Pune Bus");
                buses.Add("Mumbai Bus");
                buses.Add("Ahmednagar Bus");
            }*/
        }

        public IActionResult Index()
        {
            ViewBag.Buses = buses;
            return View();
        }

        [HttpGet("/addnewbus")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewBus()
        {
            return View();
        }

        [HttpPost("/addnewbus")]
        public IActionResult AddNewBus(string bus)
        {
            buses.Add(bus);
            return View();
        }
    }
}
