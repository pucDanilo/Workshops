using System;

namespace Danps.Catalogo.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        protected Produto()
        {
        }
    }
}