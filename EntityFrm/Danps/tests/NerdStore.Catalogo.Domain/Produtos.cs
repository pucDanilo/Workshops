using Danps.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Produtos : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public String Nome { get; private set; }
        public String Descricao { get; private set; }
        public Boolean Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public String Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }
        public Guid Id { get; private set; }

        protected Produtos()
        {
        }

        public Produtos(
            Guid CategoriaId,
            String Nome,
            String Descricao,
            Boolean Ativo,
            decimal Valor,
            DateTime DataCadastro,
            String Imagem,
            int QuantidadeEstoque,
            decimal Altura,
            decimal Largura,
            decimal Profundidade)
        {
            this.CategoriaId = CategoriaId;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Ativo = Ativo;
            this.Valor = Valor;
            this.DataCadastro = DataCadastro;
            this.Imagem = Imagem;
            this.QuantidadeEstoque = QuantidadeEstoque;
            this.Altura = Altura;
            this.Largura = Largura;
            this.Profundidade = Profundidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O campo Id do produto não pode estar vazio");
        }
    }
}