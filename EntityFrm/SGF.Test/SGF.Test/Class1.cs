using SGF.Domain.Models;
using System;

namespace SGF.Test
{
    public class Class1
    {
        public Class1()
        {
            var formulario = Mock.FORMULARIO_ADM;
            formulario.AdicionarFonteDados(Mock.FONTE_1);
            // recupera as fontes de dados do formulário
            var FontesDados = this.BuscarFontesDadosFormulario(formulario.Seq).SMCToFixupCollection();

            // recupear as seções do formulário
            formulario.Secoes = this.BuscarSecoesFormulario(formulario.Seq).SMCToFixupCollection();

            // recupera os elementos de cada seção do formulário
            foreach (var secao in formulario.Secoes)
                secao.Elementos = this.BuscarElementosSecao(secao.Seq, true).SMCToFixupCollection();

            // retorna o formulario completo
            return formulario;
            formulario.add 


        }
    }
}
