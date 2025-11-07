using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class ContraChequeNaturezaSummaryViewModel : IViewModelDefault
    {
        public Int32 TenantId { get; set; }
        public String Descricao { get; set; }
        public Decimal Total { get; set; }
    }
}