using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class ContraChequeViewModel : IViewModelDefault
    {
        public Int32 ContraChequeId { get; set; }
        public decimal ValorTransacao { get; set; }
        public Int32 TransacaoId { get; set; }
        public Int32 NaturezaId { get; set; }
        public Decimal Valor { get; set; }
        public Int32 TenantId { get; set; }
    }
}