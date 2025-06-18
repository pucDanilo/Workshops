using Ex40.Models;
using System.Text.RegularExpressions;

public class Employee
{
    public string Name { get; }
    public decimal Salary { get; }
    internal IIncomeTax Tax { get; }

    public Employee(string name, decimal salary)
    {
        this.Name = name;
        this.Salary = salary;
        this.Tax = IncomeTaxFactory.GetTax(salary);
    }

    public decimal CalculateNetSalary()
    {
        decimal deducted = this.Salary - Tax.Apply(this.Salary);
        decimal bonus = new PerformanceBonus().Calculate(this.Salary);
        return deducted + bonus;
    }
}