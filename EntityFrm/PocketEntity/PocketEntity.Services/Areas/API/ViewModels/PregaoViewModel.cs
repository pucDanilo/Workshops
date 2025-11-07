using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class PregaoViewModel : IViewModelDefault
    {
        public Int32 PregaoId { get; set; }
        public string  NomeStock { get; set; }
        public Int32 StockId { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal Preco { get; set; }
        public Decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}