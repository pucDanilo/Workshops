using Danps.Core.Data;
using System;

namespace PocketEntity.Core.ViewModels
{
    public class TenantViewModel : IViewModelDefault
    {
        public Int32 TenantId { get; set; }
        public String TenantName { get; set; }
    }
}