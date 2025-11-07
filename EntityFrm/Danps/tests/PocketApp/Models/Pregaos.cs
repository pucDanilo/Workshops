using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Pregao : ITransacao
    {
        [Key]
        public int PregaoId { get; set; }

        public int StockId { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Preco { get; set; }

        #region ITransacao

        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }

        #endregion ITransacao

        public virtual Stock Stock { get; set; }
    }
}