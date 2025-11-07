using PocketApp.Core.DomainObjects;
using System;

namespace PocketApp.Domain
{
    public class Movimentacao : Entity
    {
        public string Descricao { get; private set; }
        public System.DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public string Tag { get; private set; }
        public Guid FluxoCaixaId { get; private set; }
        public virtual FluxoCaixa FluxoCaixa { get; private set; }

        protected Movimentacao()
        {
        }

        public Movimentacao(string tag, DateTime data, decimal valor, string descricao)
        {
            this.Tag = tag;
            this.Data = data;
            this.Valor = valor;
            this.Descricao = descricao;

            Validar();
        }

        public override bool EhValido()
        {
            return true;
        }

        internal void AssociarCaixa(Guid fluxoCaixaId)
        {
            this.FluxoCaixaId = fluxoCaixaId;
        }

        public void Validar()
        {
        }
    }
}