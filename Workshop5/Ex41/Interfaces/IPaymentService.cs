namespace Ex41.Interfaces;

public interface IPaymentService
{
    void ProcessPayment(Order order, string type);
}
