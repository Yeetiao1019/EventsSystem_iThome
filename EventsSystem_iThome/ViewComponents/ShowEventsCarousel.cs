using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsSystem_iThome.Models;
using EventsSystem_iThome.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventsSystem_iThome.ViewComponents
{
    public class ShowEventsCarousel : ViewComponent
    {
        private readonly IEventsRepository _eventsRepository;

        public ShowEventsCarousel(IEventsRepository eventsRepository)
        {
            this._eventsRepository = eventsRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new EventsListViewModel
            {
                EventsCollection = await _eventsRepository.GetTheNewestEventsAsync(5)
            });
        }
    }
}

