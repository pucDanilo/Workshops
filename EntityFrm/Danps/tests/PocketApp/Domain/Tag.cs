using PocketApp.Core.DomainObjects;
using System;

namespace PocketApp.Domain
{
    public class Tag : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public Guid MovimentacaoId { get; private set; } 
        public virtual Movimentacao Movimentacao { get; private set; }

        protected Tag()
        {
        }

        public Tag(Guid movimentacaoId, int codigo, string nome)
        {
            this.MovimentacaoId = movimentacaoId;
            this.Nome = nome;
            this.Codigo = codigo;
            Validar();
        }

        public void Validar()
        {
        }
    }
}