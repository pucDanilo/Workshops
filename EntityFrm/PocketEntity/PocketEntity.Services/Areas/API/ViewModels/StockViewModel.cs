using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class StockViewModel : IViewModelDefault
    {
        public Int32 StockId { get; set; }
        public string NomeContaCorrente { get; set; }
        public Int32 ContaCorrenteId { get; set; }
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public DateTime DataCotacao { get; set; }
        public Decimal Cotacao { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal PrecoMedio { get; set; }
        public Decimal GanhoTotal { get; set; }
        public Decimal Total { get; set; }
    }
}