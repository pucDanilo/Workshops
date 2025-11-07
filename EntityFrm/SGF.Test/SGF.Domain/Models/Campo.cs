namespace SGF.Domain.Models
{
    public class Campo : Elemento
    {
        protected Campo()
        {

        }
        public Campo(//short codigoTipoCampo, short? codigoFormatoData, short? codigoFormatoObjetivo, short? codigoTipoArquivo, 
            string textoAjuda, 
            string mascara, 
            string valorPadrao, 
            short? maximoCaracteres, short? quantidadeCasasDecimais, 
            bool multiplasLinhas,
            string extensoesValidas)
        {
            CodigoTipoCampo = codigoTipoCampo;
            CodigoFormatoData = codigoFormatoData;
            CodigoFormatoObjetivo = codigoFormatoObjetivo;
            CodigoTipoArquivo = codigoTipoArquivo;
            TextoAjuda = textoAjuda;
            Mascara = mascara;
            ValorPadrao = valorPadrao;
            MaximoCaracteres = maximoCaracteres;
            QuantidadeCasasDecimais = quantidadeCasasDecimais;
            MultiplasLinhas = multiplasLinhas;
            ExtensoesValidas = extensoesValidas; 
            
        }

        public short CodigoTipoCampo { get; set; }
        public short? CodigoFormatoData { get; set; }
        public short? CodigoFormatoObjetivo { get; set; }
        public short? CodigoTipoArquivo { get; set; }
        public string TextoAjuda { get; set; }
        public string Mascara { get; set; }
        public string ValorPadrao { get; set; }
        public short? MaximoCaracteres { get; set; }
        public short? QuantidadeCasasDecimais { get; set; }
        public bool MultiplasLinhas { get; set; }
        public string ExtensoesValidas { get; set; } 
        public TipoCampo Tipo
        {
            get { return (TipoCampo)this.CodigoTipoCampo; }
            set { this.CodigoTipoCampo = (short)value; }
        }

        public FormatoData? FormatoData
        {
            get
            {
                if (this.Tipo != TipoCampo.DataHora || !this.CodigoFormatoData.HasValue)
                    return null;
                return (FormatoData)this.CodigoFormatoData.Value;
            }
            set
            {
                this.CodigoFormatoData = (short?)value;
            }
        }

        public FormatoObjetivo? FormatoObjetivo
        {
            get
            {
                if (this.Tipo != TipoCampo.Objetivo || !this.CodigoFormatoObjetivo.HasValue)
                    return null;
                return (FormatoObjetivo)this.CodigoFormatoObjetivo.Value;
            }
            set
            {
                this.CodigoFormatoObjetivo = (short?)value;
            }
        }

        public TipoArquivo? TipoArquivo
        {
            get
            {
                if (this.Tipo != TipoCampo.Arquivo || !this.CodigoTipoArquivo.HasValue)
                    return null;
                return (TipoArquivo)this.CodigoTipoArquivo.Value;
            }
            set
            {
                this.CodigoTipoArquivo = (short?)value;
            }
        }

        public Arquivo ArquivoPadrao { get; set; }

        public override Elemento Clone()
        {
            Campo campo = new Campo();

            campo.Nome = this.Nome;
            campo.Descricao = this.Descricao;
            campo.CodigoTipoExibicao = this.CodigoTipoExibicao;

            campo.CodigoTipoCampo = this.CodigoTipoCampo;
            campo.TextoAjuda = this.TextoAjuda;
            campo.ValorPadrao = this.ValorPadrao;
            campo.ExibirListagem = this.ExibirListagem;

            // texto
            if (this.Tipo == TipoCampo.Texto)
            {
                campo.MaximoCaracteres = this.MaximoCaracteres;
                campo.MultiplasLinhas = this.MultiplasLinhas;
                campo.Mascara = this.Mascara;
            }

            // numérico
            if (this.Tipo == TipoCampo.Numero)
            {
                campo.QuantidadeCasasDecimais = this.QuantidadeCasasDecimais;
            }

            // datahora
            if (this.Tipo == TipoCampo.DataHora)
            {
                campo.CodigoFormatoData = this.CodigoFormatoData;
            }

            // objetivo
            if (this.Tipo == TipoCampo.Objetivo)
            {
                campo.CodigoFormatoObjetivo = this.CodigoFormatoObjetivo;
            }

            // tipo arquivo
            if (this.Tipo == TipoCampo.Arquivo)
            {
                campo.CodigoTipoArquivo = this.CodigoTipoArquivo;
                campo.ExtensoesValidas = this.ExtensoesValidas;
            }

            // tipo arquivo
            if (this.Tipo == TipoCampo.CNPJ)
            {
                campo.Mascara = "99.999.999/9999-99";
            }

            // tipo arquivo
            if (this.Tipo == TipoCampo.CPF)
            {
                campo.Mascara = "999.999.999-99";
            }

            return campo;
        }
    }
}