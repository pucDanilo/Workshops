using Ex40;

var employees = new[]
{
   new Employee("Alice", 3000m),
   new Employee("Bob", 4500m),
   new Employee("Carol", 2000m)
};

var processor = new PayrollProcessor();

foreach (var employee in employees)
{
    processor.Process(employee);
    Console.WriteLine();
}

Console.WriteLine("Processamento concluído. Pressione qualquer tecla...");
Console.ReadKey();

public record Employee(string Name, decimal Salary);

public class PayrollProcessor
{
    public void Process(Employee employee)
    {
        Console.WriteLine($"Processando pagamento para {employee.Name} com salário de {employee.Salary:C}");
        // Adicione lógica de processamento aqui
    }
}