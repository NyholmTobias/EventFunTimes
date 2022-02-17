using Projektarbete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteAdmin
{
    public interface IProjectarbeteApi
    {
        Task<bool> CreateEvent(Event newEvent);
        Task<bool> DeleteEvent(Guid? id);
        Task<Event?> GetEvent(Guid? guid);
        Task<bool> UpdateEvent(Event result);
        Task<IEnumerable<Event?>?> GetAllEvents();
    }
}
