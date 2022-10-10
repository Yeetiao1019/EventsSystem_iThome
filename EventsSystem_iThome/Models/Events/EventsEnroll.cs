using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsSystem_iThome.Models
{
    public class EventsEnroll
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string ApplicationUserId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EnrollTime { get; set; }

        public Events Events { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
    }
}
