namespace Ex41;

public interface IPaymentProcessor
{
    string Type { get; }
    void Process(Order order);
}
