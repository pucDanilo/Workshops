using FluentMigrator;
using System;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180803215200)]
    public class DefaultDB_20180803_215200_ContaCorrente : PopularDB
    {
        public override void Up()
        {
            this.CreateTableWithId32("Banco", "BancoId", s => s
                .WithColumn("Nome").AsString(100)
                .WithColumn("NumeroConta").AsString(100)
                .WithColumn("TipoConta").AsInt32()
                .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_Banco_TenantId", "Tenant", "TenantId"));

            this.CreateTableWithId32("ContaCorrente", "ContaCorrenteId", s => s
                .WithColumn("BancoId").AsInt32().ForeignKey("FK_ContaCorrente_BancoId", "Banco", "BancoId")
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2).NotNullable());
            //.WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_ContaCorrente_TenantId", "Tenant", "TenantId"));
            
            this.CreateTableWithId32("Salario", "SalarioId", s => s
                .WithColumn("BancoId").AsInt32().ForeignKey("FK_ContraCheque_BancoId", "Banco", "BancoId")
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2).NotNullable());

            this.CreateTableWithId32("ContraCheque", "ContraChequeId", s => s
                .WithColumn("SalarioId").AsInt32().ForeignKey("FK_ContraCheque_SalarioId", "Salario", "SalarioId")
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2).NotNullable() );

            this.CreateTableWithId32("Titulo", "TituloId", s => s
                .WithColumn("BancoId").AsInt32().NotNullable().ForeignKey("FK_Titulo_BancoId", "Banco", "BancoId")
                .WithColumn("Nome").AsString(100)
                .WithColumn("Tipo").AsString(100)
                .WithColumn("DataVencimento").AsDateTime()
                .WithColumn("TaxaAtual").AsDecimal(9, 2));
            //    .WithColumn("TenantId").AsInt32().NotNullable().ForeignKey("FK_Titulo_TenantId", "Tenant", "TenantId"));

            this.CreateTableWithId32("ExtratoTitulo", "ExtratoTituloId", s => s
                .WithColumn("TituloId").AsInt32().NotNullable().ForeignKey("FK_ExtratoTitulo_TituloId", "Titulo", "TituloId")
                .WithColumn("BancoId").AsInt32().NotNullable().ForeignKey("FK_ExtratoTitulo_BancoId", "Banco", "BancoId")
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2)
                .WithColumn("ValorInicial").AsDecimal(9, 2)
                .WithColumn("ValorLiquido").AsDecimal(9, 2)
                .WithColumn("ValorBruto").AsDecimal(9, 2));

            this.CreateTableWithId32("Protocolo", "ProtocoloId", s => s
                .WithColumn("TituloId").AsInt32().ForeignKey("FK_Protocolo_TituloId", "Titulo", "TituloId")
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2)
                .WithColumn("PrecoUnitario").AsDecimal(9, 2)
                .WithColumn("Quantidade").AsDecimal(9, 2)
                .WithColumn("ValorLiquido").AsDecimal(9, 2)
                .WithColumn("ValorInvestido").AsDecimal(9, 2));

            this.CreateTableWithId32("Stock", "StockId", s => s
                .WithColumn("BancoId").AsInt32().ForeignKey("FK_Stock_BancoId", "Banco", "BancoId")
                .WithColumn("Codigo").AsString(100)
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2)
                .WithColumn("Cotacao").AsDecimal(9, 2)
                .WithColumn("Quantidade").AsDecimal(9, 2)
                .WithColumn("PrecoMedio").AsDecimal(9, 2)
                .WithColumn("GanhoTotal").AsDecimal(9, 2));

            this.CreateTableWithId32("Pregao", "PregaoId", s => s
                .WithColumn("StockId").AsInt32().ForeignKey("FK_Pregao_StockId", "Stock", "StockId")
                .WithColumn("Quantidade").AsDecimal(9, 2)
                .WithColumn("Preco").AsDecimal(9, 2)
                .WithColumn("Descricao").AsString(100)
                .WithColumn("Data").AsDateTime()
                .WithColumn("Valor").AsDecimal(9, 2));

            this.CreateTableWithId32("Tag", "TagId", s => s
                .WithColumn("EntitdadeId").AsInt32()
                .WithColumn("TipoEntidade").AsInt16()
                .WithColumn("Nome").AsString(100));

            DateTime data = new DateTime(2017, 09, 19);

            Insert.IntoTable("Banco").Row(new { Nome = "Santander CC", NumeroConta = "3476 - 01007663-9", TenantId = 1, TipoConta = 1 });
            Insert.IntoTable("Banco").Row(new { Nome = "Santander Investimento", NumeroConta = "3476 - 01007663-9", TenantId = 1, TipoConta = 2 });
            Insert.IntoTable("Banco").Row(new { Nome = "BRADESCO ContaCorrente", NumeroConta = "1203 - 32508-2", TenantId = 1, TipoConta = 1 });
            Insert.IntoTable("Banco").Row(new { Nome = "BRADESCO Tesouro Direto", NumeroConta = "1203 - 32508-2", TenantId = 1, TipoConta = 3 });
            Insert.IntoTable("Banco").Row(new { Nome = "BRADESCO Acoes", NumeroConta = "1203 - 32508-2", TenantId = 1, TipoConta = 4 });
            Insert.IntoTable("Banco").Row(new { Nome = "EASYNVEST", NumeroConta = "165482", TenantId = 1, TipoConta = 2 });
            Insert.IntoTable("Banco").Row(new { Nome = "Salario PUC MINAS", NumeroConta = "SMC", TenantId = 1, TipoConta = 5 });
        }
    }
}