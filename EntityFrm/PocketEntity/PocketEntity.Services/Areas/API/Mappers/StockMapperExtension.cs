using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingStockExtension
    {
        public static IMappingExpression<Stock, StockViewModel> MapStockViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<Stock, StockViewModel>()
                .ForMember(dest => dest.ContaCorrenteId, opt => opt.MapFrom(src => src.BancoId)) 
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo)) 
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Descricao)) 
                .ForMember(dest => dest.DataCotacao, opt => opt.MapFrom(src => src.Data)) 
                .ForMember(dest => dest.Cotacao, opt => opt.MapFrom(src => src.Cotacao)) 
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade)) 
                .ForMember(dest => dest.PrecoMedio, opt => opt.MapFrom(src => src.PrecoMedio)) 
                .ForMember(dest => dest.GanhoTotal, opt => opt.MapFrom(src => src.GanhoTotal)) 
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Valor)) 
                .ForMember(dest => dest.NomeContaCorrente, opt => opt.MapFrom(src => src.Banco.Nome));
             return mapa;
        }
    }
}