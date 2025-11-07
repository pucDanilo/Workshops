using Danps.Core.DomainObjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace Danps.My.Domain.Models
{
    public class MySqlObject
    {
        public string ObjectName { get; set; }
        public string Definition { get; set; }
        public string ObjectType { get; set; }
        public string ObjectDrop { get; set; }
    }

    public class MyClass : EntityAudit
    {
        public string NomeTabela { get; set; }
        public string Nome { get; set; }
        public string NomeColuna { get; set; }
        public string NomeChavePrimaria { get; set; }
        public ICollection<MyClassField> MyClassFields { get; set; }
        public ICollection<MyClassForeignKey> MyClassForeignKeys { get; set; }
    }

    public class MyAggregateClass : EntityAudit
    {
        public int MyAggregateId { get; set; }
        public MyAggregate MyAggregate { get; set; }
        public int MyClassId { get; set; }
        public MyClass MyClass { get; set; }

        [DefaultValue("false")]
        public bool Principal { get; set; }
    }
}