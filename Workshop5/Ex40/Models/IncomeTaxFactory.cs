namespace Ex40.Models;

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
