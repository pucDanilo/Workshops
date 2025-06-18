namespace Ex40.Models;

internal class HighTax : IncomeTaxBase
{
    protected override decimal Rate => 0.22m;
}
