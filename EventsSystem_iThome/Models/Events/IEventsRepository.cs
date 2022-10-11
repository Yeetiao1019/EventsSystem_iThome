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
        Task<bool> AddEventWithEventsImageAsync(Events @event, EventsImage eventsImage);
        bool DeleteEventById(int eventId);
        Task<bool> DeleteEventAsync(Events @event);
        bool UpdateEvent(Events @event);
        Task<bool> UpdateEventAsync(Events @event);

        //對 EventsEnroll 的 Function
        Task<bool> SaveUserInfoToEventsEnrollAsync(EventsEnroll eventsEnroll);
        Task<bool> DeleteUserInfoFromEventsEnrollAsync(EventsEnroll eventsEnroll);
        Task<int> GetApplicateQtyByEventIdAsync(int eventId);
    }
}
