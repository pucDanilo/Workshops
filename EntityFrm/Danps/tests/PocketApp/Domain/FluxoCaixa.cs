using PocketApp.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketApp.Domain
{
    public class FluxoCaixa : Entity, IAggregateRoot
    {
        protected FluxoCaixa()
        {
            this._movimentacaoItems = new List<Movimentacao>();
        }

        public FluxoCaixa(TipoCategoria tipoCategoria, string nome, decimal saldoAnterior)
        {
            this.Nome = nome;
            this.SaldoAnterior = saldoAnterior;
            this.TipoCategoria = tipoCategoria;
            this.Saldo = 0;
            this._movimentacaoItems = new List<Movimentacao>();

            Validar();
        }

        public Guid LocatarioId { get; private set; }
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public TipoCategoria TipoCategoria { get; private set; }

        private readonly List<Movimentacao> _movimentacaoItems;
        public IReadOnlyCollection<Movimentacao> Movimentacoes => _movimentacaoItems;

        public decimal SaldoAnterior { get; private set; }

        public void AlterarTipoFluxoCaixa(TipoCategoria tipo)
        {
            this.TipoCategoria = tipo;
        }

        public bool MovimentacaoExistente(Movimentacao item)
        {
            return _movimentacaoItems.Any(p => p.Id == item.Id);
        }

        public void AdicionarItem(Movimentacao item)
        {
            if (!item.EhValido()) return;

            item.AssociarCaixa(Id);

            if (MovimentacaoExistente(item))
            {
                var itemExistente = _movimentacaoItems.FirstOrDefault(p => p.Id == item.Id);
                _movimentacaoItems.Remove(itemExistente);
            }

            _movimentacaoItems.Add(item);

            CalcularSaldo();
        }

        public void CalcularSaldo()
        {
            Saldo = SaldoAnterior + _movimentacaoItems.Sum(p => p.Valor);
        }

        public void ArquivarMovimentacao(int ano, int mes)
        {
            var saldo = this.Saldo;

            var itensAnoMes = Movimentacoes.Where(p => p.Data.Year == ano && p.Data.Month == mes);

            if (itensAnoMes != null)
            {
                foreach (var item in itensAnoMes)
                {
                    this.SaldoAnterior -= item.Valor;
                    _movimentacaoItems.Remove(item);
                }
            }
            CalcularSaldo();
            if (this.Saldo != saldo)
            {
                throw new Exception("Processo de arquivamento invalido!");
            }
        }

        public void RemoverItem(Movimentacao item)
        {
            if (!item.EhValido()) return;

            var itemExistente = Movimentacoes.FirstOrDefault(p => p.Id == item.Id);

            if (itemExistente == null) throw new Exception("Movimentacao não encontrada no caixa!");

            _movimentacaoItems.Remove(itemExistente);

            CalcularSaldo();
        }

        public void AtualizarItem(Movimentacao item)
        {
            if (!item.EhValido()) return;
            item.AssociarCaixa(Id);

            var itemExistente = Movimentacoes.FirstOrDefault(p => p.Id == item.Id);

            if (itemExistente == null) throw new Exception("O item não pertence ao pedido");

            _movimentacaoItems.Remove(itemExistente);
            _movimentacaoItems.Add(item);

            CalcularSaldo();
        }

        public void Validar()
        {
        }
    }
}