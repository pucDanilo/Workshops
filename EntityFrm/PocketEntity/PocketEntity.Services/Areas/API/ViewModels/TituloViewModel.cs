using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class TituloViewModel : IViewModelDefault
    {
        public Int32 TituloId { get; set; }
        public string  NomeTenant { get; set; }
        public Int32 BancoId { get; set; }
        public String Nome { get; set; }
        public String Tipo { get; set; }
        public DateTime DataVencimento { get; set; }
        public Decimal TaxaAtual { get; set; }
        public Decimal ValorLiquido { get; set; }
        public Decimal ValorInvestido { get; set; }
        public Int32 TenantId { get; set; }
    }
}