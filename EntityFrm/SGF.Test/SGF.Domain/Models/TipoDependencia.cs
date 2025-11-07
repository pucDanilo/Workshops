using System.ComponentModel;

namespace SGF.Domain.Models
{
    public enum Direcao : short
    {
        Entrada = 1,

        [Description("Saída")]
        Saida = 2,

        [Description("Entrada e saída")]
        EntradaSaida = 3
    }

    public enum SituacaoFormulario : short
    {
        Nenhum = 0,

        [Description("Em manutenção")]
        Em_Manutencao = 1,

        Liberado = 2
    }

    public enum TipoDependencia : short
    {
        Obrigatoriedade = 1,

        Visibilidade = 2,

        [Description("Valor padrão")]
        ValorPadrao = 3,

        [Description("Somente leitura")]
        SomenteLeitura = 4,

        [Description("Ocultar na impressão")]
        OcultarImpressao = 5
    }
}