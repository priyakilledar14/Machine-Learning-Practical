using Microsoft.AspNetCore.Mvc;
    namespace REST_API.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reservation> items;
        public Repository()
        {
            this.items = new Dictionary<int, Reservation>();

            List<Reservation> listReservation = new List<Reservation>();
            listReservation.Add(new Reservation { Id = 1, Name = "PRIYA", StartLocation = "MUMBAI", EndLocation = "PUNE" });
            listReservation.Add(new Reservation { Id = 1, Name = "PIU", StartLocation = "PUNE", EndLocation = "MUMBAI" });

            foreach (var r in listReservation)
            {
                AddReservation(r);
            }
        }

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; }
                ;
                reservation.Id = key;
            }
            items[reservation.Id] = reservation;
            return reservation;
        }

        public bool DeleteReservation(int id)
        {
            return items.Remove(id);
        }


        public Reservation? GetReservation(int id)
        {
            return items.ContainsKey(id) ? items[id] : null;
        }
        IEnumerable<Reservation> GetReservation()
        {
            return items.Values;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            return AddReservation(reservation);
        }

        IEnumerable<Reservation> IRepository.GetReservation()
        {
            return GetReservation();
        }
    }
}


