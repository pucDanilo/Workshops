using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingTituloExtension
    {
        public static IMappingExpression<Titulo, TituloViewModel> MapTituloViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<Titulo, TituloViewModel>()
                .ForMember(dest => dest.BancoId, opt => opt.MapFrom(src => src.BancoId))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.DataVencimento, opt => opt.MapFrom(src => src.DataVencimento))
                .ForMember(dest => dest.TaxaAtual, opt => opt.MapFrom(src => src.TaxaAtual)); 
                //.ForMember(dest => dest.TenantId, opt => opt.MapFrom(src => src.TenantId)) 
                //.ForMember(dest => dest.NomeTenant, opt => opt.MapFrom(src => src.Tenant.TenantName));
             return mapa;
        }
    }
}