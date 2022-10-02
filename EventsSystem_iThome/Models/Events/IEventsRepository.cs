using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public interface IEventsRepository
    {
        IEnumerable<Events> GetEvents();
        Events GetEventById(int? eventId);
        Task<Events> GetEventByIdAsync(int? eventId);
        bool AddEvent(Events @event);
        Task<bool> AddEventAsync(Events @event);
        bool DeleteEventById(int eventId);
        Task<bool> DeleteEventByIdAsync(Events @event);
        bool UpdateEvent(Events @event);
        Task<bool> UpdateEventAsync(Events @event);
    }
}
