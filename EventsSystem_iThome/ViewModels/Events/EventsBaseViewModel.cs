using EventsSystem_iThome.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using EventsSystem_iThome.Enum;

namespace EventsSystem_iThome.ViewModels
{
    public class EventsBaseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "活動名稱")]
        public string Title { get; set; }
        [Display(Name = "票券販賣起始時間")]
        public DateTime SaleTimeStart { get; set; }
        [Display(Name = "票券販賣結束時間")]
        public DateTime SaleTimeEnd { get; set; }
        [Display(Name = "活動開始時間")]
        public DateTime ProgressTimeStart { get; set; }
        [Display(Name = "活動結束時間")]
        public DateTime ProgressTimeEnd { get; set; }
        [Display(Name = "活動簡介")]
        public string SimpleIntro { get; set; }
        [Display(Name = "活動類型")]
        public EventsCategoryEnum EventsCategoryEnum { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "資料建立時間")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "資料建立者")]
        public string CreateUser { get; set; }
        [Display(Name = "資料修改時間")]
        public DateTime UpdateTime { get; set; }
        [Display(Name = "資料修改者")]
        public string UpdateUser { get; set; }

        public EventsInfo EventsInfo { get; set; }  // 一對一
        public ICollection<EventsImage> EventsImage { get; set; }   // 一對多
    }
}
