using EventFunTimesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Projektarbete.Models;

namespace Projektarbete.Controllers
{
    [Route("api/v1/EventHost")]
    [ApiController]
    public class EventHostController : Controller
    {
        private readonly IEventHostService _eventService;

        public EventHostController(IEventHostService eventService)
        {
            _eventService = eventService;
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
