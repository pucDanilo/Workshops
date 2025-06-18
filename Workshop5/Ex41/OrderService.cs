using System;

namespace Ex41;

public class OrderService
{
    private PaymentService _payment = new PaymentService();
    private NotificationService _notifier = new NotificationService();
    private ReportGenerator _reporter = new ReportGenerator();

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