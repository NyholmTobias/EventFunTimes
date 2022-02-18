using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventFunTimesAPI.Controllers
{
    [Route("api/v1/Openinghours")]
    [ApiController]
    public class OpeninghoursController : Controller
    {
        private readonly IOpeninghoursService _openinghoursService;

        public OpeninghoursController(IOpeninghoursService openinghoursService)
        {
            _openinghoursService = openinghoursService;
        }

        [HttpPut]
        public bool UpdateOpeningHours(List<OpeningHours> oh)
        {
            var response = _openinghoursService.UpdateOpeningHours(oh);
            return response;
        }

        [HttpPost]
        public bool CreateOpeningHours(List<OpeningHours> oh)
        {
            var response = _openinghoursService.CreateOpeningHours(oh);
            return response;
        }
    }
}
    