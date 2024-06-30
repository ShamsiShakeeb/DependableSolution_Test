using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IOrderService
    {
        List<Order>? GetOrderList(string search, int page);
        int GetOrdersCounter(string search);
        string GetLatestRefId();
        (bool success, string? message, Order? order) GetOrderById(int id);
    }
}
