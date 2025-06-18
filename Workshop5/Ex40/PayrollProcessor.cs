using Ex40.Models;
using Ex40.Services;

namespace Ex40;

public class PayrollProcessor
{
    private Logger _logger = new Logger();
    private NotificationService _notifier = new NotificationService();
    private CurrencyConverter _converter = new CurrencyConverter();

    public void Process(Employee employee)
    {
        _logger.LogInfo($"Iniciando processamento de {employee.Name}");

        decimal net = employee.CalculateNetSalary();
        _logger.LogInfo($"Salário líquido de {employee.Name}: {net}");

        decimal inDollars = _converter.ToUSD(net, "BRL");
        _logger.LogInfo($"(Em dólares: {inDollars})");

        SendNotifications(employee.Name, net);
        _logger.LogInfo($"Finalizado processamento de {employee.Name}");
    }

    private void SendNotifications(string employeeName, decimal net)
    {
        _notifier.SendEmail(employeeName, net);
        _notifier.SendSms(employeeName, net);
    }
}