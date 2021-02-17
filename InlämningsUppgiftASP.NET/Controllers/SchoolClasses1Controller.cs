using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InlämningsUppgiftASP.NET.Data;
using InlämningsUppgiftASP.NET.Models;
using Microsoft.AspNetCore.Identity;

namespace InlämningsUppgiftASP.NET.Controllers
{
    public class SchoolClasses1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchoolClasses1Controller(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SchoolClasses1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SchoolClasses.Include(s => s.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SchoolClasses1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClasses = await _context.SchoolClasses
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClasses == null)
            {
                return NotFound();
            }

            return View(schoolClasses);
        }

        // GET: SchoolClasses1/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["TeacherId"] = new SelectList(await _userManager.GetUsersInRoleAsync("Teacher"), "Id", "DisplayName");
            return View();
        }

        // POST: SchoolClasses1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,TeacherId")] SchoolClasses schoolClasses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolClasses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Users, "Id", "Id", schoolClasses.TeacherId);
            return View(schoolClasses);
        }

        // GET: SchoolClasses1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClasses = await _context.SchoolClasses.FindAsync(id);
            if (schoolClasses == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(await _userManager.GetUsersInRoleAsync("Teacher"), "Id", "DisplayName");
            return View(schoolClasses);
        }

        // POST: SchoolClasses1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Year,TeacherId")] SchoolClasses schoolClasses)
        {
            if (id != schoolClasses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClasses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassesExists(schoolClasses.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Users, "Id", "Id", schoolClasses.TeacherId);
            return View(schoolClasses);
        }

        // GET: SchoolClasses1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolClasses = await _context.SchoolClasses
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClasses == null)
            {
                return NotFound();
            }

            return View(schoolClasses);
        }

        // POST: SchoolClasses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var schoolClasses = await _context.SchoolClasses.FindAsync(id);
            _context.SchoolClasses.Remove(schoolClasses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassesExists(string id)
        {
            return _context.SchoolClasses.Any(e => e.Id == id);
        }
    }
}
