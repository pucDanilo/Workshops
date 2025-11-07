using AutoMapper;
using PocketApp.Application.ViewModels;
using PocketApp.Domain;

namespace PocketApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FluxoCaixaViewModel, FluxoCaixa>();// .ConstructUsing(p => new FluxoCaixa(p.TipoCategoria, p.Nome, p.SaldoAnterior));

            CreateMap<MovimentacaoViewModel, Movimentacao>();
        }
    }
}