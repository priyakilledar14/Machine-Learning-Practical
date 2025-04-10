namespace REST_API.Models
{
    public interface IRepository
    {
        IEnumerable<Reservation> GetReservation();

        Reservation GetReservation(int id);
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation resrevation);
        bool DeleteReservation(int id);

    }
}
