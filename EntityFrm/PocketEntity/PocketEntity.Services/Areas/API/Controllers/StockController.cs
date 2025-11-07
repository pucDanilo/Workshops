using Danps.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core.Models; 
using PocketEntity.Core.Services;
using PocketEntity.Core.ViewModels;
namespace PocketEntity.Core.Controllers
{
    [Authorize] [Route("api/v1/[controller]")]
    public class StockController : FactoryControllerBase<Stock, StockViewModel>
    {
        public StockController(QuickPocketContext context, IStockService servico) : base(context, servico)
        {
        }
    }
}