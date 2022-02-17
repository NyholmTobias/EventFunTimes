using Projektarbete.Models;

namespace EventFunTimesAPI.Services.Interfaces
{
    public interface IEventHostService
    {
        Event GetEvent(Guid? id);
        bool DeleteEvent(Guid? id);
        bool UpdateEvent(Event eventToUpdate);
        bool CreateEvent(Event newEvent);
        IEnumerable<Event> GetAllEvents();
    }
}
