using Projektarbete.Models;

namespace Projektarbete.Services.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetEvents(Criterias criterias);
        Event GetEvent(Guid? id);
        bool DeleteEvent(Guid? id);
        bool UpdateEvent(Event eventToUpdate);
        bool CreateEvent(Event newEvent);
        IEnumerable<Event> GetAllEvents();
    }
}
