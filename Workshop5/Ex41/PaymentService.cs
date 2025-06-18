using Ex41.Interfaces;

namespace Ex41;

public class PaymentService : IPaymentService
{
    private readonly Dictionary<string, IPaymentProcessor> _processors;

    public PaymentService(IEnumerable<IPaymentProcessor> processors)
    {
        _processors = processors.ToDictionary(p => p.Type, p => p);
    }

    public void ProcessPayment(Order order, string type)
    {
        if (_processors.TryGetValue(type, out var processor))
        {
            processor.Process(order);
        }
        else
        {
            throw new ArgumentException("Tipo de pagamento não suportado");
        }
    }
}
