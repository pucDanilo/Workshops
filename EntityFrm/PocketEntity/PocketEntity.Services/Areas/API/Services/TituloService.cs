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
    public interface ITituloService : IServiceFactory<Titulo, TituloViewModel>
    {
    }

    public class TituloService : ServiceFactory<Titulo, TituloViewModel>, ITituloService
    {
        public TituloService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapTituloViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(Titulo obj, TituloViewModel model)
        {
        obj.BancoId = model.BancoId;
        obj.Nome= model.Nome;
        obj.Tipo= model.Tipo;
        obj.DataVencimento= model.DataVencimento;
        obj.TaxaAtual= model.TaxaAtual; 
        //obj.TenantId= model.TenantId;
        }

        public override System.Linq.Expressions.Expression<System.Func<Titulo, bool>> GetById(Int32 TituloId)
        {
            return a =>
        a.TituloId == TituloId;
        }

        public override Expression<System.Func<Titulo, object>> IncludeGetAll()
        {
            return a => a.Banco;
        }

        public override Expression<Func<Titulo, bool>> GetByViewModel(TituloViewModel model)
        {
            return  a => a.BancoId == model.TenantId;
        }

        public override Expression<Func<Titulo, object>> OrderByClause()
        {
            return a => a.TituloId;
        }
    }
}