namespace PocketEntity.Core.Models
{
    public interface ITransacao
    {
        string Descricao { get; set; }
        System.DateTime Data { get; set; }
        decimal Valor { get; set; }
    }
    public partial class Tag
    {
        public int TagId { get; set; }
        public int EntitdadeId { get; set; } 
        public short TipoEntidade { get; set; }
        public string Nome{ get; set; }
    }
    public partial class ContaCorrente : ITransacao
    {
        public int ContaCorrenteId { get; set; }
        public int BancoId { get; set; } 

        #region ITransacao

        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Valor { get; set; }

        #endregion ITransacao

        public virtual Banco Banco { get; set; } 
    }

}