using EventFunTimesAPI.Models;

namespace EventFunTimesAPI.Services.Interfaces
{
    public interface IEventHostService
    {
        Event GetEvent(Guid? id);
        IEnumerable<Event> GetEvents();
        bool DeleteEvent(Guid? id);
        bool UpdateEvent(Event eventToUpdate);
        bool CreateEvent(Event newEvent);
        IEnumerable<Event> GetAllEvents();
    }
}
