using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class SpecialDAL : ISpecialService
    {
        private AppDBContext _dbContext;

        public SpecialDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Special> GetAllSpecials()
        {
            try
            {
                return _dbContext.Special.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Special GetSpecial(int id) => _dbContext.Special.Find(id);

        public void AddSpecial(Special special)
        {
            try
            {
                _dbContext.Special.Add(special);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateSpecial(Special special)
        {
            try
            {
                _dbContext.Entry(special).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteSpecial(int id)
        {
            try
            {
                Special special = _dbContext.Special.Find(id);
                _dbContext.Remove(special);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
