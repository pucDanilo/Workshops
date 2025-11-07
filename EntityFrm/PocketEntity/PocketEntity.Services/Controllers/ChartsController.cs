using Danps.Core.Services;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core;
using PocketEntity.Core.Services;

namespace PocketEntity.Services.Controllers
{
    [Route("api/[controller]")]
    public class ChartsController : WebAPIControllerBase
    {
        private IApiValueService ApiValueService;

        public ChartsController(QuickPocketContext context) : base(context)
        {
            this.ApiValueService = new ApiValueService();
        }
    }
}