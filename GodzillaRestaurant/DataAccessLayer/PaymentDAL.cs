using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class PaymentDAL : IPaymentService
    {
        private AppDBContext _dbContext;

        public PaymentDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Payment> GetAllPayments() => _dbContext.Payment.ToList();

        public Payment GetPayment(int id) => _dbContext.Payment.Find(id);

        public void AddPayment(Payment payment)
        {
            try
            {
                _dbContext.Payment.Add(payment);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePayment(Payment payment)
        {
            try
            {
                _dbContext.Entry(payment).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeletePayment(int id)
        {
            try
            {
                Payment payment = GetPayment(id);
                _dbContext.Remove(payment);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
