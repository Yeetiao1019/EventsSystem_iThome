using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EventsSystem_iThome.Models
{
    public class EventsRepository : IEventsRepository
    { 
        private readonly AppDbContext _appDbContext;
        private readonly IEventsImageRepository _eventsImageRepository;

        public EventsRepository(AppDbContext appDbContext, IEventsImageRepository eventsImageRepository)
        {
            this._appDbContext = appDbContext;
            _eventsImageRepository = eventsImageRepository;
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

        public async Task<bool> AddEventWithEventsImageAsync(Events @event, EventsImage eventsImage)
        {
            if (await AddEventAsync(@event))
            {
                eventsImage.EventsId = @event.Id;

                return await _eventsImageRepository.AddEventImageAsync(eventsImage);
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

                item.EventsImage = _appDbContext.EventsImage.Where(
                    ei => ei.EventsId == item.Id
                    ).ToList();
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

        public async Task<bool> SaveUserInfoToEventsEnrollAsync(EventsEnroll eventsEnroll)
        {
            _appDbContext.EventsEnroll.Add(eventsEnroll);
            var count = await _appDbContext.SaveChangesAsync();

            return count > 0;
        }

        public async Task<bool> DeleteUserInfoFromEventsEnrollAsync(EventsEnroll eventsEnroll)
        {
            var delEventsEnroll = await _appDbContext.EventsEnroll.Where(
                ee => ee.Events == eventsEnroll.Events && ee.ApplicationUserId == eventsEnroll.ApplicationUserId
                ).FirstOrDefaultAsync();
            _appDbContext.EventsEnroll.Remove(delEventsEnroll);
            var count = await _appDbContext.SaveChangesAsync();

            return count > 0;
        }

        public async Task<int> GetApplicateQtyByEventIdAsync(int eventId)
        {
            var qty = await _appDbContext.EventsEnroll.Where(
                ee => ee.Events.Id == eventId
                ).CountAsync();

            return qty;
        }

        public async Task<ICollection<EventsEnroll>> GetEventsEnrollsByEventIdAsync(int eventId)
        {
            var eventsEnrolls = await _appDbContext.EventsEnroll.Where(
                ee => ee.Events.Id == eventId
                ).ToListAsync();

            return eventsEnrolls;
        }

        public async Task<IEnumerable<Events>> GetTheNewestEventsAsync(int count)
        {
            string SqlScript = $"EXECUTE dbo.GetTheNewestEvents @Count = {count}";
            var events = await _appDbContext.Events.FromSqlRaw(SqlScript).ToListAsync();

            foreach (var item in events)
            {
                item.EventsInfo = _appDbContext.EventsInfo.Where(
                    ei => ei.EventsInfoOfEventsId == item.Id
                    ).FirstOrDefault();

                item.EventsImage = _appDbContext.EventsImage.Where(
                    ei => ei.EventsId == item.Id
                    ).ToList();
            }

            return events;
        }
    }
}
