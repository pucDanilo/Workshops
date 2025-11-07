namespace SGF.Domain.Models
{
    public class Visao
    {
        public long Seq { get; set; }
        public long SeqTipoFormulario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Token { get; set; }
        public bool Ativo { get; set; }
        protected Visao()
        {

        }

        public Visao(string nome, string descricao, string token)
        {
            Nome = nome;
            Descricao = descricao;
            Token = token;
            Ativo = true;
        }
    }
}