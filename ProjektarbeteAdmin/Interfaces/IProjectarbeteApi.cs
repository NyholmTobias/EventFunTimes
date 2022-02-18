using EventFunTimesAPI.Models;

namespace ProjektarbeteAdmin.Interfaces
{
    public interface IProjectarbeteApi
    {
        Task<bool> CreateEvent(Event newEvent);
        Task<bool> DeleteEvent(Guid? id);
        Task<Event?> GetEvent(Guid? guid);
        Task<bool> UpdateEvent(Event eventToUpdate);
        Task<IEnumerable<Event?>?> GetAllEvents();
        Task<bool> CreateOpeningHours(List<OpeningHours> newOpeningHours);
        Task<bool> UpdateOpeningHours(List<OpeningHours> OpeningHoursToUpdate);
    }
}
