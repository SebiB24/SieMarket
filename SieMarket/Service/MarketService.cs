namespace SieMarket.Service
{
    public class MarketService
    {
        private List<Order> orders = new List<Order>();

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
                .Select(group => new { CustomerName = group.Key, TotalSpent = group.Sum(order => order.GetTotalPrice()) })
                .OrderByDescending(x => x.TotalSpent)
                .FirstOrDefault();
        }
    }
}