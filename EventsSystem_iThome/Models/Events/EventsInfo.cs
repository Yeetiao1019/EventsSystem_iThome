using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class EventsInfo
    {
        public int EventsInfoId { get; set; }
        [Required]
        public int ApplicationLimitedQty { get; set; }
        public int EventsApplicationQty { get; set; }
        public string PersonalSite { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string FullIntro { get; set; }

        public int EventsInfoOfEventsId { get; set; }
        public Events Events { get; set; }      //一對一
    }
}
