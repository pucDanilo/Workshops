using System;
using System.Collections.Generic;

namespace Danps.Catalogo.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }
    }
}