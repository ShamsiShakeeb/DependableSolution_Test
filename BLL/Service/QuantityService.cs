using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class QuantityService : IQuantityService
    {
        private readonly IPurchaseOrderContext _purchaseOrderContext;
        public QuantityService(IPurchaseOrderContext purchaseOrderContext)
        {
            _purchaseOrderContext = purchaseOrderContext;
        }
        public List<Qunantity>? GetQuantityItemByOrderId(int orderId)
        {
            var data = _purchaseOrderContext.SqlRead<List<Qunantity>>(string.Format("EXEC GetQuantityItemByOrderId @OrderId = {0}",orderId)).Data;
            return data;
        }

        public void DeletePreviousQty(int orderId)
        {
            _purchaseOrderContext.SqlReadScalerValue<string>(string.Format("EXEC StoreUpdatedQty @OrderId = {0}", orderId));
        }
    }
}
