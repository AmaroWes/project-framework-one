using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aluroni.Data;
using Aluroni.Models;

namespace Aluroni.Controllers
{
    public class InvocesController : Controller
    {
        private readonly AluroniContext _context;

        public InvocesController(AluroniContext context)
        {
            _context = context;
        }

        // GET: Invoces
        public async Task<IActionResult> Index()
        {
            var aluroniContext = _context.Invoce.Include(i => i.Client).Include(r => r.Deliveryman);
            return View(await aluroniContext.ToListAsync());
        }

        // GET: Invoces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoce = await _context.Invoce
                .Include(i => i.Client)
                .Include(r => r.Deliveryman)
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            ViewData["DeliverymanId"] = new SelectList(_context.Deliveryman, "Id", "Name");
            return View();
        }

        // POST: Invoces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,DeliverymanId,Bill")] Invoce invoce)
        {
            var deliveryRate = _context.Deliveryman.Where(r => r.Id == invoce.DeliverymanId).FirstOrDefault();
            invoce.Amount = PriceCalculator(invoce.ClientId, invoce.Bill, deliveryRate.PaymentRate);
            _context.Add(invoce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", invoce.ClientId);
            ViewData["DeliverymanId"] = new SelectList(_context.Deliveryman, "Id", "Name", invoce.DeliverymanId);
            return View(invoce);
        }

        // POST: Invoces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,DeliverymanId,Bill,Amount")] Invoce invoce)
        {
            if (id != invoce.Id)
            {
                return NotFound();
            }
            try
            {
                if (!BillExist(invoce.Bill))
                {
                    ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", invoce.ClientId);
                    ViewData["DeliverymanId"] = new SelectList(_context.Deliveryman, "Id", "Name", invoce.DeliverymanId);
                    return View(invoce);
                }
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

        // GET: Invoces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoce = await _context.Invoce
                .Include(i => i.Client)
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

        public double PriceCalculator(int id, string bill, double deliveryman)
        {
            var orders = _context.Order.Where(o => o.ClientId == id && o.Bill == bill);
            var dishes = _context.Dish;
            double price = 0;

            foreach (var order in orders)
            {
                foreach (var dish in dishes)
                {
                    if (order.DishId == dish.Id)
                    {
                        price = price + dish.Price;
                    }
                }
            }

            return price + deliveryman;
        }

        public bool BillExist(string bill)
        {
            var orders = _context.Order.Where(o => bill == o.Bill).FirstOrDefault();
            if (orders == null)
            {
                return false;
            }
            return true;
        }
    }
}
