using GodzillaRestaurant.DataAccessLayer;
using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IPaymentService
    {
        public IEnumerable<Payment> GetAllPayments();
        public Payment GetPayment(int id);
        public void AddPayment(Payment payment);
        public void UpdatePayment(Payment payment);
        public void DeletePayment(int id);
    }
}
