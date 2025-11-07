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
    public interface IContraChequeService : IServiceFactory<ContraCheque, ContraChequeViewModel>
    {
    }

    public class ContraChequeService : ServiceFactory<ContraCheque, ContraChequeViewModel>, IContraChequeService
    {
        public ContraChequeService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapContraChequeViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(ContraCheque obj, ContraChequeViewModel model)
        {  
        obj.Valor= model.Valor;
        obj.SalarioId = model.TenantId;
        }

        public override System.Linq.Expressions.Expression<System.Func<ContraCheque, bool>> GetById(Int32 ContraChequeId)
        {
            return a =>
        a.ContraChequeId == ContraChequeId;
        }

        public override Expression<System.Func<ContraCheque, object>> IncludeGetAll()
        {
            return a => a.Salario;
        }

        public override Expression<Func<ContraCheque, bool>> GetByViewModel(ContraChequeViewModel model)
        {
            return  a => a.SalarioId == model.TenantId;
        }

        public override Expression<Func<ContraCheque, object>> OrderByClause()
        {
            return a => a.ContraChequeId;
        }
    }
}