using EventFunTimesUI.Services;
using Microsoft.AspNetCore.Mvc;
using Projektarbete.Models;

namespace Projektarbete.Controllers
{
    public class EventController : Controller
    {
        private readonly IUIEventService _uIEventService;

        public EventController(UIEventService eventService)
        {
            _uIEventService = eventService;
        }

        public IActionResult Show(EventResponse e)
        {
            return View(e);
        }

        public IActionResult GetEvents()
        {
            try
            {
                var events = _uIEventService.GetEvents();
                if(events.IsFaulted || events.IsCanceled || events.Result == Enumerable.Empty<EventResponse>())
                {
                    return BadRequest();
                }

                return View(events);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
