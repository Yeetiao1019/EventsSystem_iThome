using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsSystem_iThome.Models;
using Microsoft.Extensions.Logging;

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

        public async Task<bool> IsUserAlreadyEnroll(int id, string userId)
        {
            try
            {
                if(id > 0 && !string.IsNullOrEmpty(userId))
                {
                    var eventsEnrolls = await _eventsRepository.GetEventsEnrollsByEventIdAsync(id);

                    var userInEnroll = eventsEnrolls.Where(
                        ee => ee.ApplicationUserId == userId
                        ).FirstOrDefault();

                    if(userInEnroll == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    throw new Exception("判斷使用者是否在活動報名資料內錯誤。 ID not valid");
                }
            }
            catch (Exception)
            {
                throw new Exception("判斷使用者是否在活動報名資料內錯誤。");
            }
        }
    }
}

