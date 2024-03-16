using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class BookingDAL : IBookingService
    {
        private readonly AppDBContext _dbContext;
        private readonly IUserService _userService;

        public BookingDAL(AppDBContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public IEnumerable<Booking> GetAllBooking() => _dbContext.Booking.OrderByDescending(o => o.CreateDate).ToList();

        public IEnumerable<Booking> GetAllBookingOfUser() => _dbContext.Booking.Where(o => o.UserId == _userService.GetUserId()).OrderByDescending(o => o.CreateDate).ToList();

        public Booking GetBooking(int id) => _dbContext.Booking.Find(id);

        public void CreateBooking(Booking booking)
        {
            try
            {
                booking.DateTime = DateTime.SpecifyKind(booking.DateTime, DateTimeKind.Utc);
                booking.CreateDate = DateTime.UtcNow;
                booking.UserId = _userService.GetUserId();
                booking.BookingStatus = 1;
                if (booking.Message == null)
                {
                    booking.Message = "";
                }
                _dbContext.Booking.Add(booking);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateBookingStatus(int bookingId, int bookingStatus)
        {
            try
            {
                var booking = GetBooking(bookingId);
                booking.BookingStatus = bookingStatus;
                _dbContext.Entry(booking).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
