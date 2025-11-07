using Danps.Core.DomainObjects;

namespace Danps.My.Domain.Models
{
    public class MyClassForeignKey : EntityAudit
    {
        public string column_name { get; set; }
        public string table_name { get; set; }
        public string reference_name { get; set; }
        public int MyClassId { get; set; }
        public MyClass MyClass { get; set; }
    }
}