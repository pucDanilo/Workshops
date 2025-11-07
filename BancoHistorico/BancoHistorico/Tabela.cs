using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoHistorico.Cadastros.Domain
{
    public class Tabela
    {
        protected Tabela()
        {
            this.Id = Guid.NewGuid();
            _indiceItems = new List<Indice>();
            _colunaItems = new List<Coluna>();
        }
        public Tabela(string area, string tableNameOf, int id, string name)
        { 
            this.area = area;
            this.tableNameOf = tableNameOf;
            this.NumeroTabela = id;
            this.Name = name;
            this.Id = Guid.NewGuid();
            _indiceItems = new List<Indice>();
            _colunaItems = new List<Coluna>();
        }

        [Key]
        public Guid Id { get; set; }

        [Column("area")]
        public string area { get; private set; }

        [Column("tableNameOf")]
        public string tableNameOf { get; private set; }

        [Column("Contador")]
        public int NumeroTabela{ get; private set; }

        [Column("Name")]
        public string Name { get; private set; }

        //Foreign key for Standard  
        public Guid ProjetoId { get; private set; }
        public Projeto Projeto { get; set; }




        private readonly List<Indice> _indiceItems;
        public IReadOnlyCollection<Indice> IndiceItems => _indiceItems;

        private readonly List<Coluna> _colunaItems;
        public IReadOnlyCollection<Coluna> ColunaItems => _colunaItems;

        public void AdicionarColuna(Coluna coluna)
        {
            _colunaItems.Add(coluna);
        }

        public void AdicionarIndex(Indice indice)
        {
            _indiceItems.Add(indice);
        }

        public void AssociarProjeto(Guid projetoId)
        {
            ProjetoId = projetoId;
        }
    }
}