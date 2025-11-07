using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BancoHistorico.Cadastros.Domain
{
    public class Solucao
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; private set; }
        private readonly List<Projeto> _projetoItems;
        public IReadOnlyCollection<Projeto> ProjetoItems => _projetoItems;

        protected Solucao()
        {
            Id = Guid.NewGuid();
            _projetoItems = new List<Projeto>();
        }

        public Solucao(string name)
        {
            Id = Guid.NewGuid();
            _projetoItems = new List<Projeto>();
            this.Name = name;
        }

        public void AdicionarProjeto(string v)
        {
            _projetoItems.Add(new Projeto(v));
        }
    }
}