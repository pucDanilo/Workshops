using Ex41;

var cart = new ShoppingCart();
cart.AddItem("Notebook", 2500m);
cart.AddItem("Mouse", 150m);

var order = new Order { Items = cart.Items };

// Corrected instantiation of OrderService with required parameters
var paymentProcessors = new List<IPaymentProcessor>
{
   new CreditCardProcessor(),
   new PayPalProcessor()
};
var paymentService = new PaymentService(paymentProcessors);

var notificationService = new NotificationService();
var reportGenerator = new ReportGenerator();
var service = new OrderService(paymentService, notificationService, reportGenerator);

service.ProcessOrder(order, paymentType: "CreditCard");

Console.WriteLine("Pedido concluído. Pressione qualquer tecla...");
Console.ReadKey();