using EventFunTimesAPI.Data;
using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventFunTimesAPI.Services
{
    public class EventService : IEventHostService
    {
        private readonly new ApplicationDbContext _db;
        private readonly IWeatherService _weatherService;

        public EventService(ApplicationDbContext db, IWeatherService weatherService)
        {
            _db = db;
            _weatherService = weatherService;
        }

        /// <summary>
        /// Gets events based in the criterias that are generated automaticaly. 
        /// </summary>
        /// <returns>A list of events that pass the criterias and openinghour logic.</returns>
        public IEnumerable<Event> GetEvents()
        {
            return GetEvents(new Criterias(_weatherService));
        }

        private IEnumerable<Event> GetEvents(Criterias criterias)
        {
            IEnumerable<Event>? response = null;

            if (criterias.InsideEvent)
            {
                response = _db.Events.Where(e =>
                     e.Inside == true &&
                     e.OpeningHours.Any(oh => oh.Weekday == criterias.Time.DayOfWeek.ToString() &&
                     oh.OpeningHour - 1 < criterias.Time.Hour &&
                     oh.ClosingHour - 1 > criterias.Time.Hour));
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

        /// <summary>
        /// Get one event by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Event</returns>
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

        /// <summary>
        /// Finds and deletes event with the passed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Finds and update event.
        /// </summary>
        /// <param name="eventToUpdate"></param>
        /// <returns>true or false</returns>
        public bool UpdateEvent(Event? eventToUpdate)
        {
            try
            {
                _db.Events.Update(eventToUpdate);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new event and adds it to the db.
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns>true or false</returns>
        public bool CreateEvent(Event newEvent)
        {
            try
            {
                _db.Events.Add(newEvent);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all the events from the Events table.
        /// </summary>
        /// <returns>List of event</returns>
        public IEnumerable<Event> GetAllEvents()
        {
            try
            {
                return _db.Events
                    .Include(e => e.OpeningHours)
                    .ToList();
            }
            catch
            {
                return Enumerable.Empty<Event>();
            }
        }
    }
}
