using Danps.My.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Danps.My.Domain.ViewModels
{
    public class CampoViewModel
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
    }
    public class ContextoViewModel
    { 

        public string Projeto { get; }
        public string Area { get; }
        public ICollection<CampoViewModel> Classes { get; set; } 


        public ContextoViewModel(MyAggregate myAggregate)
        {
            this.Projeto = myAggregate.Projeto;
            this.Area = myAggregate.Area;
            var campos = myAggregate.MyAggregateClasses.Select(c => new CampoViewModel { Tipo = c.MyClass.Nome, Nome = c.MyClass.NomeTabela, }).ToArray();
        }
    }
    public class EntidadeViewModel
    {
        public MyClass Principal { get; set; }
        public string NomeInterface { get; set; }
        public string NomeEntidade { get; set; }
        public string Projeto { get; set; }
        public string Area { get; set; } 
        public string CoreDomain { get; set; }

        public EntidadeViewModel()
        {

        }
        public EntidadeViewModel(MyAggregate MyAggregate) : this(
            MyAggregate.MyAggregateClasses.Where(a => a.Principal).FirstOrDefault(),
            MyAggregate.NomeInterface, MyAggregate.Projeto, MyAggregate.Area, MyAggregate.CoreDomain
            )
        {
            /*
            this.Principal = MyAggregate.MyAggregateClasses.Where(a => a.Principal).FirstOrDefault().MyClass;

            this.NomeInterface = MyAggregate.NomeInterface;
            this.NomeEntidade = Principal.Nome;
            this.NomeNamespace = $"{MyAggregate.Projeto}.{MyAggregate.Area}.Domain"; 

            var campos = this.Principal.MyClassFields.Where(a => a.is_primary_key == false).Select(c => new CampoViewModel { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
            var pk = this.Principal.MyClassFields.Where(a => a.is_primary_key).Select(c => new CampoViewModel { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
            this.ParametroConstrutor = campos;
            this.Construtor = campos;
            this.Campos = campos.Concat(pk).ToArray();*/
        } 

        public EntidadeViewModel(MyAggregateClass item, string nomeInterface, string projeto, string area, string CoreDomain)
        {
            this.Principal = item.MyClass;
            var campos = this.Principal.MyClassFields.Where(a => a.is_primary_key == false).Select(c => new CampoViewModel { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
            var pk = this.Principal.MyClassFields.Where(a => a.is_primary_key).Select(c => new CampoViewModel { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
            this.ParametroConstrutor = campos;
            this.Construtor = campos;
            this.Campos = campos.Concat(pk).ToArray();
            
            this.NomeInterface = nomeInterface + (item.Principal? ", IAggregateRoot": "");
            this.NomeEntidade = this.Principal.Nome;
            this.Projeto = projeto;
            this.Area = area; 
            this.CoreDomain = CoreDomain;
        }

        public ICollection<CampoViewModel> Campos { get; set; }
        public ICollection<CampoViewModel> ParametroConstrutor { get; set; }
        public ICollection<CampoViewModel> Construtor { get; set; }
    }
}