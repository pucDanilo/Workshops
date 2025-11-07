using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class ContaCorrenteViewModel : IViewModelDefault
    {
        public Int32 ContaCorrenteId { get; set; }
        public string  NomeTenant { get; set; }
        public String NomeBanco { get; set; }
        public String Descricao { get; set; }
        public String NumeroConta { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public Int32 TenantId { get; set; }
    }
}