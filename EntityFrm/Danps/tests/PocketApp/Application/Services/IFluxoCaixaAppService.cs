using PocketApp.Application.ViewModels;
using PocketApp.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Application.Services
{
    public interface IFluxoCaixaAppService : IDisposable
    {
        Task<IEnumerable<FluxoCaixaViewModel>> ObterPorCategoria(TipoCategoria codigo);

        Task<FluxoCaixaViewModel> ObterPorId(Guid id);

        Task<IEnumerable<FluxoCaixaViewModel>> ObterTodos();

        Task<IEnumerable<MovimentacaoViewModel>> ObterMovimentacoes(Guid id);

        Task AdicionarFluxoCaixa(FluxoCaixaViewModel fluxoCaixaViewModel);

        Task AtualizarFluxoCaixa(FluxoCaixaViewModel fluxoCaixaViewModel);

        Task<FluxoCaixaViewModel> IncluirMovimentacao(Guid id, MovimentacaoViewModel quantidade);
    }
}