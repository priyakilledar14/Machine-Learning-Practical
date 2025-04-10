using Microsoft.AspNetCore.Mvc;
using REST_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reservationController : ControllerBase
    {
        private IRepository repository;
        public reservationController(IRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<reservationController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return repository.GetReservation();
        }

        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return repository.GetReservation(id);
        }


        // POST api/<reservationController>
        [HttpPost]
        public Reservation Post([FromBody]Reservation reservation) 
        {
            Reservation reservation1 = new Reservation();
            reservation1.Name = reservation.Name;
            reservation1.StartLocation = reservation.StartLocation;
            reservation1.EndLocation = reservation.EndLocation;

            return repository.AddReservation(reservation1);

        }

        // PUT api/<reservationController>/5
        [HttpPut("{id}")]
        public Reservation Put(int id, [FromBody] Reservation reservation)
        {
            Reservation reservation1 = new Reservation();
            reservation1.Id = reservation.Id;
            reservation1.Name = reservation.Name;
            reservation1.StartLocation = reservation.Name;
            reservation1.EndLocation = reservation.Name;

            return repository.UpdateReservation(reservation1);

        }

        // DELETE api/<reservationController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return repository.DeleteReservation(id);
        }
    }
}
