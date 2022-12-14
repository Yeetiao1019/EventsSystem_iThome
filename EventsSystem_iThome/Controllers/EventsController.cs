using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsSystem_iThome.Models;
using EventsSystem_iThome.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using EventsSystem_iThome.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EventsSystem_iThome.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IEventsRepository _eventsRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventsController(AppDbContext context, IEventsRepository eventsRepository,
            IWebHostEnvironment env,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _env = env;
            _eventsRepository = eventsRepository;
            _userManager = userManager;
        }

        // GET: Events
        [AllowAnonymous]
        public IActionResult Index()
        {
            var events = _eventsRepository.GetEvents();
            EventsListViewModel EventsListViewModel = new EventsListViewModel()
            {
                EventsCollection = events
            };

            return View(EventsListViewModel);
        }

        // GET: Events/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventsRepository.GetEventByIdAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            EventsApplyServices EventsApplyServices = new EventsApplyServices(_eventsRepository);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!await EventsApplyServices.IsApplicationLimitedQtyFull(@event) && EventsApplyServices.IsInEventsSalesTime(@event))
            {
                if (await EventsApplyServices.IsUserAlreadyEnroll((int)id, userId))
                {
                    ViewData["EnrollBtn"] = 2;
                }
                else
                {
                    ViewData["EnrollBtn"] = 1;
                }
            }
            else
            {
                ViewData["EnrollBtn"] = 3;
            }

            var applicationQty = await _eventsRepository.GetApplicateQtyByEventIdAsync((int)id);    //顯示已報名人數
            ViewData["ApplicateQty"] = applicationQty;

            if(userId != @event.CreateUser)
            {
                ViewData["ShowEditBtn"] = false;
            }
            else
            {
                ViewData["ShowEditBtn"] = true;
            }

            return View(@event);
        }

        // GET: Events/Create        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var uploadValue = EventsImageUploadService.UploadedFile(model, _env);

                IFormFile UploadImageFile = uploadValue.IFormFile;
                model.CategoryId = (int)model.EventsCategoryEnum;
                model.CreateUser = "admin";

                EventsImage EventsImageModel = new EventsImage
                {
                    ImageFileName = uploadValue.FileName,
                    ImageFilePath = uploadValue.FilePath,
                    ImageFileSize = (int)UploadImageFile.Length,
                    CreateTime = DateTime.Now,
                    CreateUser = "System"
                };

                ICollection<EventsImage> EventsImages = new List<EventsImage>();
                EventsImages.Add(EventsImageModel);

                var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<EventsCreateViewModel, Events>());
                var mapper = mapperConfig.CreateMapper();
                var events = mapper.Map<Events>(model);

                await _eventsRepository.AddEventWithEventsImageAsync(events, EventsImageModel);

                return RedirectToAction("Details", events);
            }

            return BadRequest();
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _eventsRepository.GetEventByIdAsync(id);
            if (model != null)
            {
                var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Events, EventsEditViewModel>());

                var mapper = mapperConfig.CreateMapper();
                var @event = mapper.Map<EventsEditViewModel>(model);

                return View(@event);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventsEditViewModel model)
        {
            if (model == null || model.Id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<EventsEditViewModel, Events>());

                    var mapper = mapperConfig.CreateMapper();
                    var @event = mapper.Map<Events>(model);

                    await _eventsRepository.UpdateEventAsync(@event);

                    return RedirectToAction("Details", @event);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new DbUpdateConcurrencyException("活動資料更新失敗");
                    }
                }

            }
            else
            {
                return NotFound();
            }
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _eventsRepository.GetEventByIdAsync(id);

            var mapperConfig = new MapperConfiguration(cfg =>
               cfg.CreateMap<Events, EventsDeleteViewModel>());

            var mapper = mapperConfig.CreateMapper();
            var @event = mapper.Map<EventsDeleteViewModel>(model);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(EventsDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<EventsDeleteViewModel, Events>());

                    var mapper = mapperConfig.CreateMapper();
                    var @event = mapper.Map<Events>(model);

                    await _eventsRepository.DeleteEventAsync(@event);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw new DbUpdateConcurrencyException("活動資料刪除失敗");
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EventsEnroll(int? id)
        {
            Events Event = new Events();
            try
            {
                if (id != null)
                {
                    Event = await _eventsRepository.GetEventByIdAsync(id);
                    EventsApplyServices EventsApplyServices = new EventsApplyServices(_eventsRepository);
                    var isInEventsSalesTime = EventsApplyServices.IsInEventsSalesTime(Event);
                    var isApplicationLimitedQtyFull = await EventsApplyServices.IsApplicationLimitedQtyFull(Event);
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    EventsEnroll EventsEnroll = new EventsEnroll()
                    {
                        Events = Event,
                        ApplicationUserId = userId
                    };

                    if (isInEventsSalesTime == true && isApplicationLimitedQtyFull == false
                        && !await EventsApplyServices.IsUserAlreadyEnroll((int)id, userId))
                    {
                        await _eventsRepository.SaveUserInfoToEventsEnrollAsync(EventsEnroll);
                        TempData["Message"] = "報名成功";
                    }
                    else
                    {
                        TempData["Message"] = "報名失敗";
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw new Exception("報名失敗");
            }

            return RedirectToAction("Details", Event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelEventsEnroll(int? id)
        {
            Events Event = new Events();
            try
            {
                if (id != null)
                {
                    Event = await _eventsRepository.GetEventByIdAsync(id);
                    EventsApplyServices EventsApplyServices = new EventsApplyServices(_eventsRepository);
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    EventsEnroll EventsEnroll = new EventsEnroll()
                    {
                        Events = Event,
                        ApplicationUserId = userId
                    };

                    if (Event != null && await EventsApplyServices.IsUserAlreadyEnroll((int)id, userId))
                    {
                        await _eventsRepository.DeleteUserInfoFromEventsEnrollAsync(EventsEnroll);
                        TempData["Message"] = "取消報名成功";
                    }
                    else
                    {
                        TempData["Message"] = "取消報名失敗";
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw new Exception("取消報名失敗");
            }

            return RedirectToAction("Details", Event);
        }

        private bool EventsExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
