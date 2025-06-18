namespace Ex40.Models;

internal class SuperHighTax : IncomeTaxBase
{
    protected override decimal Rate => 0.27m;
}
