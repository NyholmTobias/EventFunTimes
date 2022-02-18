using EventFunTimesUI.Models;

namespace EventFunTimesUI.Services.Interfaces
{
    public interface IUIEventService
    {
        Task<IEnumerable<EventResponse>> GetEvents();
    }
}
