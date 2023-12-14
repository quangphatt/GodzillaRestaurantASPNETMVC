using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class TestimonialDAL : ITestimonialService
    {
        private AppDBContext _dbContext;

        public TestimonialDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Testimonial> GetAllTestimonials()
        {
            try
            {
                return _dbContext.Testimonial.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Testimonial GetTestimonial(int id) => _dbContext.Testimonial.Find(id);

        public void AddTestimonial(Testimonial testimonial)
        {
            try
            {
                _dbContext.Testimonial.Add(testimonial);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            try
            {
                _dbContext.Entry(testimonial).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteTestimonial(int id)
        {
            try
            {
                Testimonial testimonial = _dbContext.Testimonial.Find(id);
                _dbContext.Remove(testimonial);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
