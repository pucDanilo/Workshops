using Danps.Core.DomainObjects;
using System.Collections.Generic;

namespace Danps.My.Domain.Models
{
    public class MyAggregate : EntityAudit
    {
        public string Area { get; set; }
        public string Projeto { get; set; }
        public string CoreDomain { get; set; }
        public string NomeInterface { get; set; }
        public ICollection<MyAggregateClass> MyAggregateClasses { get; set; }
    }
}