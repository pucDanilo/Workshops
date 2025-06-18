using System;

namespace Ex41;

 public class ReportGenerator
{
    public void Generate(Order order)
    {
        var report = $"Relatório do pedido:\nTotal: R$ {order.Total}\nItens:\n";
        foreach (var item in order.Items)
            report += $"- {item.Name}: R$ {item.Price}\n";

        Console.WriteLine(report);
        File.WriteAllText("order-report.txt", report);
    }
}