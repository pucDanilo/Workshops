using FluentMigrator;
using System;
using System.Linq;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180804181000)]
    public class DefaultDB_20180804_181000_Titulo : PopularDB
    {
        public override void Up()
        {
            var Titulo = Converta<JsonTS[]>.FromJson(JsonTS.texto);
            decimal ValorInvestido = 0, ValorLiquido = 0;
            foreach (var json in Titulo)
            {
                ValorInvestido += PopularDB.toDecimal(json.ValorInvestido);
                ValorLiquido += PopularDB.toDecimal(json.ValorLiquido);
                var nome = json.Titulo.Replace("Tesouro ", "").Trim().Replace(" com Juros Semestrais", "").Trim();

                var ParaContaCorrenteId = (json.Corretora.IndexOf("BRADESCO") > -1 ? PopularDB.BradescoCorretoraId : PopularDB.EasynvestId);

                this.insertProtocolo(ParaContaCorrenteId, nome, PopularDB.ToDateTime(json.Data), PopularDB.toDecimal(json.Quantidade),
                    PopularDB.toDecimal(json.PU),
                    PopularDB.toDecimal(json.ValorInvestido),
                    PopularDB.toDecimal(json.ValorLiquido), PopularDB.toDecimal(json.ValorBruto), json.Rentabilidade);// toDecimal(json.Quantidade));
            }


            this.insertTitulo(PopularDB.SantanderInv, "CDB", "CDB PROGRESSIVO 10M", PopularDB.ToDateTime("03/11/2020"), Decimal.Parse("100"));

            this.insertProtocolo(PopularDB.SantanderInv, "CDB PROGRESSIVO 10M", PopularDB.ToDateTime("03/11/2020"), 1, PopularDB.toDecimal("20000.00"), PopularDB.toDecimal("20000.00"), PopularDB.toDecimal("21228.08"), PopularDB.toDecimal("21535.09"), "84,00");

            this.insertTitulo(PopularDB.SantanderInv, "POUPANCA", "POUPANCA SANTANDER", PopularDB.ToDateTime("01/09/2017"), PopularDB.toDecimal("0.58080"));

            this.insertProtocolo(PopularDB.SantanderInv, "POUPANCA SANTANDER", PopularDB.ToDateTime("15/09/2017"), 1, PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), "POUPANCA ESPECIAL PF 3476-60.028285.1");
            this.insertProtocolo(PopularDB.SantanderInv, "POUPANCA SANTANDER", PopularDB.ToDateTime("15/09/2017"), 1, PopularDB.toDecimal("57939.05"), PopularDB.toDecimal("57939.05"), PopularDB.toDecimal("57939.05"), PopularDB.toDecimal("57939.05"), "POUPANCA ESPECIAL PF 3476-60.034529.5");

            //Bradesco =
            this.insertTitulo(PopularDB.BradescoId, "POUPANCA", "POUPANCA BRADESCO", PopularDB.ToDateTime("01/09/2017"), PopularDB.toDecimal("0.58080"));

            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("15908.81"), PopularDB.toDecimal("15908.81"), PopularDB.toDecimal("15993.38"), PopularDB.toDecimal("15993.38"), "POUPANCA ANTES 2009 ANIVERSARIO 28/08");
            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("26481.05"), PopularDB.toDecimal("26481.05"), PopularDB.toDecimal("26627.00"), PopularDB.toDecimal("26627.00"), "POUPANCA ANTES 2009 ANIVERSARIO 01/09");
            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("21991.71"), PopularDB.toDecimal("21991.71"), PopularDB.toDecimal("22119.44"), PopularDB.toDecimal("22119.44"), "POUPANCA ANTES 2009 ANIVERSARIO 26/08");
            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("11439.62"), PopularDB.toDecimal("11439.62"), PopularDB.toDecimal("11500.43"), PopularDB.toDecimal("11500.43"), "POUPANCA ANTES 2009 ANIVERSARIO 28/08");
            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("11607.46"), PopularDB.toDecimal("11607.46"), PopularDB.toDecimal("11671.44"), PopularDB.toDecimal("11671.44"), "POUPANCA ANTES 2009 ANIVERSARIO 01/09");
            this.insertProtocolo(PopularDB.BradescoId, "POUPANCA BRADESCO", PopularDB.ToDateTime("28/08/2017"), 1, PopularDB.toDecimal("5712.21"), PopularDB.toDecimal("5712.21"), PopularDB.toDecimal("5742.60"), PopularDB.toDecimal("5742.60"), "POUPANCA ANTES 2009 ANIVERSARIO 02/09");
        }

    }
}