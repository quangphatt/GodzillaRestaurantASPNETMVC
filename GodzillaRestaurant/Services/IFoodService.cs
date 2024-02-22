using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IFoodService
    {
        public IEnumerable<Food> GetAllMenu();
        public Food GetFood(int id);
        public void AddFood(Food food);
        public void UpdateFood(Food food);
        public void DeleteFood(int id);
    }
}
