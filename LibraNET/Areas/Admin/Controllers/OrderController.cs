using LibraNET.Data.Models.Enums;
using LibraNET.Services.Data.Contracts;
using LibraNET.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using static LibraNET.Common.GeneralApplicationConstants;


namespace LibraNET.Areas.Admin.Controllers
{
    public class OrderController : BaseAdminController
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AdminAllOrdersViewModel model)
        {
            var allOrders = await orderService.AllAsync(model);

            model.Orders = await allOrders.ToPagedListAsync(model.CurrentPage, AdminOrdersPerPage);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(OrderDetailsViewModel model)
        {
            try
            {
                if (await orderService.GetByIdAsync(model.Id) == null)
                {
                    return RedirectToAction("All", "Order");
                }

                int[] validValues = (int[])Enum.GetValues(typeof(OrderStatus));

                if (!validValues.Contains(model.NewOrderStatus))
                {
                    return RedirectToAction("All", "Order");
                }

                await orderService.ChangeStatusAsync(model.Id, model.NewOrderStatus);

                return RedirectToAction("All", "Order");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
