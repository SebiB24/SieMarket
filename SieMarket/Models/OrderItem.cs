namespace SieMarket.Models
{
    public class OrderItem
    {
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public decimal itemPrice { get; set; }

        public OrderItem(string itemName, int itemQuantity, decimal itemPrice)
        {
            this.itemName = itemName;
            this.itemQuantity = itemQuantity;
            this.itemPrice = itemPrice;
        }
    }
}