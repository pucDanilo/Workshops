namespace PocketEntity.Core.Models
{

    public partial class Banco
    {
        public int BancoId { get; set; }
        public string Nome { get; set; }
        public string NumeroConta { get; set; }
        public int TipoConta { get; set; }
    }
}