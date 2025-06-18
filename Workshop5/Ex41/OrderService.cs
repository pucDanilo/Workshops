using Ex41.Interfaces;

namespace Ex41;

public class OrderService : IOrderService
{
    private readonly IPaymentService _payment;
    private readonly INotificationService _notifier;
    private readonly IReportGenerator _reporter;

    public OrderService(IPaymentService payment, INotificationService notifier, IReportGenerator reporter)
    {
        _payment = payment;
        _notifier = notifier;
        _reporter = reporter;
    }

    public void ProcessOrder(Order order, string paymentType)
    {
        // 1. Calcula total  
        order.Total = new ShoppingCart { Items = order.Items }.CalculateTotal();
        Console.WriteLine($"Total do pedido: {order.Total}");

        // 2. Processa pagamento  
        _payment.ProcessPayment(order, paymentType);

        // 3. Envia notificação  
        _notifier.Send($"Pedido de R$ {order.Total} confirmado.", type: "Email");

        // 4. Gera relatório  
        _reporter.Generate(order);
    }
}
