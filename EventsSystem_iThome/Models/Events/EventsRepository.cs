using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public bool DeleteEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public Events GetEventById(int? eventId)
        {
            throw new NotImplementedException();
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

        public bool UpdateEvent(Events e)
        {
            throw new NotImplementedException();
        }
    }
}
