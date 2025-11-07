using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class ExtratoTitulo : ITransacao
    {
        [Key]
        public int ExtratoTituloId { get; set; }
        public int TituloId { get; set; }
        public int BancoId { get; set; }

        #region ITransacao

        public string Descricao { get; set; } //         public string AnoMes { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; } //        public decimal ValorInvestido { get; set; }

        #endregion ITransacao

        public decimal ValorInicial { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorBruto { get; set; }

        public virtual Banco Banco { get; set; }
        public virtual Titulo Titulo { get; set; }
    }
}