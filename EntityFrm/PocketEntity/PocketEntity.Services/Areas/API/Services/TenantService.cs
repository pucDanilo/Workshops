using AutoMapper;
using Danps.Core.Models;
using Danps.Core.Services;
using Microsoft.Extensions.Logging;
using PocketEntity.Core.Mappers;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;
using System;
using System.Linq.Expressions;

namespace PocketEntity.Core.Services
{
    public interface ITenantService : IServiceFactory<Tenant, TenantViewModel>
    {
    }

    public class TenantService : ServiceFactory<Tenant, TenantViewModel>, ITenantService
    {
        public TenantService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapTenantViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(Tenant obj, TenantViewModel model)
        {
            obj.TenantName = model.TenantName;
        }

        public override System.Linq.Expressions.Expression<System.Func<Tenant, bool>> GetById(Int32 TenantId)
        {
            return a =>
        a.TenantId == TenantId;
        }

        public override Expression<System.Func<Tenant, object>> IncludeGetAll()
        {
            return null;
        }

        public override Expression<Func<Tenant, bool>> GetByViewModel(TenantViewModel model)
        {
            return a => a.TenantId == model.TenantId;
        }

        public override Expression<Func<Tenant, object>> OrderByClause()
        {
            return a => a.TenantId;
        }
    }
}