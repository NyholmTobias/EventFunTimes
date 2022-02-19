using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;

namespace EventFunTimesAPI.Services
{
    public class SeedService : ISeedService
    {
        private readonly IEventHostService _eventHostService;
        private readonly IOpeninghoursService _openinghoursService;

        public SeedService(IOpeninghoursService openinghoursService, IEventHostService eventHostService)
        {
            _openinghoursService = openinghoursService;
            _eventHostService = eventHostService;
        }

        /// <summary>
        /// Fills the database
        /// </summary>
        /// <returns>Response Code</returns>
        public async Task CreateSeed()
        {
            CreateBackaBowling();
            CreateSlottskogen();
            CreateBiljardpalatset();
            CreatePaintballFabriken();
            CreateLazerDome();
        }

        private void CreateBackaBowling()
        {
            var bowling = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Backa Bowling",
                Inside = true,
                Outside = false,
                Link = "https://backabowling.com/"
            };

            var bowlingOpeninghours = new List<OpeningHours>
            {
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 19,
                    Weekday = "Monday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 19,
                    Weekday = "Tuesday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 19,
                    Weekday = "Wednesday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 19,
                    Weekday = "Thursday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 23,
                    Weekday = "Friday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 23,
                    Weekday = "Saturday",
                    Event  = bowling
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 11,
                    ClosingHour = 16,
                    Weekday = "Sunday",
                    Event  = bowling
                }
            };

            bowling.OpeningHours = bowlingOpeninghours;

            _eventHostService.CreateEvent(bowling);
        }

        private void CreateSlottskogen()
        {
            var slottskogen = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Slottskogen",
                Inside = false,
                Outside = true,
                Link = "https://goteborg.se/wps/portal/enhetssida/slottsskogen"
            };

            var slottskogenOpeninghours = new List<OpeningHours>
            {
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Monday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Tuesday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Wednesday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Thursday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Friday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Saturday",
                    Event  = slottskogen
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 6,
                    ClosingHour = 23,
                    Weekday = "Sunday",
                    Event  = slottskogen
                }
            };

            slottskogen.OpeningHours = slottskogenOpeninghours;

            _eventHostService.CreateEvent(slottskogen);
        }

        private void CreateBiljardpalatset()
        {
            var biljardPalatset = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Biljard Palatset",
                Inside = true,
                Outside = false,
                Link = "https://palatset.com/"
            };

            var biljardPalatsetOpeninghours = new List<OpeningHours>
            {
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 15,
                    ClosingHour = 24,
                    Weekday = "Monday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 15,
                    ClosingHour = 24,
                    Weekday = "Tuesday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 15,
                    ClosingHour = 24,
                    Weekday = "Wednesday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 15,
                    ClosingHour = 24,
                    Weekday = "Thursday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 15,
                    ClosingHour = 24,
                    Weekday = "Friday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 0,
                    ClosingHour = 2,
                    Weekday = "Saturday",
                    Event = biljardPalatset
                },
                 new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 14,
                    ClosingHour = 24,
                    Weekday = "Saturday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 0,
                    ClosingHour = 2,
                    Weekday = "Sunday",
                    Event = biljardPalatset
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 14,
                    ClosingHour = 24,
                    Weekday = "Sunday",
                    Event = biljardPalatset
                }
            };
            biljardPalatset.OpeningHours = biljardPalatsetOpeninghours;

            _eventHostService.CreateEvent(biljardPalatset);
        }

        private void CreatePaintballFabriken()
        {
            var paintballFabriken = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Paintball Fabriken",
                Inside = false,
                Outside = true,
                Link = "https://www.paintballfabriken.se/"
            };

            var paintballFabrikenOpeninghours = new List<OpeningHours>
            {
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Monday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Tuesday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Wednesday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Thursday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Friday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Saturday",
                    Event  = paintballFabriken
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 9,
                    ClosingHour = 18,
                    Weekday = "Sunday",
                    Event  = paintballFabriken
                }
            };

            paintballFabriken.OpeningHours = paintballFabrikenOpeninghours;

            _eventHostService.CreateEvent(paintballFabriken);
        }

        private void CreateLazerDome()
        {
            var lazerdome = new Event
            {
                Id = Guid.NewGuid(),
                Title = "Lazerdome",
                Inside = true,
                Outside = false,
                Link = "https://goteborg.laserdome.se/"
            };

            var lazerdomeOpeninghours = new List<OpeningHours>
            {
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 12,
                    ClosingHour = 19,
                    Weekday = "Monday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 12,
                    ClosingHour = 19,
                    Weekday = "Tuesday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 12,
                    ClosingHour = 19,
                    Weekday = "Wednesday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 12,
                    ClosingHour = 19,
                    Weekday = "Thursday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 12,
                    ClosingHour = 22,
                    Weekday = "Friday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 10,
                    ClosingHour = 22,
                    Weekday = "Saturday",
                    Event  = lazerdome
                },
                new OpeningHours
                {
                    Id = Guid.NewGuid(),
                    OpeningHour = 10,
                    ClosingHour = 19,
                    Weekday = "Sunday",
                    Event  = lazerdome
                }
            };

            lazerdome.OpeningHours = lazerdomeOpeninghours;

            _eventHostService.CreateEvent(lazerdome);
        }
    }
}
