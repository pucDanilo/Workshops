using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class NaturezaViewModel : IViewModelDefault
    {
        public Int32 NaturezaId { get; set; }
        public string  NomeTenant { get; set; }
        public String Nome { get; set; }
        public Int32 TenantId { get; set; }
    }
}