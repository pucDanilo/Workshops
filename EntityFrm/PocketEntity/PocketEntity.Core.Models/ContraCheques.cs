using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Salario : ITransacao
    {
        [Key]
        public int SalarioId { get; set; }

        public int BancoId { get; set; }

        #region ITransacao

        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }

        #endregion ITransacao

        public virtual Banco Banco { get; set; }
    }
    public partial class ContraCheque : ITransacao
    {
        [Key]
        public int ContraChequeId { get; set; }

        public int SalarioId { get; set; }

        #region ITransacao

        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }

        #endregion ITransacao

        public virtual Salario Salario{ get; set; }
    }
}