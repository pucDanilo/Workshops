namespace Ex40.Models;

internal class MidTax : IncomeTaxBase
{
    protected override decimal Rate => 0.15m;
}
