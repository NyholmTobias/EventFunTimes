using EventFunTimesUI.Models;
using EventFunTimesUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventFunTimesUI.Controllers
{
    public class EventController : Controller
    {
        private readonly IUIEventService _uIEventService;

        public EventController(IUIEventService uIeventService)
        {
            _uIEventService = uIeventService;
        }

        public IActionResult Show(EventResponse e)
        {
            return View(e);
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            try
            {
                var events = _uIEventService.GetEvents();
                if (events.IsFaulted || events.IsCanceled || events.Result == Enumerable.Empty<EventResponse>())
                {
                    return BadRequest();
                }

                return View(events.Result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
