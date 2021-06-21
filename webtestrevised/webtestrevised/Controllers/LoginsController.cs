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
    public class LoginsController : Controller
    {
        private readonly GymContext _context;

        public LoginsController(GymContext context)
        {
            _context = context;
        }

        // GET: Logins
        public async Task<IActionResult> Index(string sortOrder)
        {
           
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : " ";
            var gymContext = _context.Logins.Include(l => l.Client).Include(l => l.CoursePaper).Include(l => l.User);

            var logs = from s in gymContext
                           select s;
            switch (sortOrder)
            {

                case "date_desc":
                    logs = logs.OrderBy(s => s.LoginTime);
                    break;
                default:
                    logs = logs.OrderByDescending(s => s.LoginTime);
                    break;
              
            }
            return View(await logs.AsNoTracking().ToListAsync());
            //return View(await gymContext.ToListAsync());
        }

        // GET: Logins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Client)
                .Include(l => l.CoursePaper)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoginID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FullName");
            ViewData["CoursePaperID"] = new SelectList(_context.CoursePapers, "CoursePaperID", "CourseName");
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FullName");
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginID,UserID,Has_Client,Has_CoursePaper,ClientID,CoursePaperID")] Login login)
        {
            if (ModelState.IsValid)
            {
                login.LoginTime = DateTime.Now;
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", login.ClientID);
            ViewData["CoursePaperID"] = new SelectList(_context.CoursePapers, "CoursePaperID", "CoursePaperID", login.CoursePaperID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", login.UserID);
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", login.ClientID);
            ViewData["CoursePaperID"] = new SelectList(_context.CoursePapers, "CoursePaperID", "CoursePaperID", login.CoursePaperID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", login.UserID);
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LoginID,LoginTime,UserID,Has_Client,Has_CoursePaper,ClientID,CoursePaperID")] Login login)
        {
            if (id != login.LoginID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.LoginID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", login.ClientID);
            ViewData["CoursePaperID"] = new SelectList(_context.CoursePapers, "CoursePaperID", "CoursePaperID", login.CoursePaperID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "UserID", login.UserID);
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Logins
                .Include(l => l.Client)
                .Include(l => l.CoursePaper)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LoginID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var login = await _context.Logins.FindAsync(id);
            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(string id)
        {
            return _context.Logins.Any(e => e.LoginID == id);
        }
    }
}
