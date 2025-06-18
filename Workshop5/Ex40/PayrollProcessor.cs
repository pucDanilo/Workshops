using System;

namespace Ex40;

public class PayrollProcessor
    {
        private Logger _logger = new Logger();
        private SalaryCalculator _calculator = new SalaryCalculator();
        private NotificationService _notifier = new NotificationService();
        private CurrencyConverter _converter = new CurrencyConverter();

        public void Process(string employeeName, decimal baseSalary)
        {
            // Log de início
            Console.WriteLine($"[{DateTime.Now}] Iniciando processamento de {employeeName}");
            // Cálculo
            decimal net = _calculator.CalculateNetSalary(baseSalary);
            // Log de resultado
            Console.WriteLine($"[{DateTime.Now}] Salário líquido de {employeeName}: {net}");
            
            // Conversão NÃO utilizada hoje
            decimal inDollars = _converter.ToUSD(net, "BRL");
            Console.WriteLine($"[{DateTime.Now}] (Em dólares: {inDollars})");

            // Notificações previstas, mas não usadas
            _notifier.SendEmail(employeeName, net);
            _notifier.SendSms(employeeName, net);

            // Log de fim
            Console.WriteLine($"[{DateTime.Now}] Finalizado processamento de {employeeName}");
        }
    }
