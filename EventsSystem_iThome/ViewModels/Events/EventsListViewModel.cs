using EventsSystem_iThome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsSystem_iThome.ViewModels
{
    public class EventsListViewModel
    {
        public IEnumerable<Events> EventsCollection { get; set; }
    }
}
