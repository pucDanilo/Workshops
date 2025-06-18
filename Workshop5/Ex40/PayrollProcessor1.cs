public class PayrollProcessor
{
    private EmployeeRepository rep; 

    public PayrollProcessor(EmployeeRepository rep)
    {
        this.rep = rep;
    }

    public void Process(Employee employee)
    {
        Console.WriteLine($"Processando pagamento para {employee.Name} com salário de {employee.Salary:C}");
        // Adicione lógica de processamento aqui
    }

    internal void ProcessAllEmployees()
    {
        var employees = rep.GetEmployees();

        foreach (var employee in employees)
        {
            Process(employee);
            Console.WriteLine();
        }

    }
}