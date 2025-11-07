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
    public interface IStockService : IServiceFactory<Stock, StockViewModel>
    {
    }

    public class StockService : ServiceFactory<Stock, StockViewModel>, IStockService
    {
        public StockService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapStockViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(Stock obj, StockViewModel model)
        {
        obj.BancoId = model.ContaCorrenteId;
        obj.Codigo= model.Codigo;
        obj.Descricao= model.Nome;
        obj.Data= model.DataCotacao;
        obj.Cotacao= model.Cotacao;
        obj.Quantidade= model.Quantidade;
        obj.PrecoMedio= model.PrecoMedio;
        obj.GanhoTotal= model.GanhoTotal;
        obj.Valor= model.Total;
        }

        public override System.Linq.Expressions.Expression<System.Func<Stock, bool>> GetById(Int32 StockId)
        {
            return a =>
        a.StockId == StockId;
        }

        public override Expression<System.Func<Stock, object>> IncludeGetAll()
        {
            return a => a.Banco;
        }

        public override Expression<Func<Stock, bool>> GetByViewModel(StockViewModel model)
        {
            return  a => a.BancoId == model.ContaCorrenteId;
        }

        public override Expression<Func<Stock, object>> OrderByClause()
        {
            return a => a.StockId;
        }
    }
}