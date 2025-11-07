using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BancoHistorico.Cadastros.Domain
{
    public partial class Projeto
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SolucaoId { get; private set; }
        public Solucao Solucao { get; set; }

        public string Name { get; private set; }
        private readonly List<Tabela> _tabelaItems;
        public IReadOnlyCollection<Tabela> TabelaItems => _tabelaItems;

        public Projeto( string nome)
        {
            Id = Guid.NewGuid(); 
            Name = nome;
            _tabelaItems = new List<Tabela>();
        }

        protected Projeto()
        {
            Id = Guid.NewGuid();
            _tabelaItems = new List<Tabela>();
        }

        public void AdicionarTabela(string area, string tableNameOf, int id, string name)
        {
            var item = new Tabela(area, tableNameOf, id, name);
            AdicionarTabela(item);
        }
        public void AdicionarTabela(Tabela item)
        {
            //if (!item.EhValido()) return;

            item.AssociarProjeto(Id);

            if (TabelaExistente(item))
            {
                var itemExistente = _tabelaItems.FirstOrDefault(p => p.ProjetoId == item.ProjetoId);
                //itemExistente.AdicionarUnidades(item.Quantidade);
                item = itemExistente;

                _tabelaItems.Remove(itemExistente);
            }
            item.AssociarProjeto( this.Id);
            _tabelaItems.Add(item);
        }

        public void AdicionarColuna(int tabelaId, string ownsOne, string columnNameOf, int id, string name, string type, int max_length)
        {
            var tabela = _tabelaItems.Where(a => a.NumeroTabela == tabelaId).FirstOrDefault();
            var coluna = new Coluna(ownsOne, columnNameOf, id, name, type, max_length);
            tabela.AdicionarColuna(coluna);
        }

        public void RemoverTabela(Tabela item)
        {
            //if (!item.EhValido()) return;

            var itemExistente = TabelaItems.FirstOrDefault(p => p.ProjetoId == item.ProjetoId);

            //if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");
            _tabelaItems.Remove(itemExistente);
        }

        public void AtualizarTabela(Tabela item)
        {
            ///if (!item.EhValido()) return;
            item.AssociarProjeto(Id);

            var itemExistente = _tabelaItems.FirstOrDefault(p => p.ProjetoId == item.ProjetoId);

            //            if (itemExistente == null) throw new DomainException("O item não pertence ao pedido");

            _tabelaItems.Remove(itemExistente);
            _tabelaItems.Add(item);
        }

        private bool TabelaExistente(Tabela item)
        {
            return _tabelaItems.Any(p => p.Id == item.Id);
        }
    }
}