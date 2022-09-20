using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class EventsInfo
    {
        public int EventsInfoId { get; set; }        
        public int ApplicationLimitedQty { get; set; }
        public int EventsApplicationQty { get; set; }
        public string PersonalSite { get; set; }
        public string Location { get; set; }
        public string FullIntro { get; set; }

        public int EventsId { get; set; }
        public Events Events { get; set; }      //一對一
    }
}
