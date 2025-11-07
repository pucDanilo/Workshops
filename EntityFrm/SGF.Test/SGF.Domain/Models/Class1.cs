namespace SGF.Domain.Models
{
    public class Mock
    {
        //public static TipoFormulario SEQ_TIPO_FORMULARIO_ADM => new TipoFormulario("Análise Administrativa", "Tipo de formulário para cadastro de Análise Administrativa", "ANALISE_ADM");

        //public static Formulario FORMULARIO_ADM => new Formulario("Análise Administrativa Estágio Obrigatório", "Análise Administrativa Estágio Obrigatório", Mock.SEQ_TIPO_FORMULARIO_ADM.Seq);
        public static Formulario Fabrica_1()
        {
            var tipoFormulario1 = new TipoFormulario("Análise Administrativa e/ou Ac", "Tipo de formulário para cadast", "ANALISE_SGE", 54836, 4, 18, 10);
            tipoFormulario1.AdicionarVisao("Padrão", null, "PADRAO");

            var form = new Formulario("Analise Administrativa de Concedente", "Analise Administrativa de Concedente"); 
            form.AtualizarTipoFormulario(tipoFormulario1);
            var fonte_1 = new FonteInterna("Sim.Nao.Acordado.NaoAplica", "Opções: Sim, Nâo, Conforme Aco", "SIMNAOACORDADONAOAPLICA", (OrdemItens)1);
            fonte_1.AdicionarItem("Conforme acordado", "Conforme acordado");
            fonte_1.AdicionarItem("Não", "Não");
            fonte_1.AdicionarItem("Não se aplica", "Não se aplica");
            fonte_1.AdicionarItem("Sim", "Sim");
            var fonte_2 = new FonteInterna("Ativa.Inapta.NaoAplica", null, "ATIVAINAPTANAOAPLICA", (OrdemItens)1);

            fonte_2.AdicionarItem("Ativa", "Ativa");
            fonte_2.AdicionarItem("Inapta", "Inapta (Qualquer outra)");
            fonte_2.AdicionarItem("Não se aplica", "Não se Aplica");
            var fonte_3 = new FonteInterna("Sim.Nao.NaoAplica", null, "SIMNAONAOAPLICA", (OrdemItens)1);
            fonte_3.AdicionarItem("Não", "Não");
            fonte_3.AdicionarItem("Não se aplica", "Não se aplica");
            fonte_3.AdicionarItem("Sim", "Sim");
            var fonte_4 = new FonteInterna("Sim.Nao.NaoPossuiRegistro.NaoA", null, "SIMNAONAOPOSSUIREGISTRONAOAPLI", (OrdemItens)1);
            fonte_4.AdicionarItem("Não", "Não");
            fonte_4.AdicionarItem("Não Aplica", "Não aplica");
            fonte_4.AdicionarItem("Não Possui Registro", "Não possui registro");
            fonte_4.AdicionarItem("Sim", "Sim");
            var fonte_5 = new FonteInterna("Sim.Nao.NaoInformado", null, "SIMNAONAOINFORMADO", (OrdemItens)1);
            fonte_5.AdicionarItem("Não", "Não");
            fonte_5.AdicionarItem("Não Informado", "Não Informado");
            fonte_5.AdicionarItem("Sim", "Sim");

            form.VincularFonte(fonte_1);
            form.VincularFonte(fonte_2);
            form.VincularFonte(fonte_3);
            form.VincularFonte(fonte_4);
            form.VincularFonte(fonte_5);



            var Secao2 = new Secao(2, "Dados de pessoa física", "DADOS_DE_PESSOA_FISICA");
            var Secao1 = new Secao(1, "Dados de pessoa jurídica", "DADOS_DE_PESSOA_JURIDICA");
            var Secao3 = new Secao(3, "Informações gerais", "INFORMACOES_GERAIS");

            Secao2.AdicionarCampo(1, "O nome informado corresponde ao cadastro da Receita Federal?");
            Secao2.AdicionarCampo(2, "Existe alguma confirmação do endereço informado?");
            Secao2.AdicionarCampo(3, "O curso de formação do concedente foi informado corretamente?");
            Secao2.AdicionarCampo(4, "As informações sobre o registro profissional foram cadastradas corretamente?");
            Secao1.AdicionarCampo(1, "A razão social informada corresponde ao cadastro da Receita Federal?");
            Secao1.AdicionarCampo(2, "O nome fantasia informado corresponde ao cadastro da Receita Federal?");
            Secao1.AdicionarCampo(3, "O endereço informado corresponde ao cadastro da Receita Federal?");
            Secao1.AdicionarCampo(4, "Qual a situação cadastral junto à Receita Federal?");
            Secao3.AdicionarCampo(1, "O e-mail informado é válido?");
            Secao3.AdicionarCampo(2, "O telefone informado está correto?");
            Secao3.AdicionarCampo(3, "Informações complementares");


            form.AdicionarSecao(1, "Dados de pessoa jurídica", "DADOS_DE_PESSOA_JURIDICA");
            form.AdicionarSecao(2, "Dados de pessoa física", "DADOS_DE_PESSOA_FISICA");
            form.AdicionarSecao(3, "Informações gerais", "INFORMACOES_GERAIS");
        }
        public static Formulario Fabrica22()
        {
            var tipoFormulario12 = new TipoFormulario("Formulários de Inscrição - Pro", "Formulários de Inscrição - Pro", "FORMULARIO_GPI_PPGRI", 58504, 9, 21, 1);
            tipoFormulario12.AdicionarVisao("PADRAO", null, "PADRAO");

            var form = new Formulario("Ficha de Inscrição - Relações Internacionais 1/2016", "Ficha de Inscrição - Programa de Pós-graduação em Relações Internacionais 1/2016");
            form.AtualizarTipoFormulario(tipoFormulario12);

            //form.AdicionarFonteInterna("Positivo/Negativo", null, "POSITIVONEGATIVO", (OrdemItens)1);
            form.AdicionarSecao(1, "Ficha de Inscrição", "FICHA_DE_INSCRICAO");

            return form;
        }
    }
}