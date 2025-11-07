using Danps.Core.Services;
using Danps.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core;

namespace Danps.Core
{
    public class FactoryControllerBase<TEntity, TEntityView> : AbstractControllerBase<TEntity, TEntityView> where TEntityView : class
    {
        public FactoryControllerBase(QuickPocketContext context, IServiceFactory<TEntity, TEntityView> service) : base(context, service)
        {
        }

        [HttpGet]
        public override PaginatedItemsViewModel<TEntityView> Get()
        {
            return Get(0, 4);
        }
    }
}