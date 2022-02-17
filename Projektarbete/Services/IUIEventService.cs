using Projektarbete.Models;

namespace EventFunTimesUI.Services
{
    public interface IUIEventService
    {
        Task<IEnumerable<EventResponse>> GetEvents();
    }
}
