using PocketApp.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketApp.Domain
{
    public interface IFluxoCaixaRepository : IRepository<FluxoCaixa>
    {
        Task<IEnumerable<FluxoCaixa>> ObterTodos();

        Task<IEnumerable<FluxoCaixa>> ObterPorCategoria(TipoCategoria codigo);

        Task<FluxoCaixa> ObterPorId(Guid id);

        void Adicionar(FluxoCaixa obj);

        void Atualizar(FluxoCaixa obj);

        Task<IEnumerable<Movimentacao>> ObterMovimentacoes(Guid fluxoCaixaId);

        void AdicionarMovimentacao(Guid fluxoCaixaId, Movimentacao obj);

        void AtualizarMovimentacao(Guid fluxoCaixaId, Movimentacao obj);
    }
}