**Exercício de Refatoração: Aplicando DRY, KISS e YAGNI**

------

### 🏗️ Estrutura do Projeto

```
PayrollApp/
│
├─ Program.cs
├─ PayrollProcessor.cs
├─ Logger.cs
├─ SalaryCalculator.cs
├─ NotificationService.cs
└─ CurrencyConverter.cs
```

------

### 🔍 Código Atual (antes da refatoração)

#### Program.cs

```csharp
using System;

namespace PayrollApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new[] { ("Alice", 3000m), ("Bob", 4500m), ("Carol", 2000m) };
            var processor = new PayrollProcessor();

            foreach (var (name, salary) in employees)
            {
                processor.Process(name, salary);
                Console.WriteLine();
            }

            Console.WriteLine("Processamento concluído. Pressione qualquer tecla...");
            Console.ReadKey();
        }
    }
}
```

#### PayrollProcessor.cs

```csharp
using System;

namespace PayrollApp
{
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
}
```

#### Logger.cs

```csharp
using System;

namespace PayrollApp
{
    public class Logger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"[INFO {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR {DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
    }
}
```

#### SalaryCalculator.cs

```csharp
using System;

namespace PayrollApp
{
    public class SalaryCalculator
    {
        public decimal CalculateNetSalary(decimal gross)
        {
            // Lógica exagerada para uma simples dedução de imposto:
            IIncomeTax tax;
            if (gross <= 2000m)        tax = new LowTax();
            else if (gross <= 4000m)   tax = new MidTax();
            else if (gross <= 8000m)   tax = new HighTax();
            else                       tax = new SuperHighTax();

            decimal deducted = gross - tax.Apply(gross);
            decimal bonus = new PerformanceBonus().Calculate(gross);
            return deducted + bonus;
        }
    }

    interface IIncomeTax { decimal Apply(decimal amount); }
    class LowTax : IIncomeTax    { public decimal Apply(decimal a) => a * 0.08m; }
    class MidTax : IIncomeTax    { public decimal Apply(decimal a) => a * 0.15m; }
    class HighTax : IIncomeTax   { public decimal Apply(decimal a) => a * 0.22m; }
    class SuperHighTax : IIncomeTax { public decimal Apply(decimal a) => a * 0.27m; }

    class PerformanceBonus
    {
        public decimal Calculate(decimal amount)
        {
            // bônus fixo de 5% para todo mundo
            return amount * 0.05m;
        }
    }
}
```

#### NotificationService.cs

```csharp
namespace PayrollApp
{
    public class NotificationService
    {
        public void SendEmail(string user, decimal amount)
        {
            // placeholder: implementação prevista
        }

        public void SendSms(string user, decimal amount)
        {
            // placeholder: implementação prevista
        }

        public void SendPush(string user, decimal amount)
        {
            // placeholder: implementação prevista
        }
    }
}
```

#### CurrencyConverter.cs

```csharp
namespace PayrollApp
{
    public class CurrencyConverter
    {
        // complexidade extra para conversão de moedas
        public decimal ToUSD(decimal amount, string fromCurrency)
        {
            // API externa simulada
            if (fromCurrency == "BRL") return amount / 5.0m;
            if (fromCurrency == "EUR") return amount / 0.9m;
            // ...
            return amount;
        }
    }
}
```

------

### 🎯 Objetivos de Refatoração

1. **DRY**
   - Centralizar toda a geração de logs em uma única classe/utilitário (evitar repetir `Console.WriteLine($"[{DateTime.Now}] …")`).
2. **KISS**
   - Simplificar a lógica de cálculo de salário: talvez não seja necessário tantos níveis de imposto nem classes extras para um exemplo de console.
3. **YAGNI**
   - Remover ou adiar (não deletar completamente) funcionalidades que não estão sendo usadas hoje, como notificações SMS/push e conversão de moeda complexa.

------

### 📝 Tarefas

1. **Identifique** no código acima:
   - Onde o princípio **DRY** está sendo violado.
   - Quais trechos são excessivamente complexos (quebrando **KISS**).
   - Que partes representam trabalho antecipado (violações de **YAGNI**).
2. **Refatore**:
   - Extraia um método ou uma classe de `Log` para agrupar formatação e timestamp.
   - Converta a lógica de cálculo de salário para algo mais direto (linhas mínimas de código que cubram imposto fixo + bônus).
   - Remova (ou comente) todas as referências a `NotificationService.SendSms/SendPush` e `CurrencyConverter`, deixando apenas o que é realmente usado hoje.
3. **Teste** a aplicação refatorada:
   - As saídas no console devem ser idênticas às do código original (exceto as partes deliberadamente removidas).
   - Garanta que os testes manuais (executar com diferentes salários) funcionem sem erro.

------

🔧 **Dica**: Comece criando uma classe `SimpleLogger` com um método `Log(string message)` que já inclua `DateTime.Now`, e substitua todos os `Console.WriteLine` repetidos. Em seguida, simplifique o `SalaryCalculator` para algo como:

```csharp
public decimal CalculateNetSalary(decimal gross)
{
    decimal taxRate = 0.15m;     // alíquota fixa para este exercício
    decimal bonusRate = 0.05m;
    return gross * (1 - taxRate + bonusRate);
}
```

E só então remova os arquivos/classes que não trazem valor imediato.