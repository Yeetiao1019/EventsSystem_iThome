using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class EventsCategory
    {
        public int EventsCategoryId { get; set; }
        public string EventsCategoryName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}
