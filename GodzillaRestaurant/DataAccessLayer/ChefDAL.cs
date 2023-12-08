using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class ChefDAL : IChefService
    {
        private AppDBContext _dbContext;

        public ChefDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Chef> GetAllChefs()
        {
            try
            {
                return _dbContext.Chef.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Chef GetChef(int id) => _dbContext.Chef.Find(id);

        public void AddChef(Chef chef)
        {
            try
            {
                _dbContext.Chef.Add(chef);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateChef(Chef chef)
        {
            try
            {
                _dbContext.Entry(chef).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteChef(int id)
        {
            try
            {
                Chef chef = _dbContext.Chef.Find(id);
                _dbContext.Remove(chef);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
