using EventFunTimesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventFunTimesAPI.Controllers
{
    [Route("api/v1/Seed")]
    [ApiController]
    public class SeedController : Controller
    {
        private readonly ISeedService _seedService;
        public SeedController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        [HttpPost]
        public async Task SeedDatabase()
        {
            await _seedService.CreateSeed();
        }
    }
}
