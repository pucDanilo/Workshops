using Danps.Core.DomainObjects;

namespace Danps.My.Domain.Models
{
    public class MyClassField : EntityAudit
    {
        public int column_id { get; set; }
        public string object_name { get; set; }
        public string column_name { get; set; }
        public string clr_type { get; set; }
        public string column_type { get; set; }
        public int? max_length { get; set; }
        public bool is_primary_key { get; set; }
        public string OwnsOne { get; set; }
        public int MyClassId { get; set; }
        public MyClass MyClass { get; set; }
    }
}