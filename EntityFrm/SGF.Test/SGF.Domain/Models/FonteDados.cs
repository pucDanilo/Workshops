using System;
using System.Collections.Generic;

namespace SGF.Domain.Models
{
    public class FonteInterna : FonteDados
    {
        public FonteInterna(string nome, string descricao, string token, OrdemItens ordemItens)
            : base(nome, descricao, token, TipoFonteDados.FonteInterna)
        {
            OrdemItens = ordemItens;
            _valorFonteItens = new List<ValorFonte>();
        }

        protected FonteInterna()
        {
            _valorFonteItens = new List<ValorFonte>();
        }

        private readonly List<ValorFonte> _valorFonteItens;
        public IReadOnlyCollection<ValorFonte> Valores => _valorFonteItens;


        public void AdicionarValorFonte(string valor, string texto, bool ativo)
        {
            var item = new ValorFonte(Seq, valor, texto);
            if (!ativo)
                item.Desativar();
            _valorFonteItens.Add(item);
        }

         
        public OrdemItens OrdemItens { get; set; } 

        public FonteInterna Clone()
        {
            var fonteInterna = new FonteInterna();
            fonteInterna.Nome = this.Nome;
            fonteInterna.Descricao = this.Descricao;
            fonteInterna.Token = this.Token;

            foreach (var valor in this.Valores)
            {
                fonteInterna.AdicionarValorFonte(valor.Valor, valor.Texto, valor.Ativo);
            } 
            return fonteInterna;
        }

        internal void AdicionarItem(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
    public enum TipoFonteDados
    {
        FonteGlobal = 3,
        FonteInterna = 1,
        FonteExterna = 2
    }
    public class FonteDados
    {
        public long Seq { get; set; }
        public long SeqFormulario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Token { get; set; }
        public TipoFonteDados TipoFonteDados { get; private set; }
        public Formulario Formulario { get; set; }
        public IEnumerable<FonteDadosTipoFormulario> TiposFormularios { get; set; }
        public IEnumerable<CampoFonteDados> Campos { get; set; }
        public IEnumerable<ValorFonteInterna> Valores { get; set; }

        public bool Novo
        {
            get { return this.Seq == default(int); }
        }

        protected FonteDados()
        {
        }

        public FonteDados( string nome, string descricao, string token, TipoFonteDados tipoFonteDados)
        {
            Nome = nome;
            Descricao = descricao;
            Token = token;
            this.TipoFonteDados = tipoFonteDados;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
        }

        public FonteDados CloneFonteInterna()
        {
            var fonteInterna = new FonteDados();

            fonteInterna.Nome = this.Nome;
            fonteInterna.Descricao = this.Descricao;
            fonteInterna.Token = this.Token;
            var Valores = new List<ValorFonteInterna>();

            foreach (var valor in this.Valores)
            {
                Valores.Add(new ValorFonteInterna()
                {
                    Texto = valor.Texto,
                    Valor = valor.Valor
                });
            }
            fonteInterna.Valores = Valores;
            return fonteInterna;
        }
    }

    public partial class CampoFonteDados
    {
        public long Seq { get; set; }
        public long SeqFonteDados { get; set; }
        public string Nome { get; set; }
        public string Token { get; set; }
        public short CodigoDirecao { get; set; }

        public Direcao Direcao
        {
            get { return (Direcao)this.CodigoDirecao; }
            set { this.CodigoDirecao = (short)value; }
        }

        public FonteDados FonteDados { get; set; }
    }

    /*
    public class FonteExterna : FonteDados
    {
        public IEnumerable<CampoFonteDados> Campos { get; set; }
    }

    public class FonteInterna : FonteDados
    {
        public FonteInterna Clone()
        {
            var fonteInterna = new FonteInterna();

            fonteInterna.Nome = this.Nome;
            fonteInterna.Descricao = this.Descricao;
            fonteInterna.Token = this.Token;
            var Valores = new List<ValorFonteInterna>();

            foreach (var valor in this.Valores)
            {
                Valores.Add(new ValorFonteInterna()
                {
                    Texto = valor.Texto,
                    Valor = valor.Valor
                });
            }
            fonteInterna.Valores = Valores;
            return fonteInterna;
        }

        public IEnumerable<ValorFonteInterna> Valores { get; set; }
    }*/

    public partial class ValorFonteInterna
    {
        public long Seq { get; set; }
        public long SeqFonteDados { get; set; }
        public string Valor { get; set; }
        public string Texto { get; set; }
        public bool Ativo { get; set; }
        public FonteDados FonteDados { get; set; }
    }
}