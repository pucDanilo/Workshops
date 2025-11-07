using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class TransacaoViewModel : IViewModelDefault
    {
        public Int32 TransacaoId { get; set; }
        public string  NomeContaCorrente { get; set; }
        public Int32 ContaCorrenteId { get; set; }
        public Int32 NaturezaId { get; set; }
        public String Descricao { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public Int32 TenantId { get; set; }
    }
}