using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingProtocoloExtension
    {
        public static IMappingExpression<Protocolo, ProtocoloViewModel> MapProtocoloViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<Protocolo, ProtocoloViewModel>()
                .ForMember(dest => dest.TituloId, opt => opt.MapFrom(src => src.TituloId)) 
                .ForMember(dest => dest.TaxaPactuada, opt => opt.MapFrom(src => src.Descricao)) 
                .ForMember(dest => dest.PrecoUnitario, opt => opt.MapFrom(src => src.PrecoUnitario)) 
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade)) 
                .ForMember(dest => dest.ValorLiquido, opt => opt.MapFrom(src => src.ValorLiquido)) 
                .ForMember(dest => dest.ValorInvestido, opt => opt.MapFrom(src => src.ValorInvestido)) 
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor)) 
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data)) 
                .ForMember(dest => dest.NomeTitulo, opt => opt.MapFrom(src => src.Titulo.Nome));
             return mapa;
        }
    }
}