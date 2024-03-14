using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IBookingService
    {
        public IEnumerable<Booking> GetAllBooking();
        public IEnumerable<Booking> GetAllBookingOfUser();
        public Booking GetBooking(int id);
        public void CreateBooking(Booking booking);
        public void UpdateBookingStatus(int bookingId, int bookingStatus);
    }
}
