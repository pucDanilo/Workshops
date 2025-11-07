using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Authorize] [Route("api/v1/[controller]")]
    public class PregaoController : FactoryControllerBase<Pregao, PregaoViewModel>
    {
        public PregaoController(QuickPocketContext context, IPregaoService servico) : base(context, servico)
        {
        }
    }
}