using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class ProtocoloViewModel : IViewModelDefault
    {
        public Int32 ProtocoloId { get; set; }
        public string  NomeTitulo { get; set; }
        public Int32 TituloId { get; set; }
        public String TaxaPactuada { get; set; }
        public Decimal PrecoUnitario { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal ValorLiquido { get; set; }
        public Decimal ValorInvestido { get; set; }
        public Decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}