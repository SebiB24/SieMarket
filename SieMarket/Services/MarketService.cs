using SieMarket.Models;

namespace SieMarket.Services
{
    public class MarketService
    {
        private List<Order> orders = new List<Order>();

        public MarketService()
        {
        }

        public MarketService(List<Order> orders)
        {
            this.orders = orders;
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public string GetBiggestSpender()
        {
            if (orders.Count == 0)
            {
                return "No orders available.";
            }

            return orders.GroupBy(order => order.customerName)
                .Select(group => new { customerName = group.Key, TotalSpent = group.Sum(order => order.GetTotalPrice()) })
                .OrderByDescending(x => x.TotalSpent)
                .FirstOrDefault()?.customerName ?? "No customers found.";
        }

    }
}