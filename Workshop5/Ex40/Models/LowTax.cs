namespace Ex40.Models;

internal class LowTax : IncomeTaxBase
{
    protected override decimal Rate => 0.08m;
}
