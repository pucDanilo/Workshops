using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BancoHistorico.Cadastros.Domain
{
    public class Coluna
    {
        [Key]
        public Guid Id { get; set; }

        public Coluna(string name, int id)
        {
            Id = Guid.NewGuid();
            _indiceItems = new List<Indice>();
            this.Name = name;
            this.NumeroColuna = id;
        }

        protected Coluna()
        {
            Id = Guid.NewGuid();
            _indiceItems = new List<Indice>();
        }

        public Coluna(string ownsOne, string columnNameOf, int id, string name, string type, int max_length)
        {
            Id = Guid.NewGuid();
            //_indiceItems = new List<Indice>();
            this.OwnsOne = ownsOne;
            this.ColumnNameOf = columnNameOf;
            this.NumeroColuna = id;
            this.Name = name;
            this.type = type;
            this.max_length = max_length;
        }

        public Guid TabelaId { get; private set; }
        public Tabela Tabela{ get; set; }

        public string Name { get; private set; }
        public int NumeroColuna { get; private set; }
        public string OwnsOne { get; private set; }
        public string ColumnNameOf { get; private set; }
        public string type { get; private set; }
        public int max_length { get; private set; }
        public Fk[] fks { get; private set; }
        public Constraint[] constraints { get; private set; }
        private readonly List<Indice> _indiceItems; public IReadOnlyCollection<Indice> IndiceItems => _indiceItems;
        //private readonly List<Fk> _FkItems; public IReadOnlyCollection<Fk> FkItems => _FkItems;
        //private readonly List<Constraint> _ConstraintItems; public IReadOnlyCollection<Constraint> ConstraintItems => _ConstraintItems;
        /*
        public void AdicionarIndice(Indice indice)
        {
            _indiceItems.Add(indice);
        }
        */
        public void AssociarTabela(Guid tabelaId)
        {
            TabelaId = tabelaId;
        }
    }
}