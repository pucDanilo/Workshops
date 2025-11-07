using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Authorize] [Route("api/v1/[controller]")]
    public class TenantController : FactoryControllerBase<Tenant, TenantViewModel>
    {
        public TenantController(QuickPocketContext context, ITenantService servico) : base(context, servico)
        {
        }
    }
}