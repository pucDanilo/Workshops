using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Authorize] [Route("api/v1/[controller]")]
    public class ProtocoloController : FactoryControllerBase<Protocolo, ProtocoloViewModel>
    {
        public ProtocoloController(QuickPocketContext context, IProtocoloService servico) : base(context, servico)
        {
        }
    }
}