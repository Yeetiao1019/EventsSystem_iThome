using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public interface IEventsImageRepository
    {
        IEnumerable<EventsImage> GetEventImages();
        EventsImage GetEventImageByEventId(int? eventId);
        Task<EventsImage> GetEventByEventIdAsync(int? eventId);
        bool AddEventImage(EventsImage eventImage);
        Task<bool> AddEventImageAsync(EventsImage eventImage);
        bool DeleteEventImageByEventImageId(int eventImageId);
        Task<bool> DeleteEventImageAsync(EventsImage eventImage);
        bool UpdateEventImage(EventsImage eventImage);
        Task<bool> UpdateEventImageAsync(EventsImage eventImage);
    }
}
