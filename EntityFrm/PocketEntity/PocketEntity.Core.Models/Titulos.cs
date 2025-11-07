using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Titulo
    {
        [Key]
        public int TituloId { get; set; }
        public int BancoId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public System.DateTime DataVencimento { get; set; }
        public decimal TaxaAtual { get; set; }
        public virtual Banco Banco { get; set; }
        public virtual ICollection<ExtratoTitulo> ExtratoTitulo { get; set; }
        public virtual ICollection<Protocolo> Protocolo { get; set; }
    }
}