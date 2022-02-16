using Microsoft.AspNetCore.Mvc;
using Projektarbete.Models;
using Projektarbete.Services;
using Projektarbete.Services.Interfaces;

namespace Projektarbete.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Show(Event e)
        {
            return View(e);
        }

        public IActionResult GetEvents()
        {
            try
            {
                return View(_eventService.GetEvents(new Criterias(new WeatherService())));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }

        [HttpGet]
        public Event GetEvent(Guid id)
        {
            return _eventService.GetEvent(id);
        }
        
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public bool DeleteEvent(Guid id)
        {
            return _eventService.DeleteEvent(id);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public bool UpdateEvent(Event e)
        {
            return _eventService.UpdateEvent(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool CreateEvent(Event e)
        {
            return _eventService.CreateEvent(e);
        }
    }
}
