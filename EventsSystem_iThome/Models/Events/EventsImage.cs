using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class EventsImage
    {
        public int EventsImageId { get; set; }
        public string ImageFilePath { get; set; }
        public string ImageFileName { get; set; }
        public int ImageFileSize { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }

        public int EventsId { get; set; }
        public Events Events { get; set; }      //一對多
    }
}
