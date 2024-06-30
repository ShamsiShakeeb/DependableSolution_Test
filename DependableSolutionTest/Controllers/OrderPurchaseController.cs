using DependableSolutionTest.Factory;
using DependableSolutionTest.ViewModel;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace DependableSolutionTest.Controllers
{
    public class OrderPurchaseController : Controller
    {
        private readonly IOrderPurchaseFactory _orderPurchaseFactory;
        public OrderPurchaseController(IOrderPurchaseFactory orderPurchaseFactory)
        {
            _orderPurchaseFactory = orderPurchaseFactory;
        }
        public IActionResult Entry()
        {
            ViewBag.RefId = _orderPurchaseFactory.LatestGetRefId();
            return View();
        }
        public IActionResult OrderList(string search = null , int page = 0)
        {
            var orderListModel = _orderPurchaseFactory.GetOrderList(search,page);
            ViewBag.Search = search;
            return View(orderListModel);
        }

        [Route("OrderPurchaseController/SavePurchaseOrder")]
        [HttpPost]
        public IActionResult SavePurchaseOrder([FromBody]OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errorMessage = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .FirstOrDefault();
                return BadRequest(new { message = "Validation Error: "+errorMessage});
            }

            var res = _orderPurchaseFactory.SaveOrderPurchase(orderViewModel);    

            return Ok(new { message = res.message});
        }

        [Route("OrderPurchase/Edit/{orderId}")]
        public IActionResult Edit(int orderId)
        {
            var data = _orderPurchaseFactory.GetOrderInfoById(orderId).Order;
            return View(data);
        }

        [Route("OrderPurchaseController/Details")]
        [HttpGet]
        public IActionResult Details(int orderId)
        {
            var data = _orderPurchaseFactory.GetOrderInfoById(orderId);
            return Ok(data);
        }
        [Route("OrderPurchase/DeleteOrder/{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            _orderPurchaseFactory.DeleteOrderInfo(orderId);
            return RedirectToAction(controllerName: "OrderPurchase", actionName: "OrderList");
        }

        [Route("OrderPurchase/ExportQuantity/{orderId}")]
        public IActionResult ExportQuantity(int orderId)
        {
            var data = _orderPurchaseFactory.ExportQuantityExcel(orderId);
            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "export.xlsx");
        }
    }
}
