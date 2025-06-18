namespace Ex41;

public class PayPalProcessor : IPaymentProcessor
{
    public string Type => "PayPal";

    public void Process(Order order)
    {
        Console.WriteLine($"Processando PayPal: R$ {order.Total}");
        // lógica de PayPal...
    }
}
