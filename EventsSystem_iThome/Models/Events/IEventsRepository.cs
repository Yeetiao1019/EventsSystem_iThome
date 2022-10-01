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
        bool AddEvent(Events e);
        bool DeleteEventById(int eventId);
        bool UpdateEvent(Events e);
    }
}
