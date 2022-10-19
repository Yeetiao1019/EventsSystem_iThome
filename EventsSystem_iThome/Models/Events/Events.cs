using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.Models
{
    public class Events
    {
        public int Id { get; set; }  
        [Required]
        [Display(Name = "活動名稱")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "最少輸入 5 字元，最多輸入 50 字元")]
        public string Title { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeStart { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeEnd { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeStart { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeEnd { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "最少輸入 5 字元，最多輸入 50 字元")]
        public string SimpleIntro { get; set; }
        [Display(Name = "活動類型")]
        public int CategoryId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
        [StringLength(100)]
        public string CreateUser { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime UpdateTime { get; set; }
        [StringLength(100)]
        public string UpdateUser { get; set; }

        public EventsInfo EventsInfo { get; set; }  // 一對一
        public ICollection<EventsImage> EventsImage { get; set; }   // 一對多
        public ICollection<EventsEnroll> EventsEnroll { get; set; }   // 一對多
    }
}
