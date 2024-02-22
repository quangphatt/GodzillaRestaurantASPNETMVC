using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class FoodTypeDAL : IFoodTypeService
    {
        private AppDBContext _dbContext;

        public FoodTypeDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FoodType> GetAllFoodType() => _dbContext.FoodType.OrderBy(f => f.Sequence).ToList();

        public FoodType GetFoodType(int id) => _dbContext.FoodType.Find(id);

        public void AddFoodType(FoodType foodType)
        {
            try
            {
                _dbContext.FoodType.Add(foodType);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteFoodType(int id)
        {
            try
            {
                FoodType foodType = GetFoodType(id);
                _dbContext.Remove(foodType);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
