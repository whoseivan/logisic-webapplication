using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogisticApp.Data;
using LogisticApp.Models;

namespace LogisticApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Transactions.Include(t => t.Car).Include(t => t.Client).Include(t => t.Driver).Include(t => t.Logistician).Include(t => t.Route);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Car)
                .Include(t => t.Client)
                .Include(t => t.Driver)
                .Include(t => t.Logistician)
                .Include(t => t.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "id", "id");
            ViewData["LogisticianId"] = new SelectList(_context.Logisticians, "Id", "Id");
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id");
            return View();
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteId,CarId,DriverId,LogisticianId,ClientId,TransactionDate")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", transaction.CarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transaction.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "id", "id", transaction.DriverId);
            ViewData["LogisticianId"] = new SelectList(_context.Logisticians, "Id", "Id", transaction.LogisticianId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", transaction.RouteId);
            return View(transaction);
        }

        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", transaction.CarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transaction.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "id", "id", transaction.DriverId);
            ViewData["LogisticianId"] = new SelectList(_context.Logisticians, "Id", "Id", transaction.LogisticianId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", transaction.RouteId);
            return View(transaction);
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RouteId,CarId,DriverId,LogisticianId,ClientId,TransactionDate")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", transaction.CarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transaction.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "id", "id", transaction.DriverId);
            ViewData["LogisticianId"] = new SelectList(_context.Logisticians, "Id", "Id", transaction.LogisticianId);
            ViewData["RouteId"] = new SelectList(_context.Routes, "Id", "Id", transaction.RouteId);
            return View(transaction);
        }

        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transactions
                .Include(t => t.Car)
                .Include(t => t.Client)
                .Include(t => t.Driver)
                .Include(t => t.Logistician)
                .Include(t => t.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
