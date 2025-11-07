using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingPregaoExtension
    {
        public static IMappingExpression<Pregao, PregaoViewModel> MapPregaoViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<Pregao, PregaoViewModel>()
                .ForMember(dest => dest.StockId, opt => opt.MapFrom(src => src.StockId)) 
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade)) 
                .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Preco)) 
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor)) 
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data)) 
                .ForMember(dest => dest.NomeStock, opt => opt.MapFrom(src => src.Stock.Descricao));
             return mapa;
        }
    }
}