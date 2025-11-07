using FluentMigrator;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180805124000)]
    public class DefaultDB_20180805_124000_Salario : PopularDB
    {
        public override void Up()
        {
            PopularSalario2007();

            PopularSalario2008();
            PopularSalario2009();
            PopularSalario2010();
            PopularSalario2011();
            PopularSalario2012();
            PopularSalario2013();
            PopularSalario2014();
            PopularSalario2015();
            PopularSalario2016();
            PopularSalario2017();
            PopularSalario2018();
        }

        public void PopularSalario2007()
        {
            var data = PopularDB.ToDateTime("01/01/2007");
            long TransacaoId = insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/01/2007"), PopularDB.toDecimal("1642,73"), "Salario 2007");
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-210,2"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-58,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("1910,99"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/02/2007"), PopularDB.toDecimal("1736,4"), "Salario 2007");
            data = PopularDB.ToDateTime("01/02/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-223,82"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-74,59"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", PopularDB.toDecimal("57,92"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("1976,89"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/03/2007"), PopularDB.toDecimal("1699,53"), "Salario 2007");
            data = PopularDB.ToDateTime("01/03/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", PopularDB.toDecimal("-68,53"), data);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "INSS/Dif.", PopularDB.toDecimal("-2,33"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-80,59"), data);
            this.insertContraCheque(TransacaoId, "Diferenca CCT", PopularDB.toDecimal("21,16"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/04/2007"), PopularDB.toDecimal("1635,55"), "Salario 2007");
            data = PopularDB.ToDateTime("01/04/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", PopularDB.toDecimal("-41,12"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-75,73"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/05/2007"), PopularDB.toDecimal("1625,88"), "Salario 2007");
            data = PopularDB.ToDateTime("01/05/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", PopularDB.toDecimal("-41,12"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-85,4"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/06/2007"), PopularDB.toDecimal("1673,34"), "Salario 2007");
            data = PopularDB.ToDateTime("01/06/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/07/2007"), PopularDB.toDecimal("1673,34"), "Salario 2007");
            data = PopularDB.ToDateTime("01/07/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/08/2007"), PopularDB.toDecimal("1632,22"), "Salario 2007");
            data = PopularDB.ToDateTime("01/08/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", PopularDB.toDecimal("-41,12"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/09/2007"), PopularDB.toDecimal("1673,34"), "Salario 2007");
            data = PopularDB.ToDateTime("01/09/2007");
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/10/2007"), PopularDB.toDecimal("1673,34"), "Salario 2007");
            data = data.AddMonths(1);
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/11/2007"), PopularDB.toDecimal("2660,21"), "Salario 2007");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", PopularDB.toDecimal("-41,12"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", PopularDB.toDecimal("1027,99"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", PopularDB.ToDateTime("01/12/2007"), PopularDB.toDecimal("2397,75"), "Salario 2007");
            data = data.AddMonths(1);
            //this.insertNaturezaTransacao(NaturezaId, TransacaoId);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", PopularDB.toDecimal("-1027,99"), data);
            this.insertContraCheque(TransacaoId, "INSS", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", PopularDB.toDecimal("-226,15"), data);
            this.insertContraCheque(TransacaoId, "IRRF", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", PopularDB.toDecimal("-77,42"), data);
            this.insertContraCheque(TransacaoId, "Unimed", PopularDB.toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "13.Salario", PopularDB.toDecimal("2055,97"), data);
            this.insertContraCheque(TransacaoId, "Salario", PopularDB.toDecimal("2055,97"), data);
        }

        public void PopularSalario2008()
        {
            var data = ToDateTime("01/01/2008");
            long TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2008"), toDecimal("2197,82"), "Salario 2008");
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-258,82"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-123,35"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1247,3"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("342,66"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("342,66"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1027,99"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1027,99"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1165,05"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2008"), toDecimal("1639,24"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-242,49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-60,97"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("102,85"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1918,91"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2008"), toDecimal("1693,37"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-72,21"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-238,27"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-83,26"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("110,2"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2055,97"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2008"), toDecimal("1765,58"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-238,27"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-83,26"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2166,17"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2008"), toDecimal("1722,26"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-238,27"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-83,26"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-43,32"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-79,06"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2166,17"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2008"), toDecimal("2204,86"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310,78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-171,26"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825,35"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2008"), toDecimal("2209,19"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310,78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-162,78"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825,35"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2008"), toDecimal("2152,68"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310,78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-162,78"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825,35"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2008"), toDecimal("3853,24"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-334,28"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-207,19"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-165,11"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-45,53"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-45,53"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1630,85"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("470,89"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("470,89"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1412,68"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1412,68"), data);
            this.insertContraCheque(TransacaoId, "Hora Extra 50%", toDecimal("259,48"), data);
            this.insertContraCheque(TransacaoId, "Rep. S. Remunerado", toDecimal("43,25"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2354,46"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2008"), toDecimal("1388,7"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-334,28"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-17,99"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1883,57"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2008"), toDecimal("3565,36"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310,78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-162,78"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("1412,68"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825,35"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2008"), toDecimal("3221,78"), "Salario 2008");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-1412,68"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310,78"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-313,55"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-99,86"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-174,62"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4,15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56,51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81,94"), data);
            this.insertContraCheque(TransacaoId, "13.Salario sobre Var", toDecimal("25,17"), data);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("2825,35"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825,35"), data);
        }

        public void PopularSalario2009()
        {
            var data = ToDateTime("01/01/2009");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2009"), toDecimal("2272.11"), "Salario 2009");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825.35"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-310.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-99.86"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.15"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56.51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81.94"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2009"), toDecimal("2801.79"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("475.09"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("475.09"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1412.68"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1412.68"), data);
            this.insertContraCheque(TransacaoId, "Hora Extra 50%", toDecimal("4.43"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("12.59"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("12.59"), data);
            this.insertContraCheque(TransacaoId, "Rep. S. Remunerado", toDecimal("0.74"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1412.68"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-354.07"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-209.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-19.25"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-19.25"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1672.08"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-56.51"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81.94"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2009"), toDecimal("2467.20"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("181.63"), data);
            this.insertContraCheque(TransacaoId, "Dif.Salarial", toDecimal("213.32"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2825.35"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-100.23"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-354.07"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-152.07"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81.94"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2009"), toDecimal("2345.78"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81.94"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2009"), toDecimal("2345.78"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-81.94"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2009"), toDecimal("2401.51"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2009"), toDecimal("2993.39"), "Salario 2009");
            data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-354.07"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-222.47"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-27.41"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-27.41"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1772.64"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("505.63"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("505.63"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1503.49"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1503.49"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("13.40"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("13.40"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1503.49"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2009"), toDecimal("2341.37"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2009"), toDecimal("2401.51"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2009"), toDecimal("2401.51"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2009"), toDecimal("3844.86"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("1503.49"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2009"), toDecimal("3442.01"), "Salario 2009");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "13.Salario sobre Var", toDecimal("0.48"), data);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-1503.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-330.76"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-330.82"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-123.57"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-132.65"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-4.65"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);
        }

        public void PopularSalario2010()
        {
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2010"), toDecimal("4182.16"), "Salario 2010");
            var data = PopularDB.ToDateTime("01/01/2010");
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("501.24"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("501.24"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1503.49"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1503.49"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.24"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.24"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2806.51"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-338.12"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-220.54"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-113.37"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-26.24"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-26.24"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1758.19"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2010"), toDecimal("1176.56"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1703.96"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-375.81"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-60.14"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2010"), toDecimal("2519.02"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("131.10"), data);
            this.insertContraCheque(TransacaoId, "Dif.Ferias", toDecimal("75.76"), data);
            this.insertContraCheque(TransacaoId, "Dif.Salarial", toDecimal("74.29"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3006.98"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-104.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-361.69"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-148.61"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2010"), toDecimal("2510.11"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3138.08"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-345.18"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-128.58"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2010"), toDecimal("2447.35"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3138.08"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-345.18"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-128.58"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-86.35"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2010"), toDecimal("3921.79"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("523.10"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("523.10"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1569.04"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1569.04"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.25"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.25"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2510.46"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-368.21"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-230.16"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-65.50"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-27.23"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-27.23"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1835"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2010"), toDecimal("1640.45"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2196.66"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-379.72"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-19.13"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-62.76"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2010"), toDecimal("2573.10"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-364.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-151.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2010"), toDecimal("2639.44"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-364.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-151.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2010"), toDecimal("2639.44"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-364.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-151.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2010"), toDecimal("4231.71"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("1658.61"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-364.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-151.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2010"), toDecimal("3774.14"), "Salario 2010");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "Adic.Noturno 20%", toDecimal("3.02"), data);
            this.insertContraCheque(TransacaoId, "Dif.13.Salario", toDecimal("0.30"), data);
            this.insertContraCheque(TransacaoId, "Rep. s/ Adic.Noturno", toDecimal("0.50"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-1658.61"), data);
            this.insertContraCheque(TransacaoId, "Dif. INSS13.Salario", toDecimal("-0.03"), data);
            this.insertContraCheque(TransacaoId, "Dif. IRRF 13.Salario", toDecimal("-0.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-365.28"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-364.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-152.42"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-161.9"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.10"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);
        }

        public void PopularSalario2011()
        {
            var data = ToDateTime("01/01/2011");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2011"), toDecimal("3268.01"), "Salario 2011");
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("552.87"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("552.87"), data);
            this.insertContraCheque(TransacaoId, "Dif.Ferias", toDecimal("0.20"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1658.61"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1658.61"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("1658.61"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-405.86"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-243.26"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-35.18"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-35.18"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1933.04"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.40"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-66.34"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2011"), toDecimal("2793.41"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("216.61"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-388.72"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-186.12"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.40"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-70.68"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2011"), toDecimal("2694.11"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("216.61"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3317.22"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-117.79"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-388.72"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-167.58"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-70.68"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2011"), toDecimal("2912.65"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Diferenca CCT", toDecimal("97.54"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3582.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-404.81"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-191.40"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-76.33"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2011"), toDecimal("2776.32"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3582.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-394.08"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-173.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-89.50"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2011"), toDecimal("2768.35"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3582.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-394.08"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-173.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-97.47"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2011"), toDecimal("2840"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3582.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-394.08"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-173.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-97.47"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2011"), toDecimal("2768.35"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3582.60"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-394.08"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-173.95"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-97.47"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2011"), toDecimal("4312.95"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("597.16"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("597.16"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1791.30"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1791.30"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.17"), data);
            this.insertContraCheque(TransacaoId, "Média Ferias", toDecimal("0.17"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2627.24"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-406.09"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-262.74"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-68.25"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-41.95"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-41.95"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-2083.94"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-71.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2011"), toDecimal("2291.05"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Dif.Ferias", toDecimal("63.62"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2903.44"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-406.09"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-79.20"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-75.74"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2011"), toDecimal("4792.79"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("1893.55"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-406.09"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-215.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-75.74"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-75.74"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2011"), toDecimal("4230.09"), "Salario 2011"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-1893.55"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-406.09"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-406.09"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-215.31"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-232.35"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-5.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-75.74"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);
        }

        public void PopularSalario2012()
        {
            var data = ToDateTime("01/01/2012");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2012"), toDecimal("3122.67"), "Salario 2012");
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("189.36"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-227.73"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-79.53"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2012"), toDecimal("3043.14"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("189.36"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-227.73"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-79.53"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-79.53"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2012"), toDecimal("2990.12"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("189.36"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3787.10"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-132.55"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-227.73"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-79.53"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2012"), toDecimal("4012.23"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("441.83"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("441.83"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("309.28"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("63.12"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("126.24"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("63.12"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1262.37"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("1262.37"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2524.73"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-159.05"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-83.71"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-1608.27"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.10"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2012"), toDecimal("3269.58"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-295.24"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-109.53"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2012"), toDecimal("3348.89"), "Salario 2012"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-295.24"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2012"), toDecimal("3348.89"), "Salario 2012"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-295.24"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2012"), toDecimal("3263.24"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-295.24"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2012"), toDecimal("5706.41"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("951.7"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("951.7"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("135.96"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("135.96"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("135.96"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2719.14"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2719.14"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2719.14"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-418.74"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-106.81"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-210.16"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-210.16"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-3055.81"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2012"), toDecimal("2163.96"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("135.96"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2719.14"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-52.62"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2012"), toDecimal("5404.57"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("2141.33"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-295.24"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2012"), toDecimal("4769.76"), "Salario 2012"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("4282.65"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-2141.33"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-430.78"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-270.39"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-314.52"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
        }

        public void PopularSalario2013()
        {
            var data = ToDateTime("01/12/2013");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2013"), toDecimal("2605.32"), "Salario 2013");
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("6135.63"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-2301.92"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-770.90"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2013"), toDecimal("3454.53"), "Salario 2013");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2921.73"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("146.09"), data);
            this.insertContraCheque(TransacaoId, "Dif.Ferias", toDecimal("1021.19"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("109.62"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2192.31"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("767.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-2642.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-262.48"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-89.14"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-122.71"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2013"), toDecimal("2301.92"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("2301.92"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2013"), toDecimal("4566.15"), "Salario 2013");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5843.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("292.17"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-122.71"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-737.16"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-122.71"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2013"), toDecimal("3589.65"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4384.61"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("219.23"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-335.21"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-92.08"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2013"), toDecimal("3589.65"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4384.61"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("219.23"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-335.21"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-92.08"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2013"), toDecimal("3497.57"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4384.61"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("219.23"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-92.08"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-335.21"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-92.08"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2013"), toDecimal("3617.53"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4384.61"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("219.23"), data);
            this.insertContraCheque(TransacaoId, "Diferenca CCT", toDecimal("35.97"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-343.30"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-92.08"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2013"), toDecimal("3580.11"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("309.21"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-123.08"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-332.56"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-91.84"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2013"), toDecimal("3495.48"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("309.21"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-91.84"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-332.56"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-91.84"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2013"), toDecimal("3587.32"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("309.21"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-332.56"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-91.84"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2013"), toDecimal("3518.93"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("309.21"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-142.76"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-264.38"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2013"), toDecimal("1688.85"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2039.36"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("101.97"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("101.97"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2039.36"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("713.78"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-85.65"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-2478.79"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-15.10"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-62.26"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);


            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2013"), toDecimal("3352.48"), "Salario 2013"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4078.71"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("203.94"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-6.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-115.87"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-457.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-264.38"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-85.65"), data);
        }

        public void PopularSalario2014()
        {
            var data = ToDateTime("01/12/2014");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2014"), toDecimal("4932.51"), "Salario 2014");

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-797.12"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2014"), toDecimal("1942.15"), "Salario 2014");

            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("6516.04"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-3258.02"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-832.95"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2014"), toDecimal("4034.29"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5171.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("258.57"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-130.32"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-498.46"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-10.45"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2014"), toDecimal("3258.02"), "Salario 2014"); 
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("3258.02"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2014"), toDecimal("2993.58"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3102.88"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("155.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("206.86"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("4137.17"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1448.01"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-4532"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-134.12"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-633.85"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2014"), toDecimal("4532.00"), "Salario 2014");
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("206.86"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("4137.17"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1448.01"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-633.85"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2014"), toDecimal("4962.41"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-797.12"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2014"), toDecimal("4832.09"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-130.32"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-797.12"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2014"), toDecimal("3597.94"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4137.17"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("206.86"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("103.43"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2068.58"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("724"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-2518.23"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-308.14"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-59.22"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2014"), toDecimal("2518.23"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("103.43"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2068.58"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("724"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-318.56"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-59.22"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2014"), toDecimal("4962.41"), "Salario 2014");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-797.12"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2014"), toDecimal("4871.29"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "Diferenca CCT", toDecimal("35.58"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-130.32"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-806.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2014"), toDecimal("4950.53"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5843.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("292.17"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("344.82"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-787.52"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-129.61"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2014"), toDecimal("4501.01"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5843.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("292.17"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-204.52"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-694.60"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-122.71"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2014"), toDecimal("4582.82"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5843.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("292.17"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-122.71"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-694.60"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-122.71"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2014"), toDecimal("4705.53"), "Salario 2014"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5843.46"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("292.17"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.24"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-122.63"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-482.92"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-694.60"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-122.71"), data);
        }

        public void PopularSalario2015()
        {
            var data = ToDateTime("01/12/2015");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2015"), toDecimal("3888.65"), "Salario 2015");

            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("168.21"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3364.14"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1177.45"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-308.14"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2015"), toDecimal("2086.99"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("7064.68"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-3532.34"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-932.34"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2015"), toDecimal("3052.38"), "Salario 2015"); 
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3364.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("168.21"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("168.21"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3364.14"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1177.45"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-3888.65"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-153.85"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-308.14"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2015"), toDecimal("3532.34"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("3532.34"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2015"), toDecimal("5190.77"), "Salario 2015");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-141.29"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-893.49"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2015"), toDecimal("5332.06"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-893.49"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2015"), toDecimal("5332.06"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-893.49"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2015"), toDecimal("5190.77"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-141.29"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-893.49"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2015"), toDecimal("5332.06"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-893.49"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2015"), toDecimal("5371.73"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "Diferenca CCT", toDecimal("54.72"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-908.54"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2015"), toDecimal("5190.45"), "Salario 2015"); data = data.AddMonths(-1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("521.28"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-140.75"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-888.98"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2015"), toDecimal("5331.2"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("521.28"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-888.98"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2015"), toDecimal("4106.19"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("5378.32"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("268.92"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-217.2"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-506.71"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2015"), toDecimal("3368.87"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3930.31"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("196.52"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("155.14"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3102.88"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1086.01"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-130.32"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-3599.26"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-288.34"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-266.93"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2015"), toDecimal("3599.26"), "Salario 2015");

            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("155.14"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3102.88"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1086.01"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-477.84"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-266.93"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2015"), toDecimal("4910.06"), "Salario 2015"); data = data.AddMonths(-1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6205.75"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("310.29"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-7.88"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-136.03"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-513.01"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-788.84"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-130.32"), data);
        }

        public void PopularSalario2016()
        {
            var data = ToDateTime("01/01/2016");
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2016"), toDecimal("5289.18"), "Salario 2016");

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-877.58"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2016"), toDecimal("5147.89"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-141.29"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-877.58"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2016"), toDecimal("5053.69"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-235.49"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-877.58"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2016"), toDecimal("5596.50"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("6728.27"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("336.41"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("423.88"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-994.14"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2016"), toDecimal("4023.04"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("4485.51"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("224.28"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("470.98"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("112.14"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2242.76"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("784.97"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-150.71"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-2727.71"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-454.48"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-66.78"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-141.29"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2016"), toDecimal("2727.71"), "Salario 2016");

            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("112.14"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("2242.76"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("784.97"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-345.38"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-66.78"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2016"), toDecimal("5590.36"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7131.97"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("356.60"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-147.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-991.81"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-149.77"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2016"), toDecimal("5559.48"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7131.97"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("356.60"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "Dif.Unimed", toDecimal("-15.44"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-991.81"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-149.77"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2016"), toDecimal("5615.95"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("369.76"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-155.3"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1066.28"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-155.3"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2016"), toDecimal("5771.25"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("369.76"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1066.28"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-155.3"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2016"), toDecimal("5771.25"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("369.76"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1066.28"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-155.3"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2016"), toDecimal("5604.38"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("369.76"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-155.3"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1066.28"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-41.47"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-155.3"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2016"), toDecimal("3882.45"), "Salario 2016");
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("3882.45"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2016"), toDecimal("2404.9"), "Salario 2016"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2465.05"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("123.25"), data);
            this.insertContraCheque(TransacaoId, "Desc.Indevido", toDecimal("11.57"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("246.50"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("4930.09"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1725.53"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-5258.32"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-39.67"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-871.73"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-155.3"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2016"), toDecimal("2202.58"), "Salario 2016");

            this.insertContraCheque(TransacaoId, "13.Salario", toDecimal("7764.9"), data);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("-3882.45"), data);
            this.insertContraCheque(TransacaoId, "INSS13.Salario", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "IRRF 13.Salario", toDecimal("-1108.99"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/12/2016"), toDecimal("5258.32"), "Salario 2016");
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("246.50"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("4930.09"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1725.53"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-570.88"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-8.8"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-871.73"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.9"), data);
        }

        public void PopularSalario2017()
        {
            var data = ToDateTime("01/01/2017"); 
            long TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2017"), toDecimal("6006.17"), "Salario 2017"); data = data.AddMonths(1);

            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("739.51"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1155.59"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-29.90"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-162.69"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2017"), toDecimal("5901.03"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("739.51"), data);
            this.insertContraCheque(TransacaoId, "Desc.Indevido", toDecimal("29.90"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-162.69"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1155.60"), data);
            this.insertContraCheque(TransacaoId, "Internet", toDecimal("-2.24"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-162.69"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2017"), toDecimal("5764.90"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("739.51"), data);
            this.insertContraCheque(TransacaoId, "Contrib.Sindical", toDecimal("-271.16"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1155.60"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-162.69"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2017"), toDecimal("6212.99"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7395.14"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("739.51"), data);
            this.insertContraCheque(TransacaoId, "ANTECIPACAO.SALARIAL", toDecimal("244.04"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1222.71"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-162.69"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2017"), toDecimal("6130.05"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-170.13"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1255.79"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2017"), toDecimal("6300.18"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-162.49"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1255.79"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2017"), toDecimal("4539.68"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("386.66"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3866.55"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1417.74"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-522.83"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2017"), toDecimal("3607.54"), "Salario 2017"); 
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("3866.55"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("386.66"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("386.66"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3866.55"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1417.74"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "Dif.Unimed", toDecimal("-10.56"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-4539.68"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-282.56"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-522.83"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/08/2017"), toDecimal("6119.49"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-170.13"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1255.79"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/09/2017"), toDecimal("6289.62"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1255.79"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/10/2017"), toDecimal("6289.62"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-9.37"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1255.79"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2017"), toDecimal("4253.20"), "Salario 2017"); data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Adto.13.Salario", toDecimal("4253.20"), data);

            TransacaoId = this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/11/2017"), toDecimal("4539.68"), "FERIAS 2017");  
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("386.66"), data);
            this.insertContraCheque(TransacaoId, "Adic.Férias.1/3", toDecimal("1417.74"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("3866.55"), data);
            this.insertContraCheque(TransacaoId, "INSSFerias", toDecimal("-608.44"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-522.83"), data);
        }

        public void PopularSalario2018()
        {
            var data = ToDateTime("01/01/2018");
            long TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/01/2018"), toDecimal("6104.26"), "Salario 2018");
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.47"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-170.13"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1252.33"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/02/2018"), toDecimal("6104.26"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.47"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-170.13"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1252.33"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/03/2018"), toDecimal("6274.40"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.47"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1252.33"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/04/2018"), toDecimal("6274.40"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7733.09"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("773.31"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.47"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1252.33"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-170.13"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/05/2018"), toDecimal("6292.12"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7853.73"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("785.37"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.46"), data);
            this.insertContraCheque(TransacaoId, "Tx.Assist.SAAE", toDecimal("-172.78"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-173.05"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1324.58"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-172.78"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/06/2018"), toDecimal("6362.92"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("7853.73"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("785.37"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.77"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-177.89"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-1288.09"), data);
            this.insertContraCheque(TransacaoId, "Dif.Mensalidade Sindical", toDecimal("-0.62"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-172.78"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2018"), toDecimal("2646.71"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "Salario", toDecimal("2617.91"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("261.79"), data);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("523.58"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("5235.82"), data);
            this.insertContraCheque(TransacaoId, "Adic.Ferias 1/3", toDecimal("1919.80"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.46"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-177.89"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "Liquido de Ferias", toDecimal("-5793.19"), data);
            this.insertContraCheque(TransacaoId, "IRRF", toDecimal("-60.21"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-1071.63"), data);
            this.insertContraCheque(TransacaoId, "SMC.Prev.Basica", toDecimal("-172.78"), data);

            TransacaoId =this.insertSalario(PopularDB.SalarioId, "Salario", ToDateTime("01/07/2018"), toDecimal("5793.19"), "Salario 2018");
            data = data.AddMonths(1);
            this.insertContraCheque(TransacaoId, "ATS Administrativo", toDecimal("523.58"), data);
            this.insertContraCheque(TransacaoId, "Ferias", toDecimal("5235.82"), data);
            this.insertContraCheque(TransacaoId, "Adic.Ferias 1/3", toDecimal("1919.80"), data);
            this.insertContraCheque(TransacaoId, "INSS", toDecimal("-621.03"), data);
            this.insertContraCheque(TransacaoId, "SAAE/MG", toDecimal("-15.46"), data);
            this.insertContraCheque(TransacaoId, "Unimed", toDecimal("-177.89"), data);
            this.insertContraCheque(TransacaoId, "IRRF Ferias", toDecimal("-1071.63"), data);
        }
    }
}