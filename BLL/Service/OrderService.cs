using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IPurchaseOrderContext _purchaseOrderContext;
        public OrderService(IPurchaseOrderContext purchaseOrderContext)
        {
            _purchaseOrderContext = purchaseOrderContext;
        }
        public List<Order>? GetOrderList(string search, int page)
        {
            var orderList = _purchaseOrderContext.SqlRead<List<Order>>(string.Format("exec GetOrderList @Search = '{0}' , @page = {1}", search, page == 0 ? 1 : page)).Data;
            if (orderList == null)
            {
                return new List<Order>();
            }
            if (!orderList.Any())
                return new List<Order>();

            return orderList;
        }
        public int GetOrdersCounter(string search)
        {
            var count = _purchaseOrderContext.SqlReadScalerValue<int>(string.Format("exec GetOrderCounts @Search = '{0}'", search)).Data;
            return count;
        }
        public string GetLatestRefId()
        {
            var refId = _purchaseOrderContext.SqlReadScalerValue<string?>("exec GetLatestRefId").Data;
            if (refId == null) return "001";
            return refId;
        }
        public (bool success, string? message, Order? order) GetOrderById(int id)
        {
            var order = _purchaseOrderContext.SqlReadScalerModel<Order>(string.Format("EXEC GetOrderById @OrderId = {0}",id)).Data;
            if(order == null)
            {
                return (false, "Order Not Found",null);
            }
            return (true,"Order Found",order);
        }
    }
}
