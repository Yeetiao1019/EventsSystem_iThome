using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeStart { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeEnd { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeStart { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeEnd { get; set; }
        public string SimpleIntro { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }

        public EventsInfo EventsInfo { get; set; }  // 一對一
        public ICollection<EventsImage> EventsImage { get; set; }   // 一對多
    }
}
