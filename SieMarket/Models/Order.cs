namespace SieMarket.Models
{
    public class Order
    {
        public string customerName { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();

        public Order(string customerName, List<OrderItem> items)
        {
            this.customerName = customerName;
            this.items = items;
        }
        public Order(string customerName)
        {
            this.customerName = customerName;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.itemPrice * item.itemQuantity;
            }
            if (totalPrice > 500m)
            {
                totalPrice *= 0.9m; 
            }
            return totalPrice;
        }
    }
}