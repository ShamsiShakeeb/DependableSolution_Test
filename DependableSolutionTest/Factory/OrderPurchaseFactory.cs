using BLL.Service;
using DependableSolutionTest.ViewModel;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Utility.Excel;

namespace DependableSolutionTest.Factory
{
    public class OrderPurchaseFactory : IOrderPurchaseFactory
    {
        private readonly IOrderPurchaseService _orderPurchaseService;
        private readonly IOrderService _orderService;
        private readonly IQuantityService _quantityService;
        private readonly IExcelServiceUtility _excelServiceUtility;
        public OrderPurchaseFactory(IOrderPurchaseService orderPurchaseService,
            IOrderService orderService,
            IQuantityService quantityService,
            IExcelServiceUtility excelServiceUtility)
        {
            _orderPurchaseService = orderPurchaseService;
            _orderService = orderService;
            _quantityService = quantityService;
            _excelServiceUtility = excelServiceUtility;
        }

        public (string message, string errorMessage) SaveOrderPurchase(OrderViewModel orderViewModel)
        {

            if (orderViewModel.Id != null)
            {
                _quantityService.DeletePreviousQty(Convert.ToInt32(orderViewModel.Id));
            }


            var latestRefId = _orderService.GetLatestRefId();

            if (orderViewModel.Id == null && Convert.ToInt32(latestRefId) > Convert.ToInt32(orderViewModel.RefId) )
            {
                return ("RefId Must be Equal or More Then " + latestRefId, "RefId Validation Error");
            }

            var ids = _orderPurchaseService.GetLatestIds();
            var orderId = ids.OrderId;
            var order = new Order()
            {
                Id = orderViewModel.Id == null ? orderId + 1: Convert.ToInt32(orderViewModel.Id),
                RefId = orderViewModel.RefId,
                Remarks = orderViewModel.Remarks,
                ExpectedDate = orderViewModel.ExpectedDate,
                PODATE = orderViewModel.PODATE,
                PONO = orderViewModel.PONO,
                Supplier = orderViewModel.Supplier
            };

            var qtyies = new List<Qunantity>();

            for(int i=0;i<orderViewModel.QuantityItems.Count(); i++)
            {
                var qunatity = new Qunantity()
                {
                    Id = ids.QuantityId + i + 1,
                    ItemName = orderViewModel.QuantityItems[i].Item,
                    Qty = orderViewModel.QuantityItems[i].Qty,
                    Rate = orderViewModel.QuantityItems[i].Rate
                };
                qtyies.Add(qunatity);   
            }

            if(orderViewModel.Id != null)
            {
                var update = _orderPurchaseService.UpdateOrder(order, qtyies);
                return (update.message, update.errorMessage);
            }

            var res = _orderPurchaseService.SaveOrder(order, qtyies);

            return (res.message, res.errorMessage);
        }
        public string LatestGetRefId()
        {
            return _orderService.GetLatestRefId();
        }
        public OrderListViewModel GetOrderList(string search , int page)
        {
            var data = _orderService.GetOrderList(search==null?search:search.Trim(),page);
            var count = _orderService.GetOrdersCounter(search == null ? search : search.Trim());
            var model = new OrderListViewModel();
            model.Orders = data;
            model.Count = count;
            return model;
        }
        public OrderQuantities GetOrderInfoById(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (!order.success)
                throw new Exception("Order Not Found");

            var quantities = _quantityService.GetQuantityItemByOrderId(orderId);
            var model = new OrderQuantities();
            model.Order = order.order;
            model.Qunantities = quantities;
            return model;

        }
        public void DeleteOrderInfo(int orderId)
        {
            _orderPurchaseService.DeleteOrderInfo(orderId);
        }
        public byte[] ExportQuantityExcel(int orderId)
        {
            var qunantities = _quantityService.GetQuantityItemByOrderId(orderId);
            var order =_orderService.GetOrderById(orderId).order;
            List<Order> orders = new List<Order>() { order};
            List<string> header1 = new List<string>() { "Id", "Ref Id", "PO NO", "PO DATE", "Supplier", "Expected Date", "Remarks" };
            List<string> header2 = new List<string>() { "Id", "Item Name", "Quantity", "Rate" };
            var base64String = _excelServiceUtility.ListToExcelBase64("Sheet1", header1, header2, orders, qunantities).base64;
            return Convert.FromBase64String(base64String);
        }
    }
}
