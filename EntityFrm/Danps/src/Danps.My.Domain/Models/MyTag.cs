using Danps.Core.DomainObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danps.My.Domain.Models
{
    public class MyTag : EntityAudit
    {
        public string Token { get; set; }
        public MyObjetoOrigem Objeto { get; set; }

        [ForeignKey(nameof(Modelo)), Column(Order = 0)]
        public int ModeloId { get; set; }

        [ForeignKey(nameof(ModeloSecundario)), Column(Order = 0)]
        public int? ModeloSecundarioId { get; set; }

        public MyModelo Modelo { get; set; }
        public MyModelo ModeloSecundario { get; set; }
    }
}