using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class EventDAL : IEventService
    {
        private AppDBContext _dbContext;

        public EventDAL(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            try
            {
                return _dbContext.Event.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Event GetEvent(int id) => _dbContext.Event.Find(id);

        public void AddEvent(Event _event)
        {
            try
            {
                _dbContext.Event.Add(_event);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEvent(Event _event)
        {
            try
            {
                _dbContext.Entry(_event).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEvent(int id)
        {
            try
            {
                Event _event = _dbContext.Event.Find(id);
                _dbContext.Remove(_event);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
