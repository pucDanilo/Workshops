namespace Ex41;

public class CreditCardProcessor : IPaymentProcessor
{
    public string Type => "CreditCard";

    public void Process(Order order)
    {
        Console.WriteLine($"Processando cartão de crédito: R$ {order.Total}");
        // lógica de cartão...
    }
}
