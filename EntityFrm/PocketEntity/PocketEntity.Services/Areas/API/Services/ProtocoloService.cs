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
    public interface IProtocoloService : IServiceFactory<Protocolo, ProtocoloViewModel>
    {
    }

    public class ProtocoloService : ServiceFactory<Protocolo, ProtocoloViewModel>, IProtocoloService
    {
        public ProtocoloService(ILogger logger, IUserInfo userInfo, QuickPocketContext context) : base(logger, userInfo, context)
        {
            this._mapper = new MapperConfiguration(cfg => { cfg.MapProtocoloViewModel(); }).CreateMapper();
        }

        public override void UpdateEntity(Protocolo obj, ProtocoloViewModel model)
        {
        obj.TituloId= model.TituloId;
        obj.Descricao = model.TaxaPactuada;
        obj.PrecoUnitario= model.PrecoUnitario;
        obj.Quantidade= model.Quantidade;
        obj.ValorLiquido= model.ValorLiquido;
        obj.ValorInvestido= model.ValorInvestido;
        obj.Valor= model.Valor;
        obj.Data= model.Data;
        }

        public override System.Linq.Expressions.Expression<System.Func<Protocolo, bool>> GetById(Int32 ProtocoloId)
        {
            return a =>
        a.ProtocoloId == ProtocoloId;
        }

        public override Expression<System.Func<Protocolo, object>> IncludeGetAll()
        {
            return a => a.Titulo;
        }

        public override Expression<Func<Protocolo, bool>> GetByViewModel(ProtocoloViewModel model)
        {
            return  a => a.TituloId == model.TituloId;
        }

        public override Expression<Func<Protocolo, object>> OrderByClause()
        {
            return a => a.ProtocoloId;
        }
    }
}