using System;

namespace Ex40;

public class SalaryCalculator
{
    public decimal CalculateNetSalary(decimal gross)
    {
        IIncomeTax tax = IncomeTaxFactory.GetTax(gross);
        decimal deducted = gross - tax.Apply(gross);
        decimal bonus = new PerformanceBonus().Calculate(gross);
        return deducted + bonus;
    }
}

internal interface IIncomeTax
{
    decimal Apply(decimal amount);
}

internal abstract class IncomeTaxBase : IIncomeTax
{
    protected abstract decimal Rate { get; }

    public decimal Apply(decimal amount) => amount * Rate;
}

internal class LowTax : IncomeTaxBase
{
    protected override decimal Rate => 0.08m;
}

internal class MidTax : IncomeTaxBase
{
    protected override decimal Rate => 0.15m;
}

internal class HighTax : IncomeTaxBase
{
    protected override decimal Rate => 0.22m;
}

internal class SuperHighTax : IncomeTaxBase
{
    protected override decimal Rate => 0.27m;
}

internal static class IncomeTaxFactory
{
    public static IIncomeTax GetTax(decimal gross) => gross switch
    {
        <= 2000m => new LowTax(),
        <= 4000m => new MidTax(),
        <= 8000m => new HighTax(),
        _ => new SuperHighTax()
    };
}

internal class PerformanceBonus
{
    public decimal Calculate(decimal amount) => amount * 0.05m;
}