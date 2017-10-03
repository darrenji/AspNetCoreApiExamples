using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreApiExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApiExamples.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository { get; set; }

        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(repository.Reservations);
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}
