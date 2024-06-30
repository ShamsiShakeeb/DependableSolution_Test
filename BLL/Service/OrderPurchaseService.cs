using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class OrderPurchaseService : IOrderPurchaseService
    {
        private readonly IPurchaseOrderContext _purchaseOrderContext;
        public OrderPurchaseService(IPurchaseOrderContext purchaseOrderContext)
        {
            _purchaseOrderContext = purchaseOrderContext;
        }

        public (string? message, string? errorMessage) SaveOrder(Order order , List<Qunantity> qunantities)
        {
            var query = _purchaseOrderContext.SqlReadScalerValue<string>(
                string.Format(@"EXEC InsertOrder @Id = {0}, 
                @RefId='{1}', 
                @PONO = '{2}', 
                @PODate = '{3}' , 
                @Supplier = '{4}', 
                @ExpectedDate='{5}',
                @Remarks='{6}'", order.Id,order.RefId,order.PONO,order.PODATE,order.Supplier,order.ExpectedDate,order.Remarks));

            if (query.Data != "Data Inserted Successfully")
                return (query.Data, query.Data);
            
             var res = _purchaseOrderContext.SqlBulkUpload(qunantities, "Quantity");

            if (!res.success)
                return (res.message,res.errorMessage);

            
             var mapping = new List<Order_Quantity>();

             foreach(var q in qunantities)
             {
                 var map = new Order_Quantity()
                 {
                     OrderId = order.Id,
                     QuantityId = q.Id
                 };
                 mapping.Add(map);
             }
             var mapOperation = _purchaseOrderContext.SqlBulkUpload(mapping, "Order_Quantity");

            if (!mapOperation.success)
                return(mapOperation.message, mapOperation.errorMessage);

            return (query.Data, null);
         
        }
        public (string? message, string? errorMessage) UpdateOrder(Order order, List<Qunantity> qunantities)
        {
            var query = _purchaseOrderContext.SqlReadScalerValue<string>(
                string.Format(@"EXEC UpdateOrder @Id = {0}, 
                @RefId='{1}', 
                @PONO = '{2}', 
                @PODate = '{3}' , 
                @Supplier = '{4}', 
                @ExpectedDate='{5}',
                @Remarks='{6}'", order.Id, order.RefId, order.PONO, order.PODATE, order.Supplier, order.ExpectedDate, order.Remarks));

            if (query.Data.ToUpper().Contains("NOT"))
                return (query.Data, query.Data);

            var res = _purchaseOrderContext.SqlBulkUpload(qunantities, "Quantity");

            if (!res.success)
                return (res.message, res.errorMessage);


            var mapping = new List<Order_Quantity>();

            foreach (var q in qunantities)
            {
                var map = new Order_Quantity()
                {
                    OrderId = order.Id,
                    QuantityId = q.Id
                };
                mapping.Add(map);
            }
            var mapOperation = _purchaseOrderContext.SqlBulkUpload(mapping, "Order_Quantity");

            if (!mapOperation.success)
                return (mapOperation.message, mapOperation.errorMessage);

            return (query.Data, null);

        }
        public (int OrderId , int QuantityId) GetLatestIds()
        {
            var OrderId = _purchaseOrderContext.SqlReadScalerValue<int?>(@"EXEC GetLatestOrderId").Data;
            var QuantityId = _purchaseOrderContext.SqlReadScalerValue<int?>(@"EXEC GetLatestQuantityId").Data;
            return (OrderId == null ? 0 : Convert.ToInt32(OrderId), QuantityId == null ? 0 : Convert.ToInt32(QuantityId));
            
        }
        public void DeleteOrderInfo(int orderId)
        {
            _purchaseOrderContext.SqlRead<string>(string.Format("EXEC DeleteOrderInfo @OrderId = {0}", orderId));
        }
       
    }
}
