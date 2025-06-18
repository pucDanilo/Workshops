public class EmployeeRepository 
{
    public Employee[] GetEmployees() => new[]
    {
        new Employee("Alice", 3000m),
        new Employee("Bob", 4500m),
        new Employee("Carol", 2000m)
    };
}
