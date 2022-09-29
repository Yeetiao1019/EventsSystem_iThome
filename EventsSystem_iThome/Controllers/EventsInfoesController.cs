using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsSystem_iThome.Models;

namespace EventsSystem_iThome.Controllers
{
    public class EventsInfoesController : Controller
    {
        private readonly AppDbContext _context;

        public EventsInfoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventsInfoes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventsInfo.Include(e => e.Events);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventsInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsInfo = await _context.EventsInfo
                .Include(e => e.Events)
                .FirstOrDefaultAsync(m => m.EventsInfoId == id);
            if (eventsInfo == null)
            {
                return NotFound();
            }

            return View(eventsInfo);
        }

        // GET: EventsInfoes/Create
        public IActionResult Create()
        {
            ViewData["EventsInfoOfEventsId"] = new SelectList(_context.Events, "Id", "SimpleIntro");
            return View();
        }

        // POST: EventsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventsInfoId,ApplicationLimitedQty,EventsApplicationQty,PersonalSite,Location,FullIntro,EventsInfoOfEventsId")] EventsInfo eventsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventsInfoOfEventsId"] = new SelectList(_context.Events, "Id", "SimpleIntro", eventsInfo.EventsInfoOfEventsId);
            return View(eventsInfo);
        }

        // GET: EventsInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsInfo = await _context.EventsInfo.FindAsync(id);
            if (eventsInfo == null)
            {
                return NotFound();
            }
            ViewData["EventsInfoOfEventsId"] = new SelectList(_context.Events, "Id", "SimpleIntro", eventsInfo.EventsInfoOfEventsId);
            return View(eventsInfo);
        }

        // POST: EventsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventsInfoId,ApplicationLimitedQty,EventsApplicationQty,PersonalSite,Location,FullIntro,EventsInfoOfEventsId")] EventsInfo eventsInfo)
        {
            if (id != eventsInfo.EventsInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsInfoExists(eventsInfo.EventsInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventsInfoOfEventsId"] = new SelectList(_context.Events, "Id", "SimpleIntro", eventsInfo.EventsInfoOfEventsId);
            return View(eventsInfo);
        }

        // GET: EventsInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsInfo = await _context.EventsInfo
                .Include(e => e.Events)
                .FirstOrDefaultAsync(m => m.EventsInfoId == id);
            if (eventsInfo == null)
            {
                return NotFound();
            }

            return View(eventsInfo);
        }

        // POST: EventsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventsInfo = await _context.EventsInfo.FindAsync(id);
            _context.EventsInfo.Remove(eventsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsInfoExists(int id)
        {
            return _context.EventsInfo.Any(e => e.EventsInfoId == id);
        }
    }
}
