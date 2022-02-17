using Projektarbete.Data;
using Projektarbete.Models;
using Projektarbete.Services.Interfaces;

namespace Projektarbete.Services
{
    public class EventService : IEventService
    {
        private readonly new ApplicationDbContext _db;

        public EventService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Event> GetEvents(Criterias criterias)
        {
            IEnumerable<Event>? response = null;

            if (criterias.InsideEvent)
            {
                response = _db.Events.Where(e =>
                     e.Inside == true &&
                     e.OpeningHours.Any(oh => oh.Weekday == criterias.Time.DayOfWeek.ToString() &&
                     oh.OpeningHour -1 < criterias.Time.Hour &&
                     oh.ClosingHour -1 > criterias.Time.Hour));
            }
            else if (!criterias.InsideEvent)
            {
                response = _db.Events.Where(e =>
                     e.Outside == true &&
                     e.OpeningHours.Any(oh => oh.Weekday == criterias.Time.DayOfWeek.ToString() &&
                     oh.OpeningHour - 1 < criterias.Time.Hour &&
                     oh.ClosingHour - 1 > criterias.Time.Hour));
            }

            if (response != null) return response;

            else return Enumerable.Empty<Event>();
        }

        public Event GetEvent(Guid? id)
        {
            try
            {
                return _db.Events.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteEvent(Guid? id)
        {
            try
            {
                _db.Events.Remove(GetEvent(id));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateEvent(Event? eventToUpdate)
        {
            try
            {
                _db.Update(eventToUpdate);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateEvent(Event newEvent)
        {
            try
            {
                _db.Add(newEvent);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Event> GetAllEvents()
        {
            try
            {
                return _db.Events;
            }
            catch
            {
                return Enumerable.Empty<Event>();
            }
        }
    }
}
