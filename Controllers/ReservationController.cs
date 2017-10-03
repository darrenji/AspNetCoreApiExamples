using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreApiExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApiExamples.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository reposiory;

        public ReservationController(IRepository repo)
        {
            reposiory = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return reposiory.Reservations;
        }

        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return reposiory[id];
        }

        [HttpPost]
        public Reservation Post([FromBody]Reservation res)
        {
            return reposiory.AddReservation(new Reservation
            {
                ClientName = res.ClientName,
                Location = res.Location
            });
        }

        [HttpPut]
        public Reservation Put([FromBody]Reservation res)
        {
           return reposiory.UpdateReservation(res);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reposiory.DeleteReservation(id);
        }
    }
}
