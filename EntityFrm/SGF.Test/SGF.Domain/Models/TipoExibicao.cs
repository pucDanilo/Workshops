using System.ComponentModel;

namespace SGF.Domain.Models
{
    public enum OrdemItens : short
    {
        Nenhum = 0,

        Valor = 1,

        Texto = 2
    }

    public enum NomeLookup : short
    {
        Nenhum = 0,

        [Description("Unidade")]
        Unidade = 1,

        [Description("Usuário")]
        Usuario = 2,

        [Description("Área de conhecimento")]
        AreaConhecimento = 3,

        [Description("Docente")]
        Docente = 4,

        [Description("Aluno")]
        Aluno = 5,

        [Description("Disciplina SAL ")]
        DisciplinaSAL = 6
    }

    public enum FormatoNumero : short
    {
        Nenhum = 0,
        Inteiro = 1,
        Decimal = 2,
        Moeda = 3
    }

    public enum ReferenciaData : short
    {
        Nenhum = 0,

        [Description("Data corrente")]
        DataCorrente = 1,

        [Description("Data fixa")]
        DataFixa = 2
    }

    public enum FormatoTexto : short
    {
        Nenhum = 0,

        [Description("Customizado")]
        Customizado = 99,

        [Description("CPF")]
        Cpf = 1,

        [Description("CNPJ")]
        Cnpj = 2,

        [Description("Email")]
        Email = 3,

        [Description("URL")]
        Url = 4,

        [Description("Senha")]
        Senha = 5,

        [Description("Html")]
        Html = 6,

        [Description("Telefone")]
        Telefone = 7
    }

    public enum TipoElemento : short
    {
        Bloco = 1,
        Campo = 2,
        Botao = 3,
        Rotulo = 4
    }

    public enum TipoAcao
    {
        Nenhuma,

        [Description("Salvar o formulário")]
        SalvarFormulario,

        [Description("Validar o formulário")]
        ValidarFormulário,

        [Description("Abrir uma seção")]
        AbrirSecao,

        [Description("Abrir um bloco em janela")]
        AbrirBlocoJanela,

        [Description("Atualizar um elemento com fonte de dados")]
        AtualizarElementoFonteDados,

        [Description("Adicionar um item em coleção")]
        AdicionarItemColecao,

        [Description("Editar um item em coleção")]
        EditarItemColecao,

        [Description("Excluir um item em coleção")]
        ExcluirItemColecao,

        [Description("Executar ação customizada")]
        AcaoCustomizada,

        [Description("Importar Planilha")]
        ImportarPlanilha,

        [Description("Exportar Planilha")]
        ExportarPlanilha
    }

    public enum LayoutBloco : short
    {
        Linear = 1,

        Tabela = 2,

        Matriz = 3
    }

    public enum FormatoData : short
    {
        [Description("Data e Hora")]
        DataHora = 1,

        Data = 2,
        Hora = 3
    }

    public enum TipoArquivo : short
    {
        Anexo = 1,

        Imagem = 2
    }

    public enum FormatoObjetivo : short
    {
        [Description("Combo Box")]
        Combo = 1,

        [Description("Radio Button (horizontal)")]
        Radio = 2,

        [Description("Check Box (horizontal)")]
        CheckBox = 3,

        [Description("Radio Button (vertical)")]
        RadioVertical = 4,

        [Description("Check Box (vertical)")]
        CheckBoxVertical = 5
    }

    public enum TipoCampo : short
    {
        Texto = 1,

        [Description("Número")]
        Numero = 2,

        [Description("Data e hora")]
        DataHora = 3,

        Objetivo = 4,

        Arquivo = 5,

        CPF = 6,

        CNPJ = 7,

        Email = 8,

        [Description("Lookup Usuário")]
        UsuarioSAS = 9,

        [Description("Lookup Unidade")]
        Unidade = 10
    }

    public enum TipoExibicao : short
    {
        Nome = 1,

        [Description("Descrição")]
        Descricao = 2,

        [Description("Nome e descrição")]
        NomeDescricao = Nome | Descricao,

        Imagem = 4,

        [Description("Nome e imagem")]
        NomeImagem = Nome | Imagem,

        [Description("Descrição e imagem")]
        DescricaoImagem = Descricao | Imagem,

        [Description("Nome, descrição e imagem")]
        NomeDescricaoImagem = Nome | Descricao | Imagem
    }
}