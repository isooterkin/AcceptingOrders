using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcceptingOrders.Data.Context;
using AcceptingOrders.Models;

namespace AcceptingOrders.Controllers
{
    public class OrderModelsController : Controller
    {
        private readonly AcceptingOrdersDbContext _context;



        public OrderModelsController(AcceptingOrdersDbContext context) =>_context = context;
        


        public async Task<IActionResult> Index() => _context.Order != null ? 
            View(await _context.Order.ToListAsync()) : Problem("Entity set 'AcceptingOrdersDbContext.Order'  is null.");
        


        public IActionResult Create() => View();



        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("Id,Weight,Date,SenderCity,SenderAddress,AddresseeCity,AddresseeAddress")] OrderModel order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Order == null) return NotFound();

            var orderModel = await _context.Order.FindAsync(id);

            if (orderModel == null) return NotFound();
 
            return View(orderModel);
        }



        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("Id,Weight,Date,SenderCity,SenderAddress,AddresseeCity,AddresseeAddress")] OrderModel orderModel)
        {
            if (id != orderModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ((!_context.Order?.Any(order => order.Id == orderModel.Id)).GetValueOrDefault()) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(orderModel);
        }

        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Order == null) return NotFound();

            var orderModel = await _context.Order.FirstOrDefaultAsync(order => order.Id == id);

            if (orderModel == null) return NotFound();
            
            return View(orderModel);
        }

        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Order == null)
                return Problem("Entity set 'AcceptingOrdersDbContext.Order'  is null.");

            var orderModel = await _context.Order.FindAsync(id);

            if (orderModel != null)
            {
                _context.Order.Remove(orderModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}