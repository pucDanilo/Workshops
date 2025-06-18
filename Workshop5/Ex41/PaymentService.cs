using System;

namespace Ex41;

public class PaymentService
{
    public void ProcessPayment(Order order, string type)
    {
        if (type == "CreditCard")
        {
            Console.WriteLine($"Processando cartão de crédito: R$ {order.Total}");
            // lógica de cartão...
        }
        else if (type == "PayPal")
        {
            Console.WriteLine($"Processando PayPal: R$ {order.Total}");
            // lógica de PayPal...
        }
        else if (type == "Bitcoin")
        {
            Console.WriteLine($"Processando Bitcoin: R$ {order.Total}");
            // lógica de Bitcoin...
        }
        else
        {
            throw new ArgumentException("Tipo de pagamento não suportado");
        }
    }
}