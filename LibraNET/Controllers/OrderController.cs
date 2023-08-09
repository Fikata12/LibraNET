using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraNET.Controllers
{
	public class OrderController : BaseController
	{
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
    }
}
