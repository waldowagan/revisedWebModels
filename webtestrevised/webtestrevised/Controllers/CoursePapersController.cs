using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webtestrevised.Data;
using webtestrevised.Models;

namespace webtestrevised.Controllers
{
    public class CoursePapersController : Controller
    {
        private readonly GymContext _context;

        public CoursePapersController(GymContext context)
        {
            _context = context;
        }

        // GET: CoursePapers
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.CoursePapers.Include(c => c.Staff);
            return View(await gymContext.ToListAsync());
        }

        // GET: CoursePapers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePaper = await _context.CoursePapers
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(m => m.CoursePaperID == id);
            if (coursePaper == null)
            {
                return NotFound();
            }

            return View(coursePaper);
        }

        // GET: CoursePapers/Create
        public IActionResult Create()
        {
            ViewData["StaffID"] = new SelectList(_context.Staff, "UserID", "UserID");
            return View();
        }

        // POST: CoursePapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoursePaperID,CoursePaper_No,CourseName,StaffID,User_Type")] CoursePaper coursePaper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursePaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffID"] = new SelectList(_context.Staff, "UserID", "UserID", coursePaper.StaffID);
            return View(coursePaper);
        }

        // GET: CoursePapers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePaper = await _context.CoursePapers.FindAsync(id);
            if (coursePaper == null)
            {
                return NotFound();
            }
            ViewData["StaffID"] = new SelectList(_context.Staff, "UserID", "UserID", coursePaper.StaffID);
            return View(coursePaper);
        }

        // POST: CoursePapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CoursePaperID,CoursePaper_No,CourseName,StaffID,User_Type")] CoursePaper coursePaper)
        {
            if (id != coursePaper.CoursePaperID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursePaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursePaperExists(coursePaper.CoursePaperID))
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
            ViewData["StaffID"] = new SelectList(_context.Staff, "UserID", "UserID", coursePaper.StaffID);
            return View(coursePaper);
        }

        // GET: CoursePapers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursePaper = await _context.CoursePapers
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(m => m.CoursePaperID == id);
            if (coursePaper == null)
            {
                return NotFound();
            }

            return View(coursePaper);
        }

        // POST: CoursePapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coursePaper = await _context.CoursePapers.FindAsync(id);
            _context.CoursePapers.Remove(coursePaper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursePaperExists(string id)
        {
            return _context.CoursePapers.Any(e => e.CoursePaperID == id);
        }
    }
}
