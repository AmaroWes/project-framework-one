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
    public class OrdersController : Controller
    {
        private readonly AluroniContext _context;

        public OrdersController(AluroniContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var aluroniContext = _context.Order.Include(o => o.Client).Include(o => o.Dish);
            return View(await aluroniContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Dish)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,DishId,Bill")] Order order)
        {
            if (!VerifyStock(order.DishId))
            {
                ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
                ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Name");
                return View(order);
            }

            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", order.ClientId);
            ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Name", order.DishId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,DishId,Bill")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }


            try
            {
                if (!VerifyStock(order.DishId))
                {
                    ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
                    ViewData["DishId"] = new SelectList(_context.Dish, "Id", "Name");
                    return View(order);
                }

                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.Id))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Client)
                .Include(o => o.Dish)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }

        public bool VerifyStock(int id)
        {
            var recipe = _context.Recipe.Where(re => id == re.DishId).FirstOrDefault();
            var stockList = _context.Stock.Where(sl =>  sl.Quantity > 0);

            foreach (var s in stockList)
            {
                if (recipe.IngredientId == s.IngredientId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
