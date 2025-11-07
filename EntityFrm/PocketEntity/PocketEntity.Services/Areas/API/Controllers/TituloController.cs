using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Route("api/v1/[controller]")]
    public class TituloController : FactoryControllerBase<Titulo, TituloViewModel>
    {
        public TituloController(QuickPocketContext context, ITituloService servico) : base(context, servico)
        {
        }
    }
}