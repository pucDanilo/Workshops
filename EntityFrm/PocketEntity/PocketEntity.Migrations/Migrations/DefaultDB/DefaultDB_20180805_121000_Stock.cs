using FluentMigrator;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180805121000)]
    public class DefaultDB_20180805_121000_Stock : PopularDB
    {
        public override void Up()
        {
            long USIM3Id = this.insertStock(PopularDB.BradescoStockId, "USIMINAS ON N1", "USIM3", PopularDB.toDecimal("10.49"));
            long PETR4Id = this.insertStock(PopularDB.BradescoStockId, "PETROBRAS PN", "PETR4", PopularDB.toDecimal("13.21"));
            long USIM5Id = this.insertStock(PopularDB.BradescoStockId, "USIMINAS PNA N1", "USIM5", PopularDB.toDecimal("5.21"));
            long VALE5Id = this.insertStock(PopularDB.BradescoStockId, "VALE PNA N1", "VALE5", PopularDB.toDecimal("29.22"));
            long VALE3Id = this.insertStock(PopularDB.BradescoStockId, "VALE ON N1", "VALE3", PopularDB.toDecimal("31.30"));
            long OIBR3Id = this.insertStock(PopularDB.BradescoStockId, "OI ON N1", "OIBR3", PopularDB.toDecimal("4.19"));
            long PRML3Id = this.insertStock(PopularDB.BradescoStockId, "PRUMO ON NM", "PRML3", PopularDB.toDecimal("11.01"));
            long PETR3Id = this.insertStock(PopularDB.BradescoStockId, "PETROBRAS ON", "PETR3", PopularDB.toDecimal("13.72"));
            long OIBR4Id = this.insertStock(PopularDB.BradescoStockId, "OI PN N1", "OIBR4", PopularDB.toDecimal("3.55"));
            long BBAS3Id = this.insertStock(PopularDB.BradescoStockId, "BRASIL ON EJ NM ", "BBAS3", PopularDB.toDecimal("3.55"));
            long EBTP3Id = this.insertStock(PopularDB.BradescoStockId, "EMBRATEL PAR ON", "EBTP3", PopularDB.toDecimal("3.55"));
            long TOYB3Id = this.insertStock(PopularDB.BradescoStockId, "TECTOY ON", "TOYB3", PopularDB.toDecimal("3.79"));
            long VAGV4Id = this.insertStock(PopularDB.BradescoStockId, "VARIG PN", "VAGV4", PopularDB.toDecimal("3.79"));
            long UBBR4Id = this.insertStock(PopularDB.BradescoStockId, "UNIBANCO PN", "UBBR4", PopularDB.toDecimal("3.79"));
            long MMXM3Id = this.insertStock(PopularDB.BradescoStockId, "MMX MINER ON NM", "MMXM3", PopularDB.toDecimal("3.79"));

            //long VendaId = db.insertNatureza(PopularDB.BradescoStockId, "Venda Pregao");
            //long CompraId = db.insertNatureza(PopularDB.BradescoStockId, "Compra Pregao");

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, OIBR4Id, PopularDB.toDecimal("268"), PopularDB.ToDateTime("22/04/2014"), PopularDB.toDecimal("2.70"), PopularDB.toDecimal("155"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, OIBR4Id, PopularDB.toDecimal("268"), PopularDB.ToDateTime("22/04/2014"), PopularDB.toDecimal("2.68"), PopularDB.toDecimal("-100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, OIBR4Id, PopularDB.toDecimal("18.76"), PopularDB.ToDateTime("22/04/2014"), PopularDB.toDecimal("2.68"), PopularDB.toDecimal("-54"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("432.9"), PopularDB.ToDateTime("09/10/2008"), PopularDB.toDecimal("33.30"), PopularDB.toDecimal("33"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("916"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("9.16"), PopularDB.toDecimal("100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("705.32"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("9.16"), PopularDB.toDecimal("77"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("1610.00"), PopularDB.ToDateTime("06/01/2015"), PopularDB.toDecimal("8.05"), PopularDB.toDecimal("200"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("1000"), PopularDB.ToDateTime("04/02/2015"), PopularDB.toDecimal("10"), PopularDB.toDecimal("-100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("1000"), PopularDB.ToDateTime("04/02/2015"), PopularDB.toDecimal("10"), PopularDB.toDecimal("-100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("2460"), PopularDB.ToDateTime("06/01/2016"), PopularDB.toDecimal("8.20"), PopularDB.toDecimal("300"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("2965"), PopularDB.ToDateTime("20/01/2016"), PopularDB.toDecimal("5.93"), PopularDB.toDecimal("500"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("3375"), PopularDB.ToDateTime("05/02/2016"), PopularDB.toDecimal("6.75"), PopularDB.toDecimal("-500"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR3Id, PopularDB.toDecimal("3060"), PopularDB.ToDateTime("07/03/2016"), PopularDB.toDecimal("10.20"), PopularDB.toDecimal("-300"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("1068.00"), PopularDB.ToDateTime("09/10/2008"), PopularDB.toDecimal("26.70"), PopularDB.toDecimal("40"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("3344.40"), PopularDB.ToDateTime("09/10/2008"), PopularDB.toDecimal("27.87"), PopularDB.toDecimal("120"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("2991"), PopularDB.ToDateTime("05/05/2010"), PopularDB.toDecimal("29.91"), PopularDB.toDecimal("100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("955.00"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("9.55"), PopularDB.toDecimal("100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("382"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("9.55"), PopularDB.toDecimal("40"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("1680"), PopularDB.ToDateTime("06/01/2015"), PopularDB.toDecimal("8.4"), PopularDB.toDecimal("200"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("1680"), PopularDB.ToDateTime("06/01/2015"), PopularDB.toDecimal("8.4"), PopularDB.toDecimal("200"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("4120"), PopularDB.ToDateTime("04/02/2015"), PopularDB.toDecimal("10.3"), PopularDB.toDecimal("-400"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("2610"), PopularDB.ToDateTime("23/04/2015"), PopularDB.toDecimal("13.05"), PopularDB.toDecimal("-200"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("3918"), PopularDB.ToDateTime("06/01/2016"), PopularDB.toDecimal("6.53"), PopularDB.toDecimal("600"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("3290"), PopularDB.ToDateTime("19/01/2016"), PopularDB.toDecimal("4.7"), PopularDB.toDecimal("700"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("5222"), PopularDB.ToDateTime("08/03/2016"), PopularDB.toDecimal("7.46"), PopularDB.toDecimal("-700"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PETR4Id, PopularDB.toDecimal("2400"), PopularDB.ToDateTime("11/03/2016"), PopularDB.toDecimal("8"), PopularDB.toDecimal("-300"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, PRML3Id, PopularDB.toDecimal("4.00"), PopularDB.ToDateTime("06/01/2015"), PopularDB.toDecimal("4.00"), PopularDB.toDecimal("100"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM3Id, PopularDB.toDecimal("584"), PopularDB.ToDateTime("19/03/2011"), PopularDB.toDecimal("29.20"), PopularDB.toDecimal("20"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM3Id, PopularDB.toDecimal("777"), PopularDB.ToDateTime("15/06/2009"), PopularDB.toDecimal("38.85"), PopularDB.toDecimal("20"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("480"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("4.80"), PopularDB.toDecimal("100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("81.60"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("4.80"), PopularDB.toDecimal("17"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("124.80"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("4.80"), PopularDB.toDecimal("26"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("81.60"), PopularDB.ToDateTime("02/01/2015"), PopularDB.toDecimal("4.80"), PopularDB.toDecimal("17"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("422.40"), PopularDB.ToDateTime("19/03/2011"), PopularDB.toDecimal("21.12"), PopularDB.toDecimal("20"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, USIM5Id, PopularDB.toDecimal("1370"), PopularDB.ToDateTime("24/07/2008"), PopularDB.toDecimal("68.50"), PopularDB.toDecimal("20"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VALE5Id, PopularDB.toDecimal("2455.8"), PopularDB.ToDateTime("17/07/2008"), PopularDB.toDecimal("40.93"), PopularDB.toDecimal("60"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VALE5Id, PopularDB.toDecimal("435"), PopularDB.ToDateTime("03/10/2008"), PopularDB.toDecimal("29.00"), PopularDB.toDecimal("15"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VALE5Id, PopularDB.toDecimal("1040"), PopularDB.ToDateTime("09/10/2008"), PopularDB.toDecimal("26"), PopularDB.toDecimal("40"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VALE5Id, PopularDB.toDecimal("2150"), PopularDB.ToDateTime("04/05/2010"), PopularDB.toDecimal("43"), PopularDB.toDecimal("50"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VALE3Id, PopularDB.toDecimal("4500"), PopularDB.ToDateTime("06/05/2010"), PopularDB.toDecimal("45.00"), PopularDB.toDecimal("100"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, BBAS3Id, PopularDB.toDecimal("510.00"), PopularDB.ToDateTime("22/06/2009"), PopularDB.toDecimal("20.4"), PopularDB.toDecimal("25"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, BBAS3Id, PopularDB.toDecimal("726"), PopularDB.ToDateTime("27/04/2011"), PopularDB.toDecimal("29.04"), PopularDB.toDecimal("-25"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, EBTP3Id, PopularDB.toDecimal("445"), PopularDB.ToDateTime("15/05/2009"), PopularDB.toDecimal("8.9"), PopularDB.toDecimal("50"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, EBTP3Id, PopularDB.toDecimal("478.5"), PopularDB.ToDateTime("26/05/2009"), PopularDB.toDecimal("9.57"), PopularDB.toDecimal("-50"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, TOYB3Id, PopularDB.toDecimal("280"), PopularDB.ToDateTime("31/03/2009"), PopularDB.toDecimal("0.07"), PopularDB.toDecimal("4000"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, TOYB3Id, PopularDB.toDecimal("360"), PopularDB.ToDateTime("20/05/2009"), PopularDB.toDecimal("0.09"), PopularDB.toDecimal("-4000"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VAGV4Id, PopularDB.toDecimal("324"), PopularDB.ToDateTime("25/03/2009"), PopularDB.toDecimal("1.08"), PopularDB.toDecimal("300"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, VAGV4Id, PopularDB.toDecimal("372"), PopularDB.ToDateTime("05/05/2009"), PopularDB.toDecimal("1.24"), PopularDB.toDecimal("-300"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, UBBR4Id, PopularDB.toDecimal("345"), PopularDB.ToDateTime("15/01/2009"), PopularDB.toDecimal("6.9"), PopularDB.toDecimal("50"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, UBBR4Id, PopularDB.toDecimal("360"), PopularDB.ToDateTime("20/01/2009"), PopularDB.toDecimal("7.20"), PopularDB.toDecimal("-50"));

            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, MMXM3Id, PopularDB.toDecimal("344"), PopularDB.ToDateTime("12/01/2009"), PopularDB.toDecimal("3.44"), PopularDB.toDecimal("100"));
            this.insertPregao(PopularDB.BradescoId, PopularDB.BradescoStockId, MMXM3Id, PopularDB.toDecimal("365"), PopularDB.ToDateTime("14/01/2009"), PopularDB.toDecimal("3.65"), PopularDB.toDecimal("-100"));
        }
    }
}