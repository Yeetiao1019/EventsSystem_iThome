using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EventsSystem_iThome.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "用戶名稱")]
        public string FullName { get; set; }
    }
}
