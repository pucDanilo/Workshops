namespace Ex40.Models;

internal abstract class IncomeTaxBase : IIncomeTax
{
    protected abstract decimal Rate { get; }

    public decimal Apply(decimal amount) => amount * Rate;
}
