using SieMarket.Models;

namespace SieMarket.Services
{
    public class MarketService
    {
        private List<Order> Orders = new List<Order>();

        public MarketService()
        {
        }

        public MarketService(List<Order> orders)
        {
            this.Orders = orders;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public string GetBiggestSpender()
        {
            if (Orders.Count == 0)
            {
                return "No orders available.";
            }

            return Orders.GroupBy(order => order.CustomerName)
                .Select(group => new { customerName = group.Key, TotalSpent = group.Sum(order => order.GetTotalPrice()) })
                .OrderByDescending(x => x.TotalSpent)
                .FirstOrDefault()?.customerName ?? "No customers found.";
        }

        public Dictionary<string, int> GetMostPopularItems(int count)
        {
            return Orders.SelectMany(order => order.Items)
                .GroupBy(item => item.ItemName)
                .Select(group => new { ItemName = group.Key, Quantity = group.Sum(item => item.ItemQuantity) })
                .OrderByDescending(x => x.Quantity)
                .Take(count)
                .ToDictionary(x => x.ItemName, x => x.Quantity);
        }

    }
}