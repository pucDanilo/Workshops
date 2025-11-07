using System.ComponentModel;

namespace SGF.Domain.Models
{
    public enum TipoComparacao : short
    {
        Igual = 1,

        Diferente = 2,

        Maior = 3,

        [Description("Maior ou igual")]
        MaiorIgual = 4,

        Menor = 5,

        [Description("Menor ou igual")]
        MenorIgual = 6,

        Contendo = 7,

        [Description("Inicia com")]
        IniciaCom = 8,

        [Description("Termina com")]
        TerminaCom = 9,

        [Description("Não preenchido")]
        NaoPreenchido = 10,

        Preenchido = 11
    }
}