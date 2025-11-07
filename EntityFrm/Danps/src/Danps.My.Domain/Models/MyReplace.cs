using Danps.Core.DomainObjects;

namespace Danps.My.Domain.Models
{
    public class MyReplace : EntityAudit
    {
        public int Id { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
    }
}