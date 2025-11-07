namespace SGF.Domain.Models
{
    public class Rotulo : Elemento
    {
        public override Elemento Clone()
        {
            Rotulo rotulo = new Rotulo();

            rotulo.Nome = this.Nome;
            rotulo.Descricao = this.Descricao;
            rotulo.CodigoTipoExibicao = this.CodigoTipoExibicao;
            rotulo.ExibirListagem = this.ExibirListagem;

            return rotulo;
        }
    }
}