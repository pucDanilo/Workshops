using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Authorize] [Route("api/v1/[controller]")]
    public class ContraChequeController : FactoryControllerBase<ContraCheque, ContraChequeViewModel>
    {
        public ContraChequeController(QuickPocketContext context, IContraChequeService servico) : base(context, servico)
        {
        }
    }
}