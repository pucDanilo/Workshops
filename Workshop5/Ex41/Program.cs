using Ex41;

var cart = new ShoppingCart();
cart.AddItem("Notebook", 2500m);
cart.AddItem("Mouse", 150m);

var order = new Order { Items = cart.Items };
var service = new OrderService();
service.ProcessOrder(order, paymentType: "CreditCard");

Console.WriteLine("Pedido concluído. Pressione qualquer tecla...");
Console.ReadKey();