using Danps.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Categorias : Entity
    {
        public String Nome { get; private set; }
        public int Codigo { get; private set; }
        public Guid Id { get; private set; }

        protected Categorias()
        {
        }

        public Categorias(
            String Nome,
            int Codigo)
        {
            this.Nome = Nome;
            this.Codigo = Codigo;
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O campo Id do produto não pode estar vazio");
        }
    }
}