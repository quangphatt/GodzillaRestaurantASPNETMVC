using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IChefService
    {
        public IEnumerable<Chef> GetAllChefs();
        public Chef GetChef(int id);
        public void AddChef(Chef chef);
        public void UpdateChef(Chef chef);
        public void DeleteChef(int id);
    }
}
