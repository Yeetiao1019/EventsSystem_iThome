using System;
using System.Threading.Tasks;
using EventsSystem_iThome.Models;

namespace EventsSystem_iThome.Services
{
    public class EventsApplyServices
    {
        private readonly IEventsRepository _eventsRepository;

        public EventsApplyServices(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public bool IsInEventsSalesTime(Events @event)
        {
            var salesTimeStart = @event.SaleTimeStart;
            var salesTimeEnd = @event.SaleTimeEnd;
            var dateTimeNow = DateTime.Now;

            if (salesTimeStart <= dateTimeNow && salesTimeEnd >= dateTimeNow )
                return true;

            return false;
        }

        public async Task<bool> IsApplicationLimitedQtyFull(Events @event)
        {
            var applicationLimitedQty = @event.EventsInfo.ApplicationLimitedQty;
            var eventsApplicationQty = await _eventsRepository.GetApplicateQtyByEventIdAsync(@event.Id);

            return applicationLimitedQty == eventsApplicationQty;
        }
    }
}

