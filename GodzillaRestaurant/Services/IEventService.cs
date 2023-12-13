using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IEventService
    {
        public IEnumerable<Event> GetAllEvents();
        public Event GetEvent(int id);
        public void AddEvent(Event _event);
        public void UpdateEvent(Event _event);
        public void DeleteEvent(int id);
    }
}
