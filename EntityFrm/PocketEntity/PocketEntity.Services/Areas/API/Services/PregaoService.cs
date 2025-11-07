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
    public interface IPregaoService : IServiceFactory<Pregao, PregaoViewModel>
    {
    }

    public class PregaoService : ServiceFactory<Pregao, PregaoViewModel>, IPregaoService
    {
        public PregaoService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapPregaoViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(Pregao obj, PregaoViewModel model)
        {
        obj.StockId= model.StockId;
        obj.Quantidade= model.Quantidade;
        obj.Preco= model.Preco;
        obj.Valor= model.Valor;
        obj.Data= model.Data;
        }

        public override System.Linq.Expressions.Expression<System.Func<Pregao, bool>> GetById(Int32 PregaoId)
        {
            return a =>
        a.PregaoId == PregaoId;
        }

        public override Expression<System.Func<Pregao, object>> IncludeGetAll()
        {
            return a => a.Stock;
        }

        public override Expression<Func<Pregao, bool>> GetByViewModel(PregaoViewModel model)
        {
            return  a => a.StockId == model.StockId;
        }

        public override Expression<Func<Pregao, object>> OrderByClause()
        {
            return a => a.PregaoId;
        }
    }
}