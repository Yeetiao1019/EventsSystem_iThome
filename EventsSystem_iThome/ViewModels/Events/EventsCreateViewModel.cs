using EventsSystem_iThome.Enum;
using EventsSystem_iThome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.ViewModels
{
    public class EventsCreateViewModel
    {
        public int Id { get; set; }  
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "最少輸入 5 字元，最多輸入 50 字元")]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeStart { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime SaleTimeEnd { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeStart { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ProgressTimeEnd { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "最少輸入 5 字元，最多輸入 50 字元")]
        public string SimpleIntro { get; set; }
        [Required]
        public EventsCategoryEnum EventsCategoryEnum { get; set; }
        public int CategoryId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; } = DateTime.Now;        
        [StringLength(100)]
        public string CreateUser { get; set; }

        public EventsInfo EventsInfo { get; set; }  // 一對一
        public ICollection<EventsImage> EventsImage { get; set; }   // 一對多
    }
}
