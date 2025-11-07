using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingContraChequeExtension
    {
        public static IMappingExpression<ContraCheque, ContraChequeViewModel> MapContraChequeViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<ContraCheque, ContraChequeViewModel>() 
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor)) 
                .ForMember(dest => dest.TenantId, opt => opt.MapFrom(src => src.SalarioId)) 
                .ForMember(dest => dest.ValorTransacao, opt => opt.MapFrom(src => src.Valor));
             return mapa;
        }
    }
}