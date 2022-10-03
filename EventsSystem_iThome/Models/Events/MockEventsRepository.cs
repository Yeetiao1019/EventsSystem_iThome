using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class MockEventsRepository : IEventsRepository
    {
        public bool AddEvent(Events e)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddEventAsync(Events @event)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEventById(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEventAsync(Events @event)
        {
            throw new NotImplementedException();
        }

        public Events GetEventById(int? eventId)
        {
            throw new NotImplementedException();
        }

        public Task<Events> GetEventByIdAsync(int? eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Events> GetEvents()
        {
            List<Events> Events = new List<Events>()
            {
                new Events
                {
                    Id = 1,
                    Title = "測試活動1",
                    SaleTimeStart = new DateTime(2022,10,1),
                    SaleTimeEnd = new DateTime(2022,10,10),
                    ProgressTimeStart = new DateTime(2022,10,11),
                    ProgressTimeEnd = new DateTime(2022,10,12),
                    SimpleIntro = "測試簡稱1",
                    CategoryId = 0,
                    CreateTime = DateTime.Now,
                    CreateUser = "System",
                    EventsInfo = new EventsInfo
                    { 
                        EventsInfoId = 1,
                        ApplicationLimitedQty = 10,
                        EventsApplicationQty = 2,
                        PersonalSite = "https://www.facebook.com",
                        Location = "Taipei/TW",
                        FullIntro = "完整介紹",
                        EventsInfoOfEventsId = 1
                    }
                },
                new Events
                {
                    Id = 2,
                    Title = "測試活動2",
                    SaleTimeStart = new DateTime(2022,11,1),
                    SaleTimeEnd = new DateTime(2022,11,10),
                    ProgressTimeStart = new DateTime(2022,11,11),
                    ProgressTimeEnd = new DateTime(2022,11,12),
                    SimpleIntro = "測試簡稱2",
                    CategoryId = 1,
                    CreateTime = DateTime.Now,
                    CreateUser = "System",
                    EventsInfo = new EventsInfo
                    {
                        EventsInfoId = 2,
                        ApplicationLimitedQty = 20,
                        EventsApplicationQty = 10,
                        PersonalSite = "https://google.com",
                        Location = "Ilan",
                        FullIntro = "完整介紹22",
                        EventsInfoOfEventsId = 2
                    }
                },
                new Events
                {
                    Id = 3,
                    Title = "測試活動3",
                    SaleTimeStart = new DateTime(2022,12,1),
                    SaleTimeEnd = new DateTime(2022,12,10),
                    ProgressTimeStart = new DateTime(2022,12,11),
                    ProgressTimeEnd = new DateTime(2022,12,12),
                    SimpleIntro = "測試簡稱3",
                    CategoryId = 2,
                    CreateTime = DateTime.Now,
                    CreateUser = "System",
                    EventsInfo = new EventsInfo
                    {
                        EventsInfoId = 3,
                        ApplicationLimitedQty = 30,
                        EventsApplicationQty = 30,
                        PersonalSite = "https://ithelp.ithome.com.tw/",
                        Location = "USA",
                        FullIntro = "完整介紹3",
                        EventsInfoOfEventsId = 3
                    }
                }
            };

            return Events;
        }

        public bool UpdateEvent(Events e)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEventAsync(Events @event)
        {
            throw new NotImplementedException();
        }
    }
}
