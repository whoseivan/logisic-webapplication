using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticApp.Data;
using LogisticApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace LogisticApp.Controllers
{
    [Authorize(Roles = "logist")]
    public class LogisticianController : Controller
    {
        private readonly AppDbContext _context;

        public LogisticianController(AppDbContext context)
        {
            _context = context;
        }

        // Метод для отображения панели управления водителя
        public IActionResult LogisticianDashboard()
        {
            return View();
        }

        // GET: Logistician
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logisticians.ToListAsync());
        }

        // GET: Logistician/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistician = await _context.Logisticians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logistician == null)
            {
                return NotFound();
            }

            return View(logistician);
        }

        // GET: Logistician/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logistician/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,MiddleName,BirthDate,Passport,PhoneNumber,Address,Email")] Logistician logistician)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logistician);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logistician);
        }

        // GET: Logistician/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistician = await _context.Logisticians.FindAsync(id);
            if (logistician == null)
            {
                return NotFound();
            }
            return View(logistician);
        }

        // POST: Logistician/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,MiddleName,BirthDate,Passport,PhoneNumber,Address,Email")] Logistician logistician)
        {
            if (id != logistician.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logistician);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogisticianExists(logistician.Id))
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
            return View(logistician);
        }

        // GET: Logistician/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logistician = await _context.Logisticians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logistician == null)
            {
                return NotFound();
            }

            return View(logistician);
        }

        // POST: Logistician/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logistician = await _context.Logisticians.FindAsync(id);
            if (logistician != null)
            {
                _context.Logisticians.Remove(logistician);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogisticianExists(int id)
        {
            return _context.Logisticians.Any(e => e.Id == id);
        }
    }
}
