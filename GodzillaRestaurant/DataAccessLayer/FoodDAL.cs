using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class FoodDAL : IFoodService
    {
        private AppDBContext _dbContext;

        public FoodDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Food> GetAllMenu()
        {
            try
            {
                return _dbContext.Food.ToList();
            }
            catch
            {
                return Enumerable.Empty<Food>();
            }
        }

        public Food GetFood(int id) => _dbContext.Food.Find(id);

        public void AddFood(Food food)
        {
            try
            {
                _dbContext.Food.Add(food);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateFood(Food food)
        {
            try
            {
                _dbContext.Entry(food).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteFood(int id)
        {
            try
            {
                Food food = GetFood(id);
                _dbContext.Remove(food);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
