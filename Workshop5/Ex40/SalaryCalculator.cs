using System;

namespace Ex40;

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