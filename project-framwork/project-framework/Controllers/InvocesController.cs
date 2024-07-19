using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project_framework.Data;
using project_framework.Models;

namespace project_framework.Controllers
{
    public class InvocesController : Controller
    {
        private readonly project_frameworkContext _context;

        public InvocesController(project_frameworkContext context)
        {
            _context = context;
        }

        // GET: Invoces
        public async Task<IActionResult> Index()
        {
            var project_frameworkContext = _context.Invoce.Include(i => i.Order);
            return View(await project_frameworkContext.ToListAsync());
        }

        // GET: Invoces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoce = await _context.Invoce
                .Include(i => i.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoce == null)
            {
                return NotFound();
            }

            return View(invoce);
        }

        // GET: Invoces/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id");
            return View();
        }

        // POST: Invoces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,Amount")] Invoce invoce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", invoce.OrderId);
            return View(invoce);
        }

        // GET: Invoces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoce = await _context.Invoce.FindAsync(id);
            if (invoce == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", invoce.OrderId);
            return View(invoce);
        }

        // POST: Invoces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,Amount")] Invoce invoce)
        {
            if (id != invoce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoceExists(invoce.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", invoce.OrderId);
            return View(invoce);
        }

        // GET: Invoces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoce = await _context.Invoce
                .Include(i => i.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoce == null)
            {
                return NotFound();
            }

            return View(invoce);
        }

        // POST: Invoces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoce = await _context.Invoce.FindAsync(id);
            if (invoce != null)
            {
                _context.Invoce.Remove(invoce);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoceExists(int id)
        {
            return _context.Invoce.Any(e => e.Id == id);
        }
    }
}
