using SieMarket.Models;
using SieMarket.Services;

Order order1 = new Order("Alice");
order1.items.Add(new OrderItem("Laptop", 1, 1000m));
order1.items.Add(new OrderItem("Mouse", 2, 25m)); 


Order order2 = new Order("Bob", new List<OrderItem>
{
    new OrderItem("Smartphone", 1, 600m),
    new OrderItem("Headphones", 2, 150m)
});

Order order3 = new Order("Alice");
order3.items.Add(new OrderItem("USB Cable", 3, 10m));

Order order4 = new Order("Charlie");
order4.items.Add(new OrderItem("Laptop", 2, 1000m));

List<Order> orders = new List<Order> { order1, order2, order3, order4 };

Console.WriteLine("------ Orders ------");
foreach (var order in orders)
{
    Console.WriteLine($"Customer name: {order.customerName} | Total Price: {order.GetTotalPrice():C}");
}


Console.WriteLine("------ Biggest Spender ------");

MarketService marketService = new MarketService(orders);
Console.WriteLine($"Biggest spender: {marketService.GetBiggestSpender()}");

Console.WriteLine("------ Most Popular Items ------");
var popularItems = marketService.GetMostPopularItems(3);
foreach (var item in popularItems)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}