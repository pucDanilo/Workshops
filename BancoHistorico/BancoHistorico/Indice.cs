using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoHistorico.Cadastros.Domain
{/*
var solucao = a[0]
var msg = 'var solucao = GetSolucao("' + solucao.soluctionName + '");\n' ;
var projeto = solucao.dbo[0];
msg += 'var projeto = GetProjeto(solucao.Id, "' + projeto.projeto + '");\n';
for (let tabela of projeto.table) 
{
	msg += '\nvar tabela'+ tabela.id + ' = GetTabela(projeto.Id, "' + tabela.area +'", "' + tabela.tableNameOf +'", ' + tabela.id + ', "' + tabela.name +'"));';
	for (let coluna of tabela.columns) 
	{
            
	msg += '\nvar coluna_'+ coluna.id + '_'+ tabela.id + ' = GetColuna(tabela'+ tabela.id + '.Id,"' +
	coluna.OwnsOne +'", "' + coluna.ColumnNameOf +'", ' + coluna.id +', "' + coluna.name +'", "' + coluna.type +'", ' + coluna.max_length +');';
	}
}
console.log(msg);*/
    public class Indice
    {
        [Key]
        public Guid Id { get; set; }
        public Indice(Guid ColunaId, string keyNameOf, string name, bool is_unique, bool is_primary_key)
        {
            this.ColunaId = ColunaId;
            this.Id = Guid.NewGuid();
            this.KeyNameOf = keyNameOf;
            this.Name = name;
            this.is_unique = is_unique;
            this.is_primary_key = is_primary_key;

        }
        public Guid ColunaId { get; set; }

        [Column("KeyNameOf")]
        public string KeyNameOf { get; private set; }

        [Column("Name")]
        public string Name { get; private set; }

        [Column("is_unique")]
        public bool is_unique { get; private set; }

        [Column("is_primary_key")]
        public bool is_primary_key { get; private set; }

        [Column("filter_definition")]
        public string filter_definition { get; private set; } 

        /*
        private readonly List<Coluna> _colunaItems;
        public IReadOnlyCollection<Coluna> ColunaItems => _colunaItems;

        public void AdicionarColuna(string name, int id)
        {
            var coluna = new Coluna(name, id);
            _colunaItems.Add(coluna);
        }*/
    }
}