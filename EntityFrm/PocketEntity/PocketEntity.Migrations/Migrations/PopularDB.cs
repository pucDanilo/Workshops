using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PocketEntity.Migrations
{
    public enum TipoEntidade
    {
        ContaCorrente = 1, ContraCheque = 2
    }

    public class helpTitulo
    {
        public long BancoId;
        public string Nome;
        public long TituloId;
    }

    public class NaturezaHelp
    {
        public long TipoEntidadeId;
        public long EntidadeId;
        public string Nome;
        public long NaturezaId;
    }

    public abstract class PopularDB : AutoReversingMigration
    {
        public static List<helpTitulo> Titulo = new List<helpTitulo>();
        public static int StockId = 0;
        public static long ProtocoloId = 0;
        public static int ContaCorrenteId = 0; 
        public static int TituloId = 0;
        public static int NaturezaId = 0;
        public static long TenantId = 1;
        public static long CodigoSalarioId = 0; // Salario PUC MINAS

        public static long SantanderId = 1; // Santander ContaCorrente
        public static long SantanderInv = 2; // Santander Investimento
        public static long BradescoId = 3; // BRADESCO ContaCorrente
        public static long BradescoCorretoraId = 4; // BRADESCO Tesouro Direto
        public static long BradescoStockId = 5; // BRADESCO Acoes
        public static long SalarioId = 7; // Salario PUC MINAS
        public static long EasynvestId = 6; // EASYNVEST Corretora

        public static DateTime ToDateTime(string v)
        {
            return DateTime.ParseExact(v, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static decimal toDecimal(string v)
        {
            var o = decimal.Parse(v.Replace(",", "."), CultureInfo.InvariantCulture);
            return o;
        }

        public static List<NaturezaHelp> Tags = new List<NaturezaHelp>();

        private string NTNB = "NTNB", LTN = "LTN", LFT = "LFT";

        public void CriarTitulo(long CorretoraId)
        {
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2019 (NTNB Princ)", new DateTime(2019, 5, 15), Decimal.Parse("6,25"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2020 (NTNB)", new DateTime(2020, 8, 15), 0);
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2024 (NTNB Princ)", new DateTime(2024, 8, 15), Decimal.Parse("6,08"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2026 (NTNB)", new DateTime(2026, 8, 15), Decimal.Parse("6,14"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2035 (NTNB)", new DateTime(2035, 5, 15), Decimal.Parse("6,15"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2035 (NTNB Princ)", new DateTime(2035, 5, 15), Decimal.Parse("6,16"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2050 (NTNB)", new DateTime(2050, 8, 15), Decimal.Parse("6,19"));
            insertTitulo(CorretoraId, LTN, "Prefixado 2018 (LTN)", new DateTime(2018, 01, 01), 0);
            insertTitulo(CorretoraId, LTN, "Prefixado 2021 (LTN)", new DateTime(2021, 01, 01), 0);
            insertTitulo(CorretoraId, NTNB, "Prefixado 2023 (NTNF)", new DateTime(2023, 1, 1), 0);
            insertTitulo(CorretoraId, LTN, "Prefixado 2023 (LTN)", new DateTime(2023, 01, 01), Decimal.Parse("12,94"));
            insertTitulo(CorretoraId, NTNB, "Prefixado 2025 (NTNF)", new DateTime(2025, 01, 01), 0);
            insertTitulo(CorretoraId, NTNB, "Prefixado 2027 (NTNF)", new DateTime(2027, 01, 01), Decimal.Parse("12,86"));
            insertTitulo(CorretoraId, LFT, "Selic 2021 (LFT)", new DateTime(2021, 3, 01), Decimal.Parse("0,02"));
            insertTitulo(CorretoraId, NTNB, "IPCA+ 2045 (NTNB Princ)", new DateTime(2045, 05, 15), Decimal.Parse("5,58"));
        }

        public long buscarNaturezaId(int tipoEntidade, int entidadeId, string nome)
        {
            nome = nome.ToUpper();
            var codigo = Tags.Where(a => a.TipoEntidadeId == tipoEntidade && a.EntidadeId == entidadeId && a.Nome == nome).Select(a => a.NaturezaId).FirstOrDefault();
            if (codigo == 0)
            {
                codigo = insertNatureza(tipoEntidade, entidadeId, nome);
            }
            return codigo;
        }

        public long insertTitulo(long BancoId, string Tipo, string Nome, DateTime DataVencimento, Decimal TaxaAtual)
        {
            PopularDB.TituloId += 1;
            Insert.IntoTable("Titulo").Row(new { BancoId = BancoId, Nome = Nome, Tipo = Tipo, DataVencimento = DataVencimento, TaxaAtual = TaxaAtual, });
            Titulo.Add(new helpTitulo { BancoId = BancoId, Nome = Nome, TituloId = PopularDB.TituloId });
            return PopularDB.TituloId;
        }

        public long insertNatureza(int tipoEntidade, int entidadeId, string nome)
        {
            PopularDB.NaturezaId++;
            Tags.Add(new NaturezaHelp { TipoEntidadeId = tipoEntidade, EntidadeId = entidadeId, Nome = nome, NaturezaId = PopularDB.NaturezaId });

            Insert.IntoTable("Tag").Row(new { EntitdadeId = entidadeId, TipoEntidade = tipoEntidade, Nome = nome });
            return PopularDB.NaturezaId;
        }

        public long insertTransacao(long BancoId, string NomeNatureza, DateTime DataStatus, decimal ValorTransacao, string Descricao)
        {
            PopularDB.ContaCorrenteId++;
            Insert.IntoTable("ContaCorrente").Row(new { BancoId = BancoId, Data = DataStatus, Valor = ValorTransacao, Descricao = Descricao });
            var idNat = buscarNaturezaId((int)TipoEntidade.ContaCorrente, PopularDB.ContaCorrenteId, NomeNatureza);
            return PopularDB.ContaCorrenteId;
        }

        public void insertContraCheque(long SalarioId, string TipoPagamento, decimal Valor, DateTime DataStatus)
        { 
            Insert.IntoTable("ContraCheque").Row(new {SalarioId = SalarioId, Valor = Valor, Descricao = TipoPagamento, Data = DataStatus}); 
        }

        public long insertSalario(long BancoId, string NomeNatureza, DateTime Data, decimal Valor, string Descricao)
        { 
            PopularDB.CodigoSalarioId++;
            Insert.IntoTable("Salario").Row(new { BancoId = BancoId, Data = Data, Valor = Valor, Descricao = Descricao }); 
            return PopularDB.CodigoSalarioId; 
        }

        public long insertProtocolo(long BancoId,
            string Nome,
            DateTime Data,
            decimal Quantidade,
            decimal PrecoUnitario,
            Decimal Valor,
            Decimal ValorLiquido,
            decimal ValorInvestido,
            string Rentabilidade)
        {
            PopularDB.ProtocoloId++;
            Insert.IntoTable("Protocolo").Row(
                new
                {
                    TituloId = BuscarTitulo(BancoId, Nome),
                    Data = Data,
                    Valor = Valor,
                    Quantidade = Quantidade,
                    PrecoUnitario = PrecoUnitario,
                    ValorLiquido = ValorLiquido,
                    ValorInvestido = ValorInvestido,
                    Descricao = Rentabilidade
                });
            return PopularDB.ProtocoloId;
        }

        public void insertPregao(long bradescoId, long bradescoStockId, long StockId, decimal Total, DateTime DataPregao, decimal Preco, decimal Quantidade)
        {
            Insert.IntoTable("Pregao").Row(new {
                StockId = StockId,
                Valor = Total,
                Data = DataPregao,
                Descricao = (Total > 0?"Compra":"Venda"), 
                Preco = Preco,
                Quantidade = Quantidade });
        } 

         

        public long insertStock(long BancoId, string Codigo, string Nome, decimal Cotacao)
        {
            decimal Valor = 0;
            PopularDB.StockId += 1;
            Insert.IntoTable("Stock").Row(
                new
                {
                    BancoId = BancoId,
                    Codigo = Codigo,
                    Descricao = Nome,
                    Data= DateTime.Now,
                    Valor = Valor,
                    Cotacao = Cotacao,
                    Quantidade = Valor,
                    PrecoMedio = Valor,
                    GanhoTotal = Valor
                });
            return PopularDB.StockId;
        }

        public long BuscarTitulo(long BancoId, string nome)
        {
            var codigo = Titulo.Where(a => a.BancoId == BancoId && a.Nome == nome).Select(a => a.TituloId).FirstOrDefault();
            return codigo;
        }
    }
}