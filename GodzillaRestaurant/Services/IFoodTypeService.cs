using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IFoodTypeService
    {
        public IEnumerable<FoodType> GetAllFoodType();
        public FoodType GetFoodType(int id);
        public void AddFoodType(FoodType foodType);
        public void DeleteFoodType(int id);
    }
}
