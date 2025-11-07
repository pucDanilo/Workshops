using BancoHistorico.Cadastros.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BancoHistorico
{
    public class CadastroContext : DbContext
    {
        public DbSet<Solucao> Solucao { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tabela> Tabelas { get; set; }
        public DbSet<Indice> Indices { get; set; }
        public DbSet<Coluna> Colunas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolDB;Integrated Security=True");
        }
    }

    internal class Program
    {
        private static CadastroContext ctx;

        private static void Main(string[] args)
        {
            ctx = new CadastroContext();

            var projeto = ctx.Projetos.Where(a => a.Name == "GAD").FirstOrDefault();

            if (projeto == null)
            {
                var solucao = new Solucao("AssinaturaDigital");
                solucao.AdicionarProjeto("GAD");
                ctx.Solucao.Add(solucao);
                ctx.SaveChanges();
            } 
                projeto.AdicionarTabela("", "", 23723187, "historico_status_certificado");
                projeto.AdicionarColuna(23723187, "", "", 1, "seq_historico_status_certificado", "bigint", 8);
                projeto.AdicionarColuna(23723187, "", "", 2, "seq_certificado", "bigint", 8);
                projeto.AdicionarColuna(23723187, "", "", 4, "ind_atual", "bit", 1);
                projeto.AdicionarColuna(23723187, "", "", 6, "dat_inclusao", "datetime", 8);
                projeto.AdicionarColuna(23723187, "", "", 7, "usu_inclusao", "varchar", 60);
                projeto.AdicionarColuna(23723187, "", "", 8, "dat_alteracao", "datetime", 8);
                projeto.AdicionarColuna(23723187, "", "", 9, "usu_alteracao", "varchar", 60);
                projeto.AdicionarColuna(23723187, "", "", 10, "dat_status_certificadora", "datetime", 8);
                projeto.AdicionarColuna(23723187, "", "", 11, "idt_dom_status_certificado", "smallint", 2);
            projeto.AdicionarIndex(1, 23723187, "PK_historico_status_certificado", "", true, true);
            projeto.AdicionarIndex(2, 23723187, "IX_historico_status_certificado_01", "", false, false);
            /*

*/



            projeto.AdicionarTabela("", "", 48771281, "documento_participante_assinatura");
                projeto.AdicionarTabela("", "", 93295442, "participante_sistema_origem");
                projeto.AdicionarTabela("", "", 269296069, "documento_aprovador");
                projeto.AdicionarTabela("", "", 413296582, "documento_observador");
                projeto.AdicionarTabela("", "", 557297095, "certificadora_pasta");
                projeto.AdicionarTabela("", "", 569821142, "sistema_origem_certificadora");
                projeto.AdicionarTabela("", "", 873822225, "certificadora_atuacao_participante");
                projeto.AdicionarTabela("", "", 1012250711, "documento");
                projeto.AdicionarTabela("", "", 1060250882, "documento_assinado");
                projeto.AdicionarTabela("", "", 1081822966, "motivo_recusa_assinatura");
                projeto.AdicionarTabela("", "", 1204251395, "documento_participante");
                projeto.AdicionarTabela("", "", 1205631388, "dominio");
                projeto.AdicionarTabela("", "", 1261299603, "configuracao_notificacao");
                projeto.AdicionarTabela("", "", 1269631616, "certificadora");
                projeto.AdicionarTabela("", "", 1273823650, "configuracao_documento_academico");
                projeto.AdicionarTabela("", "", 1314155777, "parametro_certificadora");
                projeto.AdicionarTabela("", "", 1348251908, "historico_documento_assinado");
                projeto.AdicionarTabela("", "", 1353823935, "documento_academico");
                projeto.AdicionarTabela("", "", 1433824220, "historico_status_documento_academico");
                projeto.AdicionarTabela("", "", 1488776411, "tag");
                projeto.AdicionarTabela("", "", 1492252421, "historico_documento_participante");
                projeto.AdicionarTabela("", "", 1515204498, "status");
                projeto.AdicionarTabela("", "", 1541632585, "participante");
                projeto.AdicionarTabela("", "", 1568776696, "Logger");
                projeto.AdicionarTabela("", "", 1604252820, "historico_status_documento");
                projeto.AdicionarTabela("", "", 1621632870, "certificado");
                projeto.AdicionarTabela("", "", 1623728887, "arquivo");
                projeto.AdicionarTabela("", "", 1735729286, "CargaDocumento");
                projeto.AdicionarTabela("", "", 1764253390, "documento_tag");
                projeto.AdicionarTabela("", "", 1865825759, "configuracao_documento_academico_historico");
                projeto.AdicionarTabela("", "", 1906157886, "certificadora_integracao");
                projeto.AdicionarTabela("", "", 1952778064, "sistema_origem");
                projeto.AdicionarTabela("", "", 2112778634, "parametro_sistema_origem");
                ctx.Projetos.Update(projeto);
                ctx.SaveChanges();

            

            // mock();
        }

        private static void mock()
        {
            var solucao = GetSolucao("AssinaturaDigital");
            var projeto = GetProjeto(solucao.Id, "GAD");


            var tabela23723187 = GetTabela(projeto.Id, "", "", 23723187, "historico_status_certificado");

            var coluna_1_23723187 = GetColuna(tabela23723187.Id, "", "", 1, "seq_historico_status_certificado", "bigint", 8);

            Getindex(coluna_1_23723187.Id, "PK_historico_status_certificado", "", true, true);
            var coluna_2_23723187 = GetColuna(tabela23723187.Id, "", "", 2, "seq_certificado", "bigint", 8);

            Getindex(coluna_2_23723187.Id, "IX_historico_status_certificado_01", "", false, false);
            var coluna_4_23723187 = GetColuna(tabela23723187.Id, "", "", 4, "ind_atual", "bit", 1);

            var coluna_6_23723187 = GetColuna(tabela23723187.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_23723187 = GetColuna(tabela23723187.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_23723187 = GetColuna(tabela23723187.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_23723187 = GetColuna(tabela23723187.Id, "", "", 9, "usu_alteracao", "varchar", 60);

            var coluna_10_23723187 = GetColuna(tabela23723187.Id, "", "", 10, "dat_status_certificadora", "datetime", 8);

            var coluna_11_23723187 = GetColuna(tabela23723187.Id, "", "", 11, "idt_dom_status_certificado", "smallint", 2);


            var tabela48771281 = GetTabela(projeto.Id, "", "", 48771281, "documento_participante_assinatura");

            var coluna_1_48771281 = GetColuna(tabela48771281.Id, "", "", 1, "seq_documento_participante_assinatura", "bigint", 8);

            Getindex(coluna_1_48771281.Id, "PK_documento_participante_assinatura", "", true, true);
            var coluna_2_48771281 = GetColuna(tabela48771281.Id, "", "", 2, "seq_documento_participante", "bigint", 8);

            var coluna_3_48771281 = GetColuna(tabela48771281.Id, "", "", 3, "seq_protocolo", "uniqueidentifier", 16);

            var coluna_4_48771281 = GetColuna(tabela48771281.Id, "", "", 4, "dat_inclusao", "datetime", 8);

            var coluna_5_48771281 = GetColuna(tabela48771281.Id, "", "", 5, "usu_inclusao", "varchar", 60);

            var coluna_6_48771281 = GetColuna(tabela48771281.Id, "", "", 6, "dat_alteracao", "datetime", 8);

            var coluna_7_48771281 = GetColuna(tabela48771281.Id, "", "", 7, "usu_alteracao", "varchar", 60);


            var tabela93295442 = GetTabela(projeto.Id, "", "", 93295442, "participante_sistema_origem");

            var coluna_1_93295442 = GetColuna(tabela93295442.Id, "", "", 1, "seq_participante_sistema_origem", "bigint", 8);

            Getindex(coluna_1_93295442.Id, "PK_participante_sistema_origem", "", true, true);
            var coluna_2_93295442 = GetColuna(tabela93295442.Id, "", "", 2, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_2_93295442.Id, "UN_participante_sistema_origem_01", "", true, false);
            var coluna_3_93295442 = GetColuna(tabela93295442.Id, "", "", 3, "seq_participante", "bigint", 8);

            Getindex(coluna_3_93295442.Id, "UN_participante_sistema_origem_01", "", true, false);
            Getindex(coluna_3_93295442.Id, "IX_participante_sistema_origem_01", "", false, false);
            var coluna_4_93295442 = GetColuna(tabela93295442.Id, "", "", 4, "idt_dom_tipo_participante_sistema_origem", "smallint", 2);

            Getindex(coluna_4_93295442.Id, "UN_participante_sistema_origem_01", "", true, false);
            var coluna_5_93295442 = GetColuna(tabela93295442.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_93295442 = GetColuna(tabela93295442.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_93295442 = GetColuna(tabela93295442.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_93295442 = GetColuna(tabela93295442.Id, "", "", 8, "usu_alteracao", "varchar", 60);


            var tabela269296069 = GetTabela(projeto.Id, "", "", 269296069, "documento_aprovador");

            var coluna_1_269296069 = GetColuna(tabela269296069.Id, "", "", 1, "seq_documento_aprovador", "bigint", 8);

            Getindex(coluna_1_269296069.Id, "PK_documento_aprovador", "", true, true);
            var coluna_2_269296069 = GetColuna(tabela269296069.Id, "", "", 2, "seq_documento", "bigint", 8);

            Getindex(coluna_2_269296069.Id, "UN_documento_aprovador_01", "", true, false);
            var coluna_3_269296069 = GetColuna(tabela269296069.Id, "", "", 3, "seq_participante", "bigint", 8);

            Getindex(coluna_3_269296069.Id, "UN_documento_aprovador_01", "", true, false);
            Getindex(coluna_3_269296069.Id, "IX_documento_aprovador_02", "", false, false);
            var coluna_4_269296069 = GetColuna(tabela269296069.Id, "", "", 4, "dat_inclusao", "datetime", 8);

            var coluna_5_269296069 = GetColuna(tabela269296069.Id, "", "", 5, "usu_inclusao", "varchar", 60);

            var coluna_6_269296069 = GetColuna(tabela269296069.Id, "", "", 6, "dat_alteracao", "datetime", 8);

            var coluna_7_269296069 = GetColuna(tabela269296069.Id, "", "", 7, "usu_alteracao", "varchar", 60);


            var tabela413296582 = GetTabela(projeto.Id, "", "", 413296582, "documento_observador");

            var coluna_1_413296582 = GetColuna(tabela413296582.Id, "", "", 1, "seq_documento_observador", "bigint", 8);

            Getindex(coluna_1_413296582.Id, "PK_documento_observador", "", true, true);
            var coluna_2_413296582 = GetColuna(tabela413296582.Id, "", "", 2, "seq_documento", "bigint", 8);

            var coluna_3_413296582 = GetColuna(tabela413296582.Id, "", "", 3, "nom_observador", "varchar", 255);

            var coluna_4_413296582 = GetColuna(tabela413296582.Id, "", "", 4, "dsc_email_observador", "varchar", 100);

            var coluna_5_413296582 = GetColuna(tabela413296582.Id, "", "", 5, "ind_permite_notificacao", "bit", 1);

            var coluna_6_413296582 = GetColuna(tabela413296582.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_413296582 = GetColuna(tabela413296582.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_413296582 = GetColuna(tabela413296582.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_413296582 = GetColuna(tabela413296582.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela557297095 = GetTabela(projeto.Id, "", "", 557297095, "certificadora_pasta");

            var coluna_1_557297095 = GetColuna(tabela557297095.Id, "", "", 1, "seq_certificadora_pasta", "bigint", 8);

            Getindex(coluna_1_557297095.Id, "PK_certificadora_pasta", "", true, true);
            var coluna_2_557297095 = GetColuna(tabela557297095.Id, "", "", 2, "seq_certificadora_pasta_raiz", "bigint", 8);

            var coluna_3_557297095 = GetColuna(tabela557297095.Id, "", "", 3, "seq_certificadora", "bigint", 8);

            var coluna_4_557297095 = GetColuna(tabela557297095.Id, "", "", 4, "seq_sistema_origem", "bigint", 8);

            var coluna_5_557297095 = GetColuna(tabela557297095.Id, "", "", 5, "nom_pasta", "varchar", 50);

            var coluna_6_557297095 = GetColuna(tabela557297095.Id, "", "", 6, "dsc_caminho", "varchar", 500);

            var coluna_7_557297095 = GetColuna(tabela557297095.Id, "", "", 7, "dsc_pasta", "varchar", 1000);

            var coluna_8_557297095 = GetColuna(tabela557297095.Id, "", "", 8, "ind_padrao", "bit", 1);

            var coluna_9_557297095 = GetColuna(tabela557297095.Id, "", "", 9, "cod_pasta", "varchar", 200);

            var coluna_10_557297095 = GetColuna(tabela557297095.Id, "", "", 10, "dat_inclusao", "datetime", 8);

            var coluna_11_557297095 = GetColuna(tabela557297095.Id, "", "", 11, "usu_inclusao", "varchar", 60);

            var coluna_12_557297095 = GetColuna(tabela557297095.Id, "", "", 12, "dat_alteracao", "datetime", 8);

            var coluna_13_557297095 = GetColuna(tabela557297095.Id, "", "", 13, "usu_alteracao", "varchar", 60);


            var tabela569821142 = GetTabela(projeto.Id, "", "", 569821142, "sistema_origem_certificadora");

            var coluna_1_569821142 = GetColuna(tabela569821142.Id, "", "", 1, "seq_sistema_origem_certificadora", "bigint", 8);

            Getindex(coluna_1_569821142.Id, "PK_sistema_origem_certificadora", "", true, true);
            var coluna_2_569821142 = GetColuna(tabela569821142.Id, "", "", 2, "seq_certificadora", "bigint", 8);

            Getindex(coluna_2_569821142.Id, "UN_sistema_origem_certificadora_01", "", true, false);
            Getindex(coluna_2_569821142.Id, "IX_sistema_origem_certificadora_01", "", false, false);
            var coluna_3_569821142 = GetColuna(tabela569821142.Id, "", "", 3, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_3_569821142.Id, "UN_sistema_origem_certificadora_01", "", true, false);
            var coluna_4_569821142 = GetColuna(tabela569821142.Id, "", "", 4, "num_ordem_assinatura", "int", 4);

            var coluna_5_569821142 = GetColuna(tabela569821142.Id, "", "", 5, "dsc_token_assinante", "varchar", 255);

            var coluna_6_569821142 = GetColuna(tabela569821142.Id, "", "", 6, "cod_assinante", "varchar", 255);

            var coluna_7_569821142 = GetColuna(tabela569821142.Id, "", "", 7, "dat_inclusao", "datetime", 8);

            var coluna_8_569821142 = GetColuna(tabela569821142.Id, "", "", 8, "usu_inclusao", "varchar", 60);

            var coluna_9_569821142 = GetColuna(tabela569821142.Id, "", "", 9, "dat_alteracao", "datetime", 8);

            var coluna_10_569821142 = GetColuna(tabela569821142.Id, "", "", 10, "usu_alteracao", "varchar", 60);

            var coluna_11_569821142 = GetColuna(tabela569821142.Id, "", "", 11, "cod_pasta_certificadora", "varchar", 255);


            var tabela873822225 = GetTabela(projeto.Id, "", "", 873822225, "certificadora_atuacao_participante");

            var coluna_1_873822225 = GetColuna(tabela873822225.Id, "", "", 1, "seq_certificadora_atuacao_participante", "bigint", 8);

            Getindex(coluna_1_873822225.Id, "PK_certificadora_atuacao_participante", "", true, true);
            var coluna_2_873822225 = GetColuna(tabela873822225.Id, "", "", 2, "seq_certificadora", "bigint", 8);

            Getindex(coluna_2_873822225.Id, "UN_certificadora_atuacao_participante_01", "", true, false);
            var coluna_3_873822225 = GetColuna(tabela873822225.Id, "", "", 3, "dsc_token_atuacao", "varchar", 255);

            Getindex(coluna_3_873822225.Id, "UN_certificadora_atuacao_participante_01", "", true, false);
            var coluna_4_873822225 = GetColuna(tabela873822225.Id, "", "", 4, "dsc_atuacao_participante", "varchar", 255);

            var coluna_5_873822225 = GetColuna(tabela873822225.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_873822225 = GetColuna(tabela873822225.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_873822225 = GetColuna(tabela873822225.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_873822225 = GetColuna(tabela873822225.Id, "", "", 8, "usu_alteracao", "varchar", 60);


            var tabela1012250711 = GetTabela(projeto.Id, "", "", 1012250711, "documento");

            var coluna_1_1012250711 = GetColuna(tabela1012250711.Id, "", "", 1, "seq_documento", "bigint", 8);

            Getindex(coluna_1_1012250711.Id, "PK_documento", "", true, true);
            var coluna_2_1012250711 = GetColuna(tabela1012250711.Id, "", "", 2, "nom_documento", "varchar", 255);

            var coluna_5_1012250711 = GetColuna(tabela1012250711.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1012250711 = GetColuna(tabela1012250711.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1012250711 = GetColuna(tabela1012250711.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1012250711 = GetColuna(tabela1012250711.Id, "", "", 8, "usu_alteracao", "varchar", 60);

            var coluna_10_1012250711 = GetColuna(tabela1012250711.Id, "", "", 10, "dsc_documento", "varchar", -1);

            var coluna_13_1012250711 = GetColuna(tabela1012250711.Id, "", "", 13, "ind_rastreabilidade", "bit", 1);

            var coluna_14_1012250711 = GetColuna(tabela1012250711.Id, "", "", 14, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_14_1012250711.Id, "IX_documento_01", "", false, false);
            var coluna_15_1012250711 = GetColuna(tabela1012250711.Id, "", "", 15, "ind_exige_aprovacao", "bit", 1);


            var tabela1060250882 = GetTabela(projeto.Id, "", "", 1060250882, "documento_assinado");

            var coluna_1_1060250882 = GetColuna(tabela1060250882.Id, "", "", 1, "seq_documento_assinado", "bigint", 8);

            Getindex(coluna_1_1060250882.Id, "PK_documento_assinado", "", true, true);
            Getindex(coluna_1_1060250882.Id, "ix_documento_assinado_01", "", false, false);
            var coluna_3_1060250882 = GetColuna(tabela1060250882.Id, "", "", 3, "seq_documento", "bigint", 8);

            Getindex(coluna_3_1060250882.Id, "ix_documento_assinado_01", "", false, false);
            Getindex(coluna_3_1060250882.Id, "UN_documento_assinado_01", "", true, false);
            var coluna_4_1060250882 = GetColuna(tabela1060250882.Id, "", "", 4, "dsc_documento_id", "varchar", 255);

            var coluna_5_1060250882 = GetColuna(tabela1060250882.Id, "", "", 5, "dsc_chave_certificadora", "varchar", 255);

            var coluna_6_1060250882 = GetColuna(tabela1060250882.Id, "", "", 6, "dsc_url_assinatura", "varchar", 255);

            var coluna_7_1060250882 = GetColuna(tabela1060250882.Id, "", "", 7, "dsc_upload_id", "varchar", 255);

            var coluna_8_1060250882 = GetColuna(tabela1060250882.Id, "", "", 8, "dat_inclusao", "datetime", 8);

            var coluna_9_1060250882 = GetColuna(tabela1060250882.Id, "", "", 9, "usu_inclusao", "varchar", 60);

            var coluna_10_1060250882 = GetColuna(tabela1060250882.Id, "", "", 10, "dat_alteracao", "datetime", 8);

            var coluna_11_1060250882 = GetColuna(tabela1060250882.Id, "", "", 11, "usu_alteracao", "varchar", 60);

            var coluna_12_1060250882 = GetColuna(tabela1060250882.Id, "", "", 12, "dat_ultima_sincronizacao", "datetime", 8);

            var coluna_13_1060250882 = GetColuna(tabela1060250882.Id, "", "", 13, "num_sincronizacao", "int", 4);

            var coluna_14_1060250882 = GetColuna(tabela1060250882.Id, "", "", 14, "seq_certificadora_pasta", "bigint", 8);

            var coluna_15_1060250882 = GetColuna(tabela1060250882.Id, "", "", 15, "seq_certificadora", "bigint", 8);

            Getindex(coluna_15_1060250882.Id, "IX_documento_assinado_02", "", false, false);
            var coluna_16_1060250882 = GetColuna(tabela1060250882.Id, "", "", 16, "ord_documento_assinado", "smallint", 2);

            Getindex(coluna_16_1060250882.Id, "UN_documento_assinado_01", "", true, false);

            var tabela1081822966 = GetTabela(projeto.Id, "", "", 1081822966, "motivo_recusa_assinatura");

            var coluna_1_1081822966 = GetColuna(tabela1081822966.Id, "", "", 1, "seq_motivo_recusa_assinatura", "bigint", 8);

            Getindex(coluna_1_1081822966.Id, "PK_motivo_recusa_assinatura", "", true, true);
            var coluna_2_1081822966 = GetColuna(tabela1081822966.Id, "", "", 2, "dsc_motivo_recusa_assinatura", "varchar", 255);

            Getindex(coluna_2_1081822966.Id, "UN_motivo_recusa_assinatura_01", "", true, false);
            var coluna_3_1081822966 = GetColuna(tabela1081822966.Id, "", "", 3, "ind_exige_observacao", "bit", 1);

            var coluna_4_1081822966 = GetColuna(tabela1081822966.Id, "", "", 4, "ind_ativo", "bit", 1);

            var coluna_5_1081822966 = GetColuna(tabela1081822966.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1081822966 = GetColuna(tabela1081822966.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1081822966 = GetColuna(tabela1081822966.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1081822966 = GetColuna(tabela1081822966.Id, "", "", 8, "usu_alteracao", "varchar", 60);


            var tabela1204251395 = GetTabela(projeto.Id, "", "", 1204251395, "documento_participante");

            var coluna_1_1204251395 = GetColuna(tabela1204251395.Id, "", "", 1, "seq_documento_participante", "bigint", 8);

            Getindex(coluna_1_1204251395.Id, "PK_documento_participante", "", true, true);
            var coluna_2_1204251395 = GetColuna(tabela1204251395.Id, "", "", 2, "seq_documento_assinado", "bigint", 8);

            Getindex(coluna_2_1204251395.Id, "IX_documento_participante_02", "", false, false);
            var coluna_3_1204251395 = GetColuna(tabela1204251395.Id, "", "", 3, "seq_participante", "bigint", 8);

            Getindex(coluna_3_1204251395.Id, "ix_documento_participante_01", "", false, false);
            var coluna_4_1204251395 = GetColuna(tabela1204251395.Id, "", "", 4, "dsc_titulo_participante", "varchar", 255);

            var coluna_5_1204251395 = GetColuna(tabela1204251395.Id, "", "", 5, "ord_documento_participante", "int", 4);

            var coluna_7_1204251395 = GetColuna(tabela1204251395.Id, "", "", 7, "dsc_email", "varchar", 255);

            var coluna_8_1204251395 = GetColuna(tabela1204251395.Id, "", "", 8, "cod_assinante", "varchar", 255);

            var coluna_9_1204251395 = GetColuna(tabela1204251395.Id, "", "", 9, "dat_inclusao", "datetime", 8);

            var coluna_10_1204251395 = GetColuna(tabela1204251395.Id, "", "", 10, "usu_inclusao", "varchar", 60);

            var coluna_11_1204251395 = GetColuna(tabela1204251395.Id, "", "", 11, "dat_alteracao", "datetime", 8);

            var coluna_12_1204251395 = GetColuna(tabela1204251395.Id, "", "", 12, "usu_alteracao", "varchar", 60);

            var coluna_13_1204251395 = GetColuna(tabela1204251395.Id, "", "", 13, "idt_dom_tipo_participante", "smallint", 2);

            var coluna_15_1204251395 = GetColuna(tabela1204251395.Id, "", "", 15, "nom_participante", "varchar", 255);

            var coluna_16_1204251395 = GetColuna(tabela1204251395.Id, "", "", 16, "ind_certificado_digital", "bit", 1);

            var coluna_17_1204251395 = GetColuna(tabela1204251395.Id, "", "", 17, "ind_notificado", "bit", 1);

            var coluna_18_1204251395 = GetColuna(tabela1204251395.Id, "", "", 18, "seq_certificadora_atuacao_participante", "bigint", 8);

            Getindex(coluna_18_1204251395.Id, "IX_documento_participante_03", "", false, false);

            var tabela1205631388 = GetTabela(projeto.Id, "", "", 1205631388, "dominio");

            var coluna_1_1205631388 = GetColuna(tabela1205631388.Id, "", "", 1, "seq_dominio", "bigint", 8);

            Getindex(coluna_1_1205631388.Id, "PK_dominio", "", true, true);
            var coluna_2_1205631388 = GetColuna(tabela1205631388.Id, "", "", 2, "nom_dominio", "varchar", 255);

            Getindex(coluna_2_1205631388.Id, "UN_dominio_01", "", true, false);
            var coluna_3_1205631388 = GetColuna(tabela1205631388.Id, "", "", 3, "val_dominio", "smallint", 2);

            Getindex(coluna_3_1205631388.Id, "UN_dominio_01", "", true, false);
            var coluna_4_1205631388 = GetColuna(tabela1205631388.Id, "", "", 4, "dsc_dominio", "varchar", 255);

            var coluna_5_1205631388 = GetColuna(tabela1205631388.Id, "", "", 5, "ind_ativo", "bit", 1);

            var coluna_6_1205631388 = GetColuna(tabela1205631388.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1205631388 = GetColuna(tabela1205631388.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1205631388 = GetColuna(tabela1205631388.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1205631388 = GetColuna(tabela1205631388.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela1261299603 = GetTabela(projeto.Id, "", "", 1261299603, "configuracao_notificacao");

            var coluna_1_1261299603 = GetColuna(tabela1261299603.Id, "", "", 1, "seq_configuracao_notificacao", "bigint", 8);

            Getindex(coluna_1_1261299603.Id, "PK_configuracao_notificacao", "", true, true);
            var coluna_2_1261299603 = GetColuna(tabela1261299603.Id, "", "", 2, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_2_1261299603.Id, "UN_configuracao_notificacao_02", "", true, false);
            Getindex(coluna_2_1261299603.Id, "UN_configuracao_notificacao_01", "", true, false);
            var coluna_3_1261299603 = GetColuna(tabela1261299603.Id, "", "", 3, "seq_tipo_notificacao", "bigint", 8);

            Getindex(coluna_3_1261299603.Id, "UN_configuracao_notificacao_01", "", true, false);
            var coluna_4_1261299603 = GetColuna(tabela1261299603.Id, "", "", 4, "dsc_token_tipo_notificacao", "varchar", 255);

            Getindex(coluna_4_1261299603.Id, "UN_configuracao_notificacao_02", "", true, false);
            var coluna_5_1261299603 = GetColuna(tabela1261299603.Id, "", "", 5, "seq_configuracao_tipo_notificacao", "bigint", 8);

            var coluna_6_1261299603 = GetColuna(tabela1261299603.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1261299603 = GetColuna(tabela1261299603.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1261299603 = GetColuna(tabela1261299603.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1261299603 = GetColuna(tabela1261299603.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela1269631616 = GetTabela(projeto.Id, "", "", 1269631616, "certificadora");

            var coluna_1_1269631616 = GetColuna(tabela1269631616.Id, "", "", 1, "seq_certificadora", "bigint", 8);

            Getindex(coluna_1_1269631616.Id, "PK_certificadora", "", true, true);
            var coluna_2_1269631616 = GetColuna(tabela1269631616.Id, "", "", 2, "nom_certificadora", "varchar", 255);

            Getindex(coluna_2_1269631616.Id, "UN_certificadora_01", "", true, false);
            var coluna_5_1269631616 = GetColuna(tabela1269631616.Id, "", "", 5, "url_api_proxy", "varchar", 255);

            Getindex(coluna_5_1269631616.Id, "UN_certificadora_02", "", false, false);
            var coluna_6_1269631616 = GetColuna(tabela1269631616.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1269631616 = GetColuna(tabela1269631616.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1269631616 = GetColuna(tabela1269631616.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1269631616 = GetColuna(tabela1269631616.Id, "", "", 9, "usu_alteracao", "varchar", 60);

            var coluna_10_1269631616 = GetColuna(tabela1269631616.Id, "", "", 10, "idt_dom_tipo_certificadora", "smallint", 2);

            var coluna_11_1269631616 = GetColuna(tabela1269631616.Id, "", "", 11, "ind_externa", "bit", 1);

            var coluna_12_1269631616 = GetColuna(tabela1269631616.Id, "", "", 12, "idt_dom_formato_assinatura", "smallint", 2);

            var coluna_13_1269631616 = GetColuna(tabela1269631616.Id, "", "", 13, "ctd_arquivo_pfx", "varbinary", -1);

            var coluna_14_1269631616 = GetColuna(tabela1269631616.Id, "", "", 14, "snh_arquivo_pfx", "varchar", 255);

            var coluna_15_1269631616 = GetColuna(tabela1269631616.Id, "", "", 15, "dsc_token", "varchar", 255);

            var coluna_16_1269631616 = GetColuna(tabela1269631616.Id, "", "", 16, "dsc_token_assinatura_automatica", "varchar", 255);


            var tabela1273823650 = GetTabela(projeto.Id, "", "", 1273823650, "configuracao_documento_academico");

            var coluna_1_1273823650 = GetColuna(tabela1273823650.Id, "", "", 1, "seq_configuracao_documento_academico", "bigint", 8);

            Getindex(coluna_1_1273823650.Id, "PK_configuracao_documento_academico", "", true, true);
            var coluna_2_1273823650 = GetColuna(tabela1273823650.Id, "", "", 2, "seq_sistema_origem_certificadora", "bigint", 8);

            Getindex(coluna_2_1273823650.Id, "UN_configuracao_documento_academico_01", "", true, false);
            var coluna_6_1273823650 = GetColuna(tabela1273823650.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1273823650 = GetColuna(tabela1273823650.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1273823650 = GetColuna(tabela1273823650.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1273823650 = GetColuna(tabela1273823650.Id, "", "", 9, "usu_alteracao", "varchar", 60);

            var coluna_10_1273823650 = GetColuna(tabela1273823650.Id, "", "", 10, "cod_pasta_certificadora", "varchar", 255);

            var coluna_11_1273823650 = GetColuna(tabela1273823650.Id, "", "", 11, "idt_dom_tipo_documento_academico", "smallint", 2);

            Getindex(coluna_11_1273823650.Id, "UN_configuracao_documento_academico_01", "", true, false);

            var tabela1314155777 = GetTabela(projeto.Id, "", "", 1314155777, "parametro_certificadora");

            var coluna_1_1314155777 = GetColuna(tabela1314155777.Id, "", "", 1, "seq_parametro_certificadora", "bigint", 8);

            Getindex(coluna_1_1314155777.Id, "PK_parametro_certificadora", "", true, true);
            var coluna_2_1314155777 = GetColuna(tabela1314155777.Id, "", "", 2, "seq_certificadora", "bigint", 8);

            Getindex(coluna_2_1314155777.Id, "UN_parametro_certificadora_01", "", true, false);
            var coluna_3_1314155777 = GetColuna(tabela1314155777.Id, "", "", 3, "nom_parametro", "varchar", 255);

            Getindex(coluna_3_1314155777.Id, "UN_parametro_certificadora_01", "", true, false);
            var coluna_4_1314155777 = GetColuna(tabela1314155777.Id, "", "", 4, "val_parametro", "varchar", 1000);

            var coluna_5_1314155777 = GetColuna(tabela1314155777.Id, "", "", 5, "dsc_parametro", "varchar", 255);

            var coluna_6_1314155777 = GetColuna(tabela1314155777.Id, "", "", 6, "idt_dom_tipo_parametro", "smallint", 2);

            var coluna_7_1314155777 = GetColuna(tabela1314155777.Id, "", "", 7, "dat_inclusao", "datetime", 8);

            var coluna_8_1314155777 = GetColuna(tabela1314155777.Id, "", "", 8, "usu_inclusao", "varchar", 60);

            var coluna_9_1314155777 = GetColuna(tabela1314155777.Id, "", "", 9, "dat_alteracao", "datetime", 8);

            var coluna_10_1314155777 = GetColuna(tabela1314155777.Id, "", "", 10, "usu_alteracao", "varchar", 60);


            var tabela1348251908 = GetTabela(projeto.Id, "", "", 1348251908, "historico_documento_assinado");

            var coluna_1_1348251908 = GetColuna(tabela1348251908.Id, "", "", 1, "seq_historico_documento_assinado", "bigint", 8);

            Getindex(coluna_1_1348251908.Id, "PK_historico_documento_assinado", "", true, true);
            var coluna_2_1348251908 = GetColuna(tabela1348251908.Id, "", "", 2, "seq_documento_assinado", "bigint", 8);

            Getindex(coluna_2_1348251908.Id, "IX_historico_documento_assinado_01", "", false, false);
            var coluna_4_1348251908 = GetColuna(tabela1348251908.Id, "", "", 4, "seq_arq_anexado", "uniqueidentifier", 16);

            var coluna_5_1348251908 = GetColuna(tabela1348251908.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1348251908 = GetColuna(tabela1348251908.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1348251908 = GetColuna(tabela1348251908.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1348251908 = GetColuna(tabela1348251908.Id, "", "", 8, "usu_alteracao", "varchar", 60);

            var coluna_9_1348251908 = GetColuna(tabela1348251908.Id, "", "", 9, "ind_atual", "bit", 1);

            var coluna_10_1348251908 = GetColuna(tabela1348251908.Id, "", "", 10, "idt_dom_status_documento_assinado", "smallint", 2);


            var tabela1353823935 = GetTabela(projeto.Id, "", "", 1353823935, "documento_academico");

            var coluna_1_1353823935 = GetColuna(tabela1353823935.Id, "", "", 1, "seq_documento_academico", "bigint", 8);

            Getindex(coluna_1_1353823935.Id, "PK_documento_academico", "", true, true);
            var coluna_3_1353823935 = GetColuna(tabela1353823935.Id, "", "", 3, "dsc_documento_academico_id", "varchar", 255);

            Getindex(coluna_3_1353823935.Id, "UN_documento_academico_01", "", true, false);
            var coluna_4_1353823935 = GetColuna(tabela1353823935.Id, "", "", 4, "dat_inclusao", "datetime", 8);

            var coluna_5_1353823935 = GetColuna(tabela1353823935.Id, "", "", 5, "usu_inclusao", "varchar", 60);

            var coluna_6_1353823935 = GetColuna(tabela1353823935.Id, "", "", 6, "dat_alteracao", "datetime", 8);

            var coluna_7_1353823935 = GetColuna(tabela1353823935.Id, "", "", 7, "usu_alteracao", "varchar", 60);

            var coluna_8_1353823935 = GetColuna(tabela1353823935.Id, "", "", 8, "seq_configuracao_documento_academico_historico", "bigint", 8);

            Getindex(coluna_8_1353823935.Id, "IX_documento_academico_01", "", false, false);
            var coluna_9_1353823935 = GetColuna(tabela1353823935.Id, "", "", 9, "cod_verificacao", "varchar", 255);


            var tabela1433824220 = GetTabela(projeto.Id, "", "", 1433824220, "historico_status_documento_academico");

            var coluna_1_1433824220 = GetColuna(tabela1433824220.Id, "", "", 1, "seq_historico_status_documento_academico", "bigint", 8);

            Getindex(coluna_1_1433824220.Id, "PK_historico_status_documento_academico", "", true, true);
            var coluna_2_1433824220 = GetColuna(tabela1433824220.Id, "", "", 2, "seq_documento_academico", "bigint", 8);

            Getindex(coluna_2_1433824220.Id, "IX_historico_status_documento_academico_01", "", false, false);
            var coluna_3_1433824220 = GetColuna(tabela1433824220.Id, "", "", 3, "idt_dom_status_documento_academico", "smallint", 2);

            var coluna_4_1433824220 = GetColuna(tabela1433824220.Id, "", "", 4, "ind_atual", "bit", 1);

            var coluna_5_1433824220 = GetColuna(tabela1433824220.Id, "", "", 5, "dsc_observacao", "varchar", -1);

            var coluna_6_1433824220 = GetColuna(tabela1433824220.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1433824220 = GetColuna(tabela1433824220.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1433824220 = GetColuna(tabela1433824220.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1433824220 = GetColuna(tabela1433824220.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela1488776411 = GetTabela(projeto.Id, "", "", 1488776411, "tag");

            var coluna_1_1488776411 = GetColuna(tabela1488776411.Id, "", "", 1, "seq_tag", "bigint", 8);

            Getindex(coluna_1_1488776411.Id, "PK_tag_01", "", true, true);
            var coluna_2_1488776411 = GetColuna(tabela1488776411.Id, "", "", 2, "dsc_tag", "varchar", 255);

            var coluna_3_1488776411 = GetColuna(tabela1488776411.Id, "", "", 3, "dat_inclusao", "datetime", 8);

            var coluna_4_1488776411 = GetColuna(tabela1488776411.Id, "", "", 4, "usu_inclusao", "varchar", 60);

            var coluna_5_1488776411 = GetColuna(tabela1488776411.Id, "", "", 5, "dat_alteracao", "datetime", 8);

            var coluna_6_1488776411 = GetColuna(tabela1488776411.Id, "", "", 6, "usu_alteracao", "varchar", 60);

            var coluna_7_1488776411 = GetColuna(tabela1488776411.Id, "", "", 7, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_7_1488776411.Id, "UN_tag_01", "", true, false);
            var coluna_8_1488776411 = GetColuna(tabela1488776411.Id, "", "", 8, "nom_tag", "varchar", 255);

            Getindex(coluna_8_1488776411.Id, "UN_tag_01", "", true, false);
            var coluna_9_1488776411 = GetColuna(tabela1488776411.Id, "", "", 9, "nom_tag_notificacao", "varchar", 255);


            var tabela1492252421 = GetTabela(projeto.Id, "", "", 1492252421, "historico_documento_participante");

            var coluna_1_1492252421 = GetColuna(tabela1492252421.Id, "", "", 1, "seq_historico_documento_participante", "bigint", 8);

            Getindex(coluna_1_1492252421.Id, "PK_historico_documento_participante", "", true, true);
            var coluna_2_1492252421 = GetColuna(tabela1492252421.Id, "", "", 2, "seq_documento_participante", "bigint", 8);

            Getindex(coluna_2_1492252421.Id, "IX_historico_documento_participante_01", "", false, false);
            var coluna_4_1492252421 = GetColuna(tabela1492252421.Id, "", "", 4, "seq_arq_anexado", "uniqueidentifier", 16);

            var coluna_5_1492252421 = GetColuna(tabela1492252421.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1492252421 = GetColuna(tabela1492252421.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1492252421 = GetColuna(tabela1492252421.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1492252421 = GetColuna(tabela1492252421.Id, "", "", 8, "usu_alteracao", "varchar", 60);

            var coluna_9_1492252421 = GetColuna(tabela1492252421.Id, "", "", 9, "ind_atual", "bit", 1);

            var coluna_10_1492252421 = GetColuna(tabela1492252421.Id, "", "", 10, "dat_assinatura", "datetime", 8);

            var coluna_11_1492252421 = GetColuna(tabela1492252421.Id, "", "", 11, "dsc_observacao", "varchar", -1);

            var coluna_12_1492252421 = GetColuna(tabela1492252421.Id, "", "", 12, "idt_dom_status_documento_participante", "smallint", 2);

            var coluna_13_1492252421 = GetColuna(tabela1492252421.Id, "", "", 13, "seq_motivo_recusa_assinatura", "bigint", 8);

            Getindex(coluna_13_1492252421.Id, "IX_historico_documento_participante_02", "", false, false);

            var tabela1515204498 = GetTabela(projeto.Id, "", "", 1515204498, "status");

            var coluna_1_1515204498 = GetColuna(tabela1515204498.Id, "", "", 1, "seq_status", "bigint", 8);

            Getindex(coluna_1_1515204498.Id, "PK_status", "", true, true);
            var coluna_2_1515204498 = GetColuna(tabela1515204498.Id, "", "", 2, "idt_dom_tipo_status", "smallint", 2);

            Getindex(coluna_2_1515204498.Id, "UN_status_01", "", true, false);
            var coluna_3_1515204498 = GetColuna(tabela1515204498.Id, "", "", 3, "val_status", "smallint", 2);

            Getindex(coluna_3_1515204498.Id, "UN_status_01", "", true, false);
            var coluna_4_1515204498 = GetColuna(tabela1515204498.Id, "", "", 4, "dsc_status", "varchar", 255);

            var coluna_5_1515204498 = GetColuna(tabela1515204498.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1515204498 = GetColuna(tabela1515204498.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1515204498 = GetColuna(tabela1515204498.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1515204498 = GetColuna(tabela1515204498.Id, "", "", 8, "usu_alteracao", "varchar", 60);


            var tabela1541632585 = GetTabela(projeto.Id, "", "", 1541632585, "participante");

            var coluna_1_1541632585 = GetColuna(tabela1541632585.Id, "", "", 1, "seq_participante", "bigint", 8);

            Getindex(coluna_1_1541632585.Id, "PK_participante", "", true, true);
            var coluna_4_1541632585 = GetColuna(tabela1541632585.Id, "", "", 4, "num_cpf", "varchar", 255);

            Getindex(coluna_4_1541632585.Id, "UN_participante_01", "", true, false);
            var coluna_5_1541632585 = GetColuna(tabela1541632585.Id, "", "", 5, "nom_participante", "varchar", 255);

            var coluna_6_1541632585 = GetColuna(tabela1541632585.Id, "", "", 6, "dsc_email_participante", "varchar", 255);

            Getindex(coluna_6_1541632585.Id, "UN_participante_02", "", true, false);
            var coluna_7_1541632585 = GetColuna(tabela1541632585.Id, "", "", 7, "dat_inclusao", "datetime", 8);

            var coluna_8_1541632585 = GetColuna(tabela1541632585.Id, "", "", 8, "usu_inclusao", "varchar", 60);

            var coluna_9_1541632585 = GetColuna(tabela1541632585.Id, "", "", 9, "dat_alteracao", "datetime", 8);

            var coluna_10_1541632585 = GetColuna(tabela1541632585.Id, "", "", 10, "usu_alteracao", "varchar", 60);

            var coluna_11_1541632585 = GetColuna(tabela1541632585.Id, "", "", 11, "dat_nascimento", "datetime", 8);

            var coluna_12_1541632585 = GetColuna(tabela1541632585.Id, "", "", 12, "num_ci", "varchar", 255);

            var coluna_13_1541632585 = GetColuna(tabela1541632585.Id, "", "", 13, "dsc_orgao_emissor_ci", "varchar", 255);

            var coluna_14_1541632585 = GetColuna(tabela1541632585.Id, "", "", 14, "dsc_uf_ci", "varchar", 255);

            var coluna_15_1541632585 = GetColuna(tabela1541632585.Id, "", "", 15, "dsc_profissao", "varchar", 255);

            var coluna_16_1541632585 = GetColuna(tabela1541632585.Id, "", "", 16, "dsc_telefone", "varchar", 255);


            var tabela1568776696 = GetTabela(projeto.Id, "", "", 1568776696, "Logger");

            var coluna_1_1568776696 = GetColuna(tabela1568776696.Id, "", "", 1, "seq_logger", "bigint", 8);

            Getindex(coluna_1_1568776696.Id, "PK_Logger", "", true, true);
            var coluna_2_1568776696 = GetColuna(tabela1568776696.Id, "", "", 2, "dsc_level", "varchar", 10);

            var coluna_3_1568776696 = GetColuna(tabela1568776696.Id, "", "", 3, "dsc_logger", "varchar", 1000);

            var coluna_4_1568776696 = GetColuna(tabela1568776696.Id, "", "", 4, "dsc_conteudo", "varchar", -1);

            var coluna_5_1568776696 = GetColuna(tabela1568776696.Id, "", "", 5, "dsc_exception", "varchar", 1000);

            var coluna_6_1568776696 = GetColuna(tabela1568776696.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1568776696 = GetColuna(tabela1568776696.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1568776696 = GetColuna(tabela1568776696.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1568776696 = GetColuna(tabela1568776696.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela1604252820 = GetTabela(projeto.Id, "", "", 1604252820, "historico_status_documento");

            var coluna_1_1604252820 = GetColuna(tabela1604252820.Id, "", "", 1, "seq_historico_status_documento", "bigint", 8);

            Getindex(coluna_1_1604252820.Id, "PK_historico_status_documento", "", true, true);
            var coluna_2_1604252820 = GetColuna(tabela1604252820.Id, "", "", 2, "seq_documento", "bigint", 8);

            Getindex(coluna_2_1604252820.Id, "IX_historico_status_documento_01", "", false, false);
            var coluna_4_1604252820 = GetColuna(tabela1604252820.Id, "", "", 4, "seq_arq_anexado", "uniqueidentifier", 16);

            var coluna_5_1604252820 = GetColuna(tabela1604252820.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1604252820 = GetColuna(tabela1604252820.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1604252820 = GetColuna(tabela1604252820.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1604252820 = GetColuna(tabela1604252820.Id, "", "", 8, "usu_alteracao", "varchar", 60);

            var coluna_9_1604252820 = GetColuna(tabela1604252820.Id, "", "", 9, "ind_atual", "bit", 1);

            var coluna_10_1604252820 = GetColuna(tabela1604252820.Id, "", "", 10, "dsc_observacao", "varchar", -1);

            var coluna_11_1604252820 = GetColuna(tabela1604252820.Id, "", "", 11, "idt_dom_status_documento", "smallint", 2);


            var tabela1621632870 = GetTabela(projeto.Id, "", "", 1621632870, "certificado");

            var coluna_1_1621632870 = GetColuna(tabela1621632870.Id, "", "", 1, "seq_certificado", "bigint", 8);

            Getindex(coluna_1_1621632870.Id, "PK_certificado", "", true, true);
            var coluna_2_1621632870 = GetColuna(tabela1621632870.Id, "", "", 2, "seq_certificadora", "bigint", 8);

            Getindex(coluna_2_1621632870.Id, "IX_certificado_02", "", false, false);
            var coluna_3_1621632870 = GetColuna(tabela1621632870.Id, "", "", 3, "seq_participante", "bigint", 8);

            Getindex(coluna_3_1621632870.Id, "IX_certificado_01", "", false, false);
            var coluna_4_1621632870 = GetColuna(tabela1621632870.Id, "", "", 4, "dat_inicio", "datetime", 8);

            var coluna_5_1621632870 = GetColuna(tabela1621632870.Id, "", "", 5, "dat_fim", "datetime", 8);

            var coluna_6_1621632870 = GetColuna(tabela1621632870.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1621632870 = GetColuna(tabela1621632870.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1621632870 = GetColuna(tabela1621632870.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1621632870 = GetColuna(tabela1621632870.Id, "", "", 9, "usu_alteracao", "varchar", 60);

            var coluna_10_1621632870 = GetColuna(tabela1621632870.Id, "", "", 10, "cod_emissao_1", "varchar", 20);

            var coluna_11_1621632870 = GetColuna(tabela1621632870.Id, "", "", 11, "cod_emissao_2", "varchar", 20);

            var coluna_12_1621632870 = GetColuna(tabela1621632870.Id, "", "", 12, "num_pedido", "varchar", 20);

            var coluna_17_1621632870 = GetColuna(tabela1621632870.Id, "", "", 17, "dsc_email", "varchar", 255);

            var coluna_18_1621632870 = GetColuna(tabela1621632870.Id, "", "", 18, "seq_unidade", "bigint", 8);

            var coluna_19_1621632870 = GetColuna(tabela1621632870.Id, "", "", 19, "cod_ccusto_ems", "varchar", 20);

            var coluna_20_1621632870 = GetColuna(tabela1621632870.Id, "", "", 20, "cod_lote", "varchar", 20);

            var coluna_21_1621632870 = GetColuna(tabela1621632870.Id, "", "", 21, "ctd_arquivo_pfx", "varbinary", -1);

            var coluna_22_1621632870 = GetColuna(tabela1621632870.Id, "", "", 22, "snh_arquivo_pfx", "varchar", 255);


            var tabela1623728887 = GetTabela(projeto.Id, "", "", 1623728887, "arquivo");

            var coluna_1_1623728887 = GetColuna(tabela1623728887.Id, "", "", 1, "seq_arquivo", "uniqueidentifier", 16);

            Getindex(coluna_1_1623728887.Id, "PK_arquivo", "", true, true);
            var coluna_2_1623728887 = GetColuna(tabela1623728887.Id, "", "", 2, "sgl_aplicacao", "varchar", 30);

            var coluna_3_1623728887 = GetColuna(tabela1623728887.Id, "", "", 3, "dsc_pasta_aplicacao", "varchar", 100);

            var coluna_4_1623728887 = GetColuna(tabela1623728887.Id, "", "", 4, "nom_arquivo", "varchar", 255);

            var coluna_5_1623728887 = GetColuna(tabela1623728887.Id, "", "", 5, "tip_arquivo", "varchar", 255);

            var coluna_6_1623728887 = GetColuna(tabela1623728887.Id, "", "", 6, "tam_arquivo", "int", 4);

            var coluna_7_1623728887 = GetColuna(tabela1623728887.Id, "", "", 7, "dsc_arquivo", "varchar", 1000);

            var coluna_8_1623728887 = GetColuna(tabela1623728887.Id, "", "", 8, "dat_ultimo_download", "datetime", 8);

            var coluna_9_1623728887 = GetColuna(tabela1623728887.Id, "", "", 9, "qtd_download", "int", 4);

            var coluna_10_1623728887 = GetColuna(tabela1623728887.Id, "", "", 10, "dat_inclusao", "datetime", 8);

            var coluna_11_1623728887 = GetColuna(tabela1623728887.Id, "", "", 11, "usu_inclusao", "varchar", 60);

            var coluna_12_1623728887 = GetColuna(tabela1623728887.Id, "", "", 12, "dat_alteracao", "datetime", 8);

            var coluna_13_1623728887 = GetColuna(tabela1623728887.Id, "", "", 13, "usu_alteracao", "varchar", 60);

            var coluna_14_1623728887 = GetColuna(tabela1623728887.Id, "", "", 14, "ctd_arquivo", "varbinary", -1);


            var tabela1735729286 = GetTabela(projeto.Id, "", "", 1735729286, "CargaDocumento");

            var coluna_1_1735729286 = GetColuna(tabela1735729286.Id, "", "", 1, "Nome", "varchar", 200);

            var coluna_2_1735729286 = GetColuna(tabela1735729286.Id, "", "", 2, "DocumentoId", "varchar", 200);

            var coluna_3_1735729286 = GetColuna(tabela1735729286.Id, "", "", 3, "ChaveCertificadora", "varchar", 200);

            var coluna_4_1735729286 = GetColuna(tabela1735729286.Id, "", "", 4, "Status", "varchar", 200);

            var coluna_5_1735729286 = GetColuna(tabela1735729286.Id, "", "", 5, "DataCriacao", "datetime", 8);

            var coluna_6_1735729286 = GetColuna(tabela1735729286.Id, "", "", 6, "DataVersao", "datetime", 8);

            var coluna_7_1735729286 = GetColuna(tabela1735729286.Id, "", "", 7, "DataFinalizacao", "datetime", 8);

            var coluna_8_1735729286 = GetColuna(tabela1735729286.Id, "", "", 8, "Excluido", "varchar", 200);

            var coluna_9_1735729286 = GetColuna(tabela1735729286.Id, "", "", 9, "Bloqueado", "varchar", 200);

            var coluna_10_1735729286 = GetColuna(tabela1735729286.Id, "", "", 10, "Rejeitado", "varchar", 200);

            var coluna_11_1735729286 = GetColuna(tabela1735729286.Id, "", "", 11, "Pasta", "varchar", 200);

            var coluna_12_1735729286 = GetColuna(tabela1735729286.Id, "", "", 12, "Participante", "varchar", 200);

            var coluna_13_1735729286 = GetColuna(tabela1735729286.Id, "", "", 13, "Acao", "varchar", 200);

            var coluna_14_1735729286 = GetColuna(tabela1735729286.Id, "", "", 14, "StatusAcao", "varchar", 200);


            var tabela1764253390 = GetTabela(projeto.Id, "", "", 1764253390, "documento_tag");

            var coluna_1_1764253390 = GetColuna(tabela1764253390.Id, "", "", 1, "seq_documento_tag", "bigint", 8);

            Getindex(coluna_1_1764253390.Id, "PK_documento_tag", "", true, true);
            var coluna_3_1764253390 = GetColuna(tabela1764253390.Id, "", "", 3, "dsc_tag", "varchar", 255);

            var coluna_4_1764253390 = GetColuna(tabela1764253390.Id, "", "", 4, "dat_inclusao", "datetime", 8);

            var coluna_5_1764253390 = GetColuna(tabela1764253390.Id, "", "", 5, "usu_inclusao", "varchar", 60);

            var coluna_6_1764253390 = GetColuna(tabela1764253390.Id, "", "", 6, "dat_alteracao", "datetime", 8);

            var coluna_7_1764253390 = GetColuna(tabela1764253390.Id, "", "", 7, "usu_alteracao", "varchar", 60);

            var coluna_8_1764253390 = GetColuna(tabela1764253390.Id, "", "", 8, "seq_documento", "bigint", 8);

            Getindex(coluna_8_1764253390.Id, "IX_documento_tag_01", "", false, false);
            Getindex(coluna_8_1764253390.Id, "UN_documento_tag_01", "", true, false);
            var coluna_10_1764253390 = GetColuna(tabela1764253390.Id, "", "", 10, "seq_tag", "bigint", 8);

            Getindex(coluna_10_1764253390.Id, "IX_documento_tag_02", "", false, false);
            Getindex(coluna_10_1764253390.Id, "UN_documento_tag_01", "", true, false);

            var tabela1865825759 = GetTabela(projeto.Id, "", "", 1865825759, "configuracao_documento_academico_historico");

            var coluna_1_1865825759 = GetColuna(tabela1865825759.Id, "", "", 1, "seq_configuracao_documento_academico_historico", "bigint", 8);

            Getindex(coluna_1_1865825759.Id, "PK_configuracao_documento_academico_historico", "", true, true);
            var coluna_2_1865825759 = GetColuna(tabela1865825759.Id, "", "", 2, "seq_configuracao_documento_academico", "bigint", 8);

            Getindex(coluna_2_1865825759.Id, "UN_configuracao_documento_academico_historico_01", "", true, false);
            var coluna_3_1865825759 = GetColuna(tabela1865825759.Id, "", "", 3, "dat_inicio_validade", "datetime", 8);

            Getindex(coluna_3_1865825759.Id, "UN_configuracao_documento_academico_historico_01", "", true, false);
            var coluna_4_1865825759 = GetColuna(tabela1865825759.Id, "", "", 4, "cod_modelo_representacao_visual", "varchar", 255);

            var coluna_5_1865825759 = GetColuna(tabela1865825759.Id, "", "", 5, "cod_fluxo_assinatura", "varchar", 255);

            var coluna_6_1865825759 = GetColuna(tabela1865825759.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_1865825759 = GetColuna(tabela1865825759.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_1865825759 = GetColuna(tabela1865825759.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_1865825759 = GetColuna(tabela1865825759.Id, "", "", 9, "usu_alteracao", "varchar", 60);


            var tabela1906157886 = GetTabela(projeto.Id, "", "", 1906157886, "certificadora_integracao");

            var coluna_1_1906157886 = GetColuna(tabela1906157886.Id, "", "", 1, "seq_certificadora_integracao", "bigint", 8);

            Getindex(coluna_1_1906157886.Id, "PK_certificadora_integracao", "", true, true);
            var coluna_2_1906157886 = GetColuna(tabela1906157886.Id, "", "", 2, "seq_certificadora", "bigint", 8);

            Getindex(coluna_2_1906157886.Id, "UN_certificadora_integracao_01", "", true, false);
            var coluna_3_1906157886 = GetColuna(tabela1906157886.Id, "", "", 3, "dsc_caminho", "varchar", 255);

            var coluna_4_1906157886 = GetColuna(tabela1906157886.Id, "", "", 4, "idt_dom_api", "smallint", 2);

            Getindex(coluna_4_1906157886.Id, "UN_certificadora_integracao_01", "", true, false);
            var coluna_5_1906157886 = GetColuna(tabela1906157886.Id, "", "", 5, "dsc_password", "varchar", 255);

            var coluna_6_1906157886 = GetColuna(tabela1906157886.Id, "", "", 6, "idt_dom_metodo_http", "smallint", 2);

            var coluna_7_1906157886 = GetColuna(tabela1906157886.Id, "", "", 7, "ind_certificado", "bit", 1);

            var coluna_8_1906157886 = GetColuna(tabela1906157886.Id, "", "", 8, "ind_cabecalho", "bit", 1);

            var coluna_9_1906157886 = GetColuna(tabela1906157886.Id, "", "", 9, "dat_inclusao", "datetime", 8);

            var coluna_10_1906157886 = GetColuna(tabela1906157886.Id, "", "", 10, "usu_inclusao", "varchar", 60);

            var coluna_11_1906157886 = GetColuna(tabela1906157886.Id, "", "", 11, "dat_alteracao", "datetime", 8);

            var coluna_12_1906157886 = GetColuna(tabela1906157886.Id, "", "", 12, "usu_alteracao", "varchar", 60);


            var tabela1952778064 = GetTabela(projeto.Id, "", "", 1952778064, "sistema_origem");

            var coluna_1_1952778064 = GetColuna(tabela1952778064.Id, "", "", 1, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_1_1952778064.Id, "PK_sistema_origem", "", true, true);
            var coluna_2_1952778064 = GetColuna(tabela1952778064.Id, "", "", 2, "sgl_sistema_origem", "varchar", 255);

            Getindex(coluna_2_1952778064.Id, "UN_sistema_origem_01", "", true, false);
            var coluna_3_1952778064 = GetColuna(tabela1952778064.Id, "", "", 3, "dsc_sistema_origem", "varchar", 255);

            Getindex(coluna_3_1952778064.Id, "UN_sistema_origem_01", "", true, false);
            var coluna_4_1952778064 = GetColuna(tabela1952778064.Id, "", "", 4, "dsc_token_acesso", "varchar", 255);

            Getindex(coluna_4_1952778064.Id, "UN_sistema_origem_02", "", true, false);
            var coluna_5_1952778064 = GetColuna(tabela1952778064.Id, "", "", 5, "dat_inclusao", "datetime", 8);

            var coluna_6_1952778064 = GetColuna(tabela1952778064.Id, "", "", 6, "usu_inclusao", "varchar", 60);

            var coluna_7_1952778064 = GetColuna(tabela1952778064.Id, "", "", 7, "dat_alteracao", "datetime", 8);

            var coluna_8_1952778064 = GetColuna(tabela1952778064.Id, "", "", 8, "usu_alteracao", "varchar", 60);

            var coluna_9_1952778064 = GetColuna(tabela1952778064.Id, "", "", 9, "ind_integracao", "bit", 1);

            var coluna_10_1952778064 = GetColuna(tabela1952778064.Id, "", "", 10, "dsc_email_notificacao_falha", "varchar", 255);

            var coluna_11_1952778064 = GetColuna(tabela1952778064.Id, "", "", 11, "dsc_texto_rastreabilidade", "varchar", -1);


            var tabela2112778634 = GetTabela(projeto.Id, "", "", 2112778634, "parametro_sistema_origem");

            var coluna_1_2112778634 = GetColuna(tabela2112778634.Id, "", "", 1, "seq_parametro_sistema_origem", "bigint", 8);

            Getindex(coluna_1_2112778634.Id, "PK_parametro_sistema_origem", "", true, true);
            var coluna_2_2112778634 = GetColuna(tabela2112778634.Id, "", "", 2, "seq_sistema_origem", "bigint", 8);

            Getindex(coluna_2_2112778634.Id, "UN_parametro_sistema_origem_01", "", true, false);
            var coluna_5_2112778634 = GetColuna(tabela2112778634.Id, "", "", 5, "val_parametro_sistema_origem", "varchar", 1000);

            var coluna_6_2112778634 = GetColuna(tabela2112778634.Id, "", "", 6, "dat_inclusao", "datetime", 8);

            var coluna_7_2112778634 = GetColuna(tabela2112778634.Id, "", "", 7, "usu_inclusao", "varchar", 60);

            var coluna_8_2112778634 = GetColuna(tabela2112778634.Id, "", "", 8, "dat_alteracao", "datetime", 8);

            var coluna_9_2112778634 = GetColuna(tabela2112778634.Id, "", "", 9, "usu_alteracao", "varchar", 60);

            var coluna_10_2112778634 = GetColuna(tabela2112778634.Id, "", "", 10, "idt_dom_tipo_parametro_sistema_origem", "smallint", 2);

            Getindex(coluna_10_2112778634.Id, "UN_parametro_sistema_origem_01", "", true, false);
        }

        private static void Getindex(Guid ColunaId, string KeyNameOf, string name, bool is_unique, bool is_primary_key)
        {
            var item = ctx.Indices.Where(a => a.ColunaId == ColunaId && a.Name == name).FirstOrDefault();
            if (item == null)
            {
                item = new Indice(ColunaId, KeyNameOf, name, is_unique, is_primary_key);
                ctx.Indices.Add(item);
            }
        }
        private static Coluna GetColuna(Guid tabelaId, string ownsOne, string columnNameOf, int id, string name, string type, int max_length)
        {
            var item = ctx.Colunas.Where(a => a.TabelaId == tabelaId && a.Name == name).FirstOrDefault();
            if (item == null)
            {
                item = new Coluna(ownsOne, columnNameOf, id, name, type, max_length);
                item.AssociarTabela(tabelaId);
                ctx.Colunas.Add(item);
            }
            return item;
        }

        private static Tabela GetTabela(Guid projetoId, string area, string tableNameOf, int id, string name)
        {
            var item = ctx.Tabelas.Where(a => a.ProjetoId == projetoId && a.Name == name).FirstOrDefault();
            if (item == null)
            {
                item = new Tabela(area, tableNameOf, id, name);
                item.AssociarProjeto(projetoId);
                ctx.Tabelas.Add(item);
            }
            return item;
        }

        private static Projeto GetProjeto(Guid id, string name)
        {
            var item = ctx.Projetos.Where(a => a.SolucaoId == id && a.Name == name).FirstOrDefault();
            if (item == null)
            {
                item = new Projeto( name);
                ctx.Projetos.Add(item);
            }
            return item;
        }

        private static Solucao GetSolucao(string name)
        {
            var sol = ctx.Solucao.Where(a => a.Name == name).FirstOrDefault();
            if (sol == null)
            {
                sol = new Solucao(name);
                ctx.Solucao.Add(sol);
            }
            return sol;
        }

    }
}