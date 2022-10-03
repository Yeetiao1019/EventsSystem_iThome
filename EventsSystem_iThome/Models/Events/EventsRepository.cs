using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventsSystem_iThome.Models
{
    public class EventsRepository : IEventsRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventsRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public bool AddEvent(Events e)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddEventAsync(Events @event)
        {
            if (@event != null && @event.EventsInfo != null)
            {
                await _appDbContext.Events.AddAsync(@event);
                var count = await _appDbContext.SaveChangesAsync();

                return count > 0;
            }
            else
            {
                throw new Exception("Event 或 EventsInfo 資料有誤");
            }
        }

        public bool DeleteEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEventAsync(Events @event)
        {
            if(@event != null)
            {
                _appDbContext.Events.Remove(@event);
                var count = await _appDbContext.SaveChangesAsync();

                return count > 0;
            }

            return false;
        }

        public Events GetEventById(int? eventId)
        {
            var @event = _appDbContext.Events.Where(
             e => e.Id == eventId
            ).FirstOrDefault();

            if (@event != null)
            {
                var eventInfo = _appDbContext.EventsInfo.Where(
                    ei => ei.EventsInfoOfEventsId == @event.Id
                    ).FirstOrDefault();

                if (eventInfo != null)
                {
                    @event.EventsInfo = eventInfo;
                }
                else
                {
                    throw new Exception("EventsInfo 資料取得失敗");
                }
            }
            else
            {
                throw new Exception("Event 資料取得失敗");
            }

            return @event;
        }

        public async Task<Events> GetEventByIdAsync(int? eventId)
        {
            var @event = await _appDbContext.Events.Where(
             e => e.Id == eventId
            ).FirstOrDefaultAsync();

            if (@event != null)
            {
                var eventInfo = await _appDbContext.EventsInfo.Where(
                    ei => ei.EventsInfoOfEventsId == @event.Id
                    ).FirstOrDefaultAsync();

                if (eventInfo != null)
                {
                    @event.EventsInfo = eventInfo;
                }
                else
                {
                    throw new Exception("EventsInfo 資料取得失敗");
                }
            }
            else
            {
                throw new Exception("Event 資料取得失敗");
            }

            return @event;
        }

        public IEnumerable<Events> GetEvents()
        {
            var events = _appDbContext.Events.ToList();
            foreach (var item in events)
            {
                item.EventsInfo = _appDbContext.EventsInfo.Where(
                    ei => ei.EventsInfoOfEventsId == item.Id
                    ).FirstOrDefault();
            }

            return events;
        }

        public bool UpdateEvent(Events @event)
        {
            if (@event != null)
            {
                @event.UpdateTime = DateTime.Now;
                @event.UpdateUser = "System";

                _appDbContext.Events.Update(@event);
                _appDbContext.EventsInfo.Update(@event.EventsInfo);
            }

            var count = _appDbContext.SaveChanges();

            return count > 0;
        }

        public async Task<bool> UpdateEventAsync(Events @event)
        {
            if (@event != null)
            {
                _appDbContext.Events.Update(@event);
                _appDbContext.EventsInfo.Update(@event.EventsInfo);
            }

            var count = await _appDbContext.SaveChangesAsync();

            return count > 0;
        }
    }
}
