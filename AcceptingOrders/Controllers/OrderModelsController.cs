using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcceptingOrders.Data.Context;
using AcceptingOrders.Models;
using Dadata;
using Dadata.Model;

namespace AcceptingOrders.Controllers
{
    public class OrderModelsController : Controller
    {
        private readonly AcceptingOrdersDbContext _context;
        private static CleanClient _cleanClient = new("491bad81fdc4febee92a3339f0f8c4917405b0ed", "c2af29002683f8c344a7887c5b60ca0696d3b84b");



        public OrderModelsController(AcceptingOrdersDbContext context) =>_context = context;
        


        public async Task<IActionResult> Index() => _context.Order != null ? 
            View(await _context.Order.ToListAsync()) : Problem("Entity set 'AcceptingOrdersDbContext.Order'  is null.");
        


        public IActionResult Create() => View();



        public OrderModel CheckAddress(OrderModel order)
        {
            Address senderAddress    = _cleanClient.Clean<Address>(order.SenderAddress);
            Address addresseeAddress = _cleanClient.Clean<Address>(order.AddresseeAddress);

            if ((senderAddress.city == null && senderAddress.region == null) || senderAddress.street == null || senderAddress.house == null)
                ModelState.AddModelError("SenderAddress", "Неверно введен адресс!");

            if ((addresseeAddress.city == null && addresseeAddress.region == null) || addresseeAddress.street == null || addresseeAddress.house == null)
                ModelState.AddModelError("AddresseeAddress", "Неверно введен адресс!");

            if (ModelState.ErrorCount == 0)
            {
                order.SenderAddress = senderAddress.city != null ? $"г. {senderAddress.city}, ул. {senderAddress.street}, д. {senderAddress.house}"
                    : $"г. {senderAddress.region}, ул. {senderAddress.street}, д. {senderAddress.house}";
                order.AddresseeAddress = addresseeAddress.city != null ? $"г. {addresseeAddress.city}, ул. {addresseeAddress.street}, д. {addresseeAddress.house}"
                    : $"г. {addresseeAddress.region}, ул. {addresseeAddress.street}, д. {addresseeAddress.house}";
            }

            return order;
        }



        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmed([Bind("Id,Weight,Date,SenderAddress,AddresseeAddress")] OrderModel order)
        {
            if (ModelState.IsValid)
            {
                CheckAddress(order);
                
                if (ModelState.ErrorCount != 0)
                    return View(order);

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
        public async Task<IActionResult> EditConfirmed(int id, [Bind("Id,Weight,Date,SenderAddress,AddresseeAddress")] OrderModel order)
        {
            if (id != order.Id) return NotFound();

            if (ModelState.IsValid)
            {
                CheckAddress(order);

                if (ModelState.ErrorCount != 0)
                    return View(order);

                try
                {
                    _context.Update(order);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if ((!_context.Order?.Any(order => order.Id == order.Id)).GetValueOrDefault()) return NotFound();
                    else throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(order);
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

            if (orderModel != null) _context.Order.Remove(orderModel);
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}