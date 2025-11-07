using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class ContraChequeSummaryViewModel : IViewModelDefault
    {
        public Int32 TenantId { get; set; }
        public String Descricao { get; set; }
        public Decimal Total { get; set; }
    }
}