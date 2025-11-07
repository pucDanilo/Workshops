using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Protocolo : ITransacao
    {
        [Key] public int ProtocoloId { get; set; }
        public int TituloId { get; set; }

        #region ITransacao

        public string Descricao { get; set; } //public string TaxaPactuada { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }

        #endregion ITransacao

        public decimal PrecoUnitario { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorInvestido { get; set; }
        public virtual Titulo Titulo { get; set; }
    }
}