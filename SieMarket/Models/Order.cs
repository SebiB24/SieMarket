namespace SieMarket.Models
{
    public class Order
    {
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order(string customerName, List<OrderItem> items)
        {
            this.CustomerName = customerName;
            this.Items = items;
        }
        public Order(string customerName)
        {
            this.CustomerName = customerName;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.ItemPrice * item.ItemQuantity;
            }
            if (totalPrice > 500m)
            {
                totalPrice *= 0.9m; 
            }
            return totalPrice;
        }
    }
}