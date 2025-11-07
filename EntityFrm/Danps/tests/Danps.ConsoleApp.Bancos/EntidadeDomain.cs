using Danps.My.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Danps.ConsoleApp.Bancos
{
    public class EntidadeDomain
    {
        public EntidadeDomain()
        {
        }

        public EntidadeDomain(MyClass classes)
        {
            if (classes != null)
            {
                var campos = classes.MyClassFields.Where(a => a.is_primary_key == false).Select(c => new Campo { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
                var pk = classes.MyClassFields.Where(a => a.is_primary_key).Select(c => new Campo { Tipo = c.clr_type, Nome = c.column_name, }).ToArray();
                this.NomeEntidade = classes.Nome;
                this.CoreDomain = "Danps.Core";
                this.NomeNamespace = "Danps.Catalogo.Domain";
                this.IsAggregate = true;
                this.NomeInterface = "Entity, IAggregateRoot";
                this.ParametroConstrutor = campos;
                this.Construtor = campos;
                this.Campos = campos.Concat(pk).ToArray();
            }
        }

        public string CoreDomain { get; set; }
        public string NomeNamespace { get; set; }
        public bool IsAggregate { get; set; }
        public string NomeInterface { get; set; }
        public string NomeEntidade { get; set; }
        public ICollection<Campo> Campos { get; set; }
        public ICollection<Campo> ParametroConstrutor { get; set; }
        public ICollection<Campo> Construtor { get; set; }
    }
}