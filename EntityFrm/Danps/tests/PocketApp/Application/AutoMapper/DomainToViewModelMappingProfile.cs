using AutoMapper;
using PocketApp.Application.ViewModels;
using PocketApp.Domain;

namespace PocketApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<FluxoCaixa, FluxoCaixaViewModel>();

            CreateMap<Movimentacao, MovimentacaoViewModel>();
        }
    }
}