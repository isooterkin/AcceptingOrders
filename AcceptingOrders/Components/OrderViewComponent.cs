using AcceptingOrders.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcceptingOrders.Components
{
    [ViewComponent]
    public class OrderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OrderModel order) => View(order);
    }
}