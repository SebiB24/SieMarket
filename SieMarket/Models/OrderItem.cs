namespace SieMarket.Models
{
    public class OrderItem
    {
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }

        public OrderItem(string itemName, int itemQuantity, decimal itemPrice)
        {
            this.ItemName = itemName;
            this.ItemQuantity = itemQuantity;
            this.ItemPrice = itemPrice;
        }
    }
}