using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class EventsImageRepository : IEventsImageRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventsImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool AddEventImage(EventsImage eventImage)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddEventImageAsync(EventsImage eventImage)
        {
            eventImage.ImageFileName = string.IsNullOrEmpty(eventImage.ImageFileName) ?
                throw new Exception("圖片檔名為空值") :
                eventImage.ImageFileName; // 避免 Null 值導致無法撈資料

            await _appDbContext.EventsImage.AddAsync(eventImage);

            var count = await _appDbContext.SaveChangesAsync();

            return count > 0;
        }

        public Task<bool> DeleteEventImageAsync(EventsImage eventImage)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteEventImageByEventImageId(int eventImageId)
        {
            throw new System.NotImplementedException();
        }

        public Task<EventsImage> GetEventByEventIdAsync(int? eventId)
        {
            if (eventId == null)
            {
                throw new Exception("Events 資料錯誤。");
            }

            return _appDbContext.EventsImage.FirstOrDefaultAsync(ei => ei.EventsId == eventId);
        }

        public EventsImage GetEventImageByEventId(int? eventId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventsImage> GetEventImages()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateEventImage(EventsImage eventImage)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateEventImageAsync(EventsImage eventImage)
        {
            _appDbContext.EventsImage.Update(eventImage);
            var count = await _appDbContext.SaveChangesAsync();

            return count > 0;
        }
    }
}
