using Projektarbete.Models;

namespace ProjektarbeteAdmin
{
    public static class Menu
    {
        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin");
            Console.WriteLine("1. Get all events.");
            Console.WriteLine("2. Get event by id.");
            Console.WriteLine("3. Update event.");
            Console.WriteLine("4. Delete event.");
            Console.WriteLine("5. Create event.");
            HandleChoice(Console.ReadLine());
        }

        private async static void CreateEventMenu()
        {
            var api = new ProjectarbeteAPI();
            List<string> weekdays = new() 
            { 
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday" 
            };

            string? insideOrOutsideString, openHourString, closeHourString, link, open;
            bool isEventInside, isEventOutside;
            List<OpeningHours> daysOpen = new();

            try
            {
                Console.Clear();
                Console.WriteLine("Create Event!");
                Console.Write("Inside event y/n: ");
                insideOrOutsideString = Console.ReadLine();
                foreach (var weekday in weekdays)
                {
                    Console.Write($"Is the event open at {weekday}? y/n: ");
                    open = Console.ReadLine().ToLower() == "y" ? weekday : "closed";
                    
                    if(open != "closed")
                    {
                        Console.Write("Opens (Hour 0-23): ");
                        openHourString = Console.ReadLine();
                        Console.Write("Closes (Hour 0-23): ");
                        closeHourString = Console.ReadLine();

                        daysOpen.Add(new OpeningHours
                        {
                            Weekday = weekday,
                            OpeningHour = int.Parse(openHourString),
                            ClosingHour = int.Parse(closeHourString),
                        });
                    }
                }
                Console.Write("Link to website: ");
                link = Console.ReadLine();

                isEventInside = insideOrOutsideString.ToLower() == "y";
                isEventOutside = insideOrOutsideString.ToLower() == "n";

                var newEvent = new Event
                {
                    Id = Guid.NewGuid(),
                    Inside = isEventInside,
                    Outside = isEventOutside,
                    OpeningHours = daysOpen,
                    Link = link
                };
                
                var result = await api.CreateEvent(newEvent);

                if (result)
                {
                    Console.Clear();
                    Console.WriteLine($"New event added with id: {newEvent.Id}. Press any key to get to the main menu.");
                    Console.ReadKey();
                    StartMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong when trying to add the created event. Press any key to get to the main menu.");
                    Console.ReadKey();
                    StartMenu();
                } 
            }
            catch
            {
                SomethingWentWrong();
            }
        }

        private async static void DeleteEventMenu()
        {
            var api = new ProjectarbeteAPI();
            try
            {
                Console.Clear();
                Console.WriteLine("Delete Event!");
                Console.Write("Enter the id of the event you want to delete: ");
                var id = Guid.Parse(Console.ReadLine());
                var result = await api.DeleteEvent(id);

                if(result)
                {
                    Console.Clear();
                    Console.WriteLine($"Event with id {id} has been deleted. Press any key to get to the main menu.");
                    Console.ReadKey();
                    StartMenu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Was not able to delete event with id: {id}. Press any key to get to the main menu.");
                    Console.ReadKey();
                    StartMenu();
                }
            }
            catch
            {
                SomethingWentWrong();
            }
        }

        private async static void UpdateEventMenu()
        {
            var api = new ProjectarbeteAPI();
            try
            {
                Console.Clear();
                Console.WriteLine("Update Event!");
                Console.WriteLine("Enter the id of the event you want to update.");
                var eventToUpdate = api.GetEvent(Guid.Parse(Console.ReadLine()));
                if(eventToUpdate != null)
                {
                    List<string> weekdays = new()
                    {
                        "Monday",
                        "Tuesday",
                        "Wednesday",
                        "Thursday",
                        "Friday",
                        "Saturday",
                        "Sunday"
                    };

                    string? insideOrOutsideString, openHourString, closeHourString, open;
                    List<OpeningHours> daysOpen = new();

                    Console.Write("Inside event y/n: ");
                    insideOrOutsideString = Console.ReadLine();
                    foreach (var weekday in weekdays)
                    {
                        Console.Write($"Is the event open at {weekday}? y/n: ");
                        open = Console.ReadLine().ToLower() == "y" ? weekday : "closed";

                        if (open != "closed")
                        {
                            Console.Write("Opens (Hour 0-23): ");
                            openHourString = Console.ReadLine();
                            Console.Write("Closes (Hour 0-23): ");
                            closeHourString = Console.ReadLine();

                            daysOpen.Add(new OpeningHours
                            {
                                Weekday = weekday,
                                OpeningHour = int.Parse(openHourString),
                                ClosingHour = int.Parse(closeHourString)
                            });
                        }
                    }
                    Console.Write("Link to website: ");
                    eventToUpdate.Result.Link = Console.ReadLine();

                    eventToUpdate.Result.Inside = insideOrOutsideString.ToLower() == "y";
                    eventToUpdate.Result.Outside = insideOrOutsideString.ToLower() == "n";

                    eventToUpdate.Result.OpeningHours.Clear();
                    foreach (var oh in daysOpen)
                    {
                        eventToUpdate.Result.OpeningHours.Add(oh);
                    }

                    var result = await api.UpdateEvent(eventToUpdate.Result);

                    if (result)
                    {
                        Console.Clear();
                        Console.WriteLine($"Event with id {eventToUpdate.Result.Id} has been updated. Press any key to get to the main menu.");
                        Console.ReadKey();
                        StartMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Was not able to update the event with id: {eventToUpdate.Result.Id}. Press any key to get to the main menu.");
                        Console.ReadKey();
                        StartMenu();
                    }
                }
            }
            catch
            {
                SomethingWentWrong();
            }
        }

        private async static void GetEventMenu()
        {
            var api = new ProjectarbeteAPI();
            try
            {
                Console.Clear();
                Console.WriteLine("Get an event by id!");
                Console.Write("Enter the id of the event you want to get: ");
                var id = Guid.Parse(Console.ReadLine());

                var e = await api.GetEvent(id);

                Console.Clear();
                if (e != null)
                {
                    PrettyPrintOneEvent(e, true);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("The event you tried to print is null. Press any key to get to the main menu.");
                    Console.ReadKey();
                    StartMenu();
                }
            }
            catch
            {
                SomethingWentWrong();
            }
        }

        private async static void GetAllEventsMenu()
        {
            var api = new ProjectarbeteAPI();
            try
            {
                var events = await api.GetAllEvents();
                Console.Clear();

                if (events != null || events != Enumerable.Empty<Event>())
                {
                    PrettyPrintManyEvents(events.ToList());
                }
            }
            catch
            {
                SomethingWentWrong();
            }
        }

        private static void HandleChoice(string? choice)
        {
            switch (choice)
            {
                case "1":
                    GetAllEventsMenu();
                    break;
                case "2":
                    GetEventMenu();
                    break;
                case "3":
                    UpdateEventMenu();
                    break;
                case "4":
                    DeleteEventMenu();
                    break;
                case "5":
                    CreateEventMenu();
                    break;
                default:
                    WrongChoise();
                    break;
            }
        }

        private static void WrongChoise()
        {
            Console.WriteLine();
            Console.WriteLine("Enter one of the numbers.");
            HandleChoice(Console.ReadLine());
        }

        private static void SomethingWentWrong()
        {
            Console.Clear();
            Console.WriteLine("Something went wrong. Press any key to get to the main menu.");
            Console.ReadKey();
            StartMenu();
        }

        private static void PrettyPrintOneEvent(Event e, bool endPrint)
        {
            Console.WriteLine($"Event id: {e.Id}");
            Console.WriteLine($"Inside event: {e.Inside}");
            Console.WriteLine($"Outside event: {e.Outside}");
            Console.WriteLine($"OpeningHours: ");
            foreach (var oh in e.OpeningHours)
            {
                Console.WriteLine($"{oh.Weekday} {oh.OpeningHour}-{oh.ClosingHour}");
            }
            Console.WriteLine($"Link: {e.Link}");
            Console.WriteLine();

            if(endPrint)
            {
                Console.WriteLine("Press any key to get to the main menu.");
                Console.ReadKey();
                StartMenu();
            }
        }

        private static void PrettyPrintManyEvents(List<Event> events)
        {
            events.ForEach(e => PrettyPrintOneEvent(e, false));

            Console.WriteLine("Press any key to get to the main menu.");
            Console.ReadKey();
            StartMenu();
        }
    }
}
