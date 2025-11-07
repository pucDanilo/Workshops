using Microsoft.EntityFrameworkCore;
using PocketApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApp.Data.Repository
{

    public class FluxoCaixaRepository : PocketContextRepository<FluxoCaixa>, IFluxoCaixaRepository
    {
        private DbSet<Movimentacao> _transactions => ((PocketContext)_context).Transactions;

        public FluxoCaixaRepository(PocketContext context) : base(context)
        {
            this.aggregateRootDbSet = context.CashFlows; 
        }

        public async Task<IEnumerable<FluxoCaixa>> ObterPorCategoria(TipoCategoria codigo)
        {
            return await aggregateRootDbSet.AsNoTracking().Where(c => c.TipoCategoria == codigo).ToListAsync();
        }

        public void AdicionarMovimentacao(Guid fluxoCaixaId, Movimentacao movimentacao)
        {
            movimentacao.AssociarCaixa(fluxoCaixaId);

            _transactions.Add(movimentacao);
        }

        public void AtualizarMovimentacao(Guid fluxoCaixaId, Movimentacao movimentacao)
        {
            if (movimentacao.FluxoCaixaId != fluxoCaixaId)
            {
                throw new Exception("Movimentação entre contas!");
            }
            _transactions.Update(movimentacao);
        }

        public async Task<IEnumerable<Movimentacao>> ObterMovimentacoes(Guid fluxoCaixaId)
        {
            return await _transactions.AsNoTracking().Where(a => a.FluxoCaixaId == fluxoCaixaId).ToListAsync();
        }
    }
}