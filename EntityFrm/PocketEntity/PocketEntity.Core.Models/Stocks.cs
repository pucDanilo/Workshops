using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Stock : ITransacao
    {
        [Key]
        public int StockId { get; set; }

        public int BancoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal Cotacao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal GanhoTotal { get; set; }
        public virtual Banco Banco { get; set; }
        public virtual ICollection<Pregao> Pregao { get; set; }
    }
}