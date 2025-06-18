namespace Ex41.Interfaces;

public interface IOrderService
{
    void ProcessOrder(Order order, string paymentType);
}