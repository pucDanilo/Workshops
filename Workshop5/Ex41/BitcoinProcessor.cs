namespace Ex41;

public class BitcoinProcessor : IPaymentProcessor
{
    public string Type => "Bitcoin";

    public void Process(Order order)
    {
        Console.WriteLine($"Processando Bitcoin: R$ {order.Total}");
        // lógica de Bitcoin...
    }
}