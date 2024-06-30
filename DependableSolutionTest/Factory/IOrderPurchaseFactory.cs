using DependableSolutionTest.ViewModel;
using Entity;

namespace DependableSolutionTest.Factory
{
    public interface IOrderPurchaseFactory
    {
        (string message, string errorMessage) SaveOrderPurchase(OrderViewModel orderViewModel);
        string LatestGetRefId();
        OrderListViewModel GetOrderList(string search, int page);
        OrderQuantities GetOrderInfoById(int orderId);
        void DeleteOrderInfo(int orderId);
        byte[] ExportQuantityExcel(int orderId);
    }
}
