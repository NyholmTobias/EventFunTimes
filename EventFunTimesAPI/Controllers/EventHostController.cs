using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventFunTimesAPI.Controllers
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
            var response = _eventService.GetAllEvents();
            return response ?? Enumerable.Empty<Event>();
        }

        [HttpGet("GetCandidates")]
        public IEnumerable<Event> GetEvents()
        {
            var response = _eventService.GetEvents();
            return response ?? Enumerable.Empty<Event>();
        }

        [HttpGet("{eventId}")]
        public Event GetEvent([FromRoute] Guid id)
        {
            var response = _eventService.GetEvent(id);
            return response ?? new Event();
        }

        [HttpDelete("{eventId}")]
        public bool DeleteEvent([FromRoute] Guid id)
        {
            var response = _eventService.DeleteEvent(id);
            return response;
        }

        [HttpPut]
        public bool UpdateEvent(Event e)
        {
            var response = _eventService.UpdateEvent(e);
            return response;
        }

        [HttpPost]
        public bool CreateEvent(Event e)
        {
            var response = _eventService.CreateEvent(e);
            return response;
        }
    }
}
