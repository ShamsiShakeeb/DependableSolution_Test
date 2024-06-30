using Entity;

namespace BLL.Service
{
    public interface IOrderPurchaseService
    {
        (string? message, string? errorMessage) SaveOrder(Order order, List<Qunantity> qunantities);
        (string? message, string? errorMessage) UpdateOrder(Order order, List<Qunantity> qunantities);
        (int OrderId, int QuantityId) GetLatestIds();
        void DeleteOrderInfo(int orderId);
    }
}
