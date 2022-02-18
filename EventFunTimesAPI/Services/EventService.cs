﻿using EventFunTimesAPI.Data;
using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;

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
                _db.Events.Update(eventToUpdate);
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
                _db.Events.Add(newEvent);
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
