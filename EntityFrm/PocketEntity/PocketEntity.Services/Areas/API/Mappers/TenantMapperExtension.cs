using AutoMapper;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;

namespace PocketEntity.Core.Mappers
{
    public static class MappingTenantExtension
    {
        public static IMappingExpression<Tenant, TenantViewModel> MapTenantViewModel(this IMapperConfigurationExpression provider)
        {
            var mapa = provider.CreateMap<Tenant, TenantViewModel>()
                .ForMember(dest => dest.TenantName, opt => opt.MapFrom(src => src.TenantName)) ;
             return mapa;
        }
    }
}