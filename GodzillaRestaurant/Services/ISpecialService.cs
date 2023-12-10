using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface ISpecialService
    {
        public IEnumerable<Special> GetAllSpecials();
        public Special GetSpecial(int id);
        public void AddSpecial(Special special);
        public void UpdateSpecial(Special special);
        public void DeleteSpecial(int id);
    }
}
