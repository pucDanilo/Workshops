using FluentMigrator;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180804144500)]
    public class DefaultDB_20180804_144500_Transacao : PopularDB
    {
        public override void Up()
        {
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("21/08/2017"), PopularDB.toDecimal("16458.63"), "Saldo Anterior");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("21/08/2017"), PopularDB.toDecimal("-12.28"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("22/08/2017"), PopularDB.toDecimal("-15.67"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("22/08/2017"), PopularDB.toDecimal("-4.67"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("23/08/2017"), PopularDB.toDecimal("-14.04"), "RESTAURANTE CAN");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("23/08/2017"), PopularDB.toDecimal("-4.95"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("24/08/2017"), PopularDB.toDecimal("-15.95"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("25/08/2017"), PopularDB.toDecimal("-13.48"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("25/08/2017"), PopularDB.toDecimal("-7.39"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("28/08/2017"), PopularDB.toDecimal("-14.12"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("29/08/2017"), PopularDB.toDecimal("-899.99"), "WAZ CAIXA SOM");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("29/08/2017"), PopularDB.toDecimal("-12.92"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("30/08/2017"), PopularDB.toDecimal("-13.48"), "RESTAURANTE FEIJAO E PROSA");
            insertTransacao(PopularDB.SantanderId, "LIQUIDO.DE.VENCIMENTO", PopularDB.ToDateTime("01/09/2017"), PopularDB.toDecimal("6119.49"), "Salario");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("01/09/2017"), PopularDB.toDecimal("-16.32"), "RESTAURANTE FEIJAO E PROSA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("01/09/2017"), PopularDB.toDecimal("-40"), "RESTAURANTE EXTRA AMBU");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("04/09/2017"), PopularDB.toDecimal("-13.24"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("05/09/2017"), PopularDB.toDecimal("-13.3"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("06/09/2017"), PopularDB.toDecimal("-15.33"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "FATURA.CARTAO", PopularDB.ToDateTime("08/09/2017"), PopularDB.toDecimal("-52.74"), "CARTAO VISA");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("08/09/2017"), PopularDB.toDecimal("-182.38"), "Cerveja");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("08/09/2017"), PopularDB.toDecimal("-45.9"), "Bol");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("08/09/2017"), PopularDB.toDecimal("-13.8"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("08/09/2017"), PopularDB.toDecimal("-5.77"), "RESTAURANTE PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("-12.12"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "DEPOSITO", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("469.50"), "TED PAULINE OLIVEIRA");
            insertTransacao(PopularDB.SantanderId, "DEPOSITO", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("630.00"), "CHEQUE Dinha");
            insertTransacao(PopularDB.SantanderId, "RECARGA.TELEFONE.CELULAR", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("-30"), "31 *****6760 TIM BRASI");
            insertTransacao(PopularDB.SantanderId, "RECARGA.TELEFONE.CELULAR", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("-50"), "31 *****8958 TIM BRASI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("11/09/2017"), PopularDB.toDecimal("-6.95"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("12/09/2017"), PopularDB.toDecimal("-314.33"), "PES 2018");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("12/09/2017"), PopularDB.toDecimal("-5"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("13/09/2017"), PopularDB.toDecimal("-14.36"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-45.09"), "CHINA Camisa 13.236.697/0001-46");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-38.89"), "CHINA Bateria 13.236.697/0001-46");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-42.18"), "CHINA Ventilador 13.236.697/0001-46");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-9.96"), "CHINA Pelicula 13.236.697/0001-46");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-16.43"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("14/09/2017"), PopularDB.toDecimal("-5.19"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("15/09/2017"), PopularDB.toDecimal("-13.99"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("15/09/2017"), PopularDB.toDecimal("-21.44"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "SAQUE", PopularDB.ToDateTime("18/09/2017"), PopularDB.toDecimal("-200"), "Dinheiro");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("18/09/2017"), PopularDB.toDecimal("-10.85"), "RESTAURANTE TRI");

            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("19/09/2017"), PopularDB.toDecimal("-12.13"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("20/09/2017"), PopularDB.toDecimal("-12.60"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("20/09/2017"), PopularDB.toDecimal("-2.34"), "PAO NOSSO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("21/09/2017"), PopularDB.toDecimal("-12.81"), "RESTAURANTE ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ESTORNO.PAGAMENTO.TITULO", PopularDB.ToDateTime("21/09/2017"), PopularDB.toDecimal("899.99"), "WAZ JBL");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("22/09/2017"), PopularDB.toDecimal("-197.62"), "Cerveja");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("22/09/2017"), PopularDB.toDecimal("-909"), "WALLMART");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("22/09/2017"), PopularDB.toDecimal("-12.28"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("26/09/2017"), PopularDB.toDecimal("-13.31"), "FEIJAO E PROSA ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("27/09/2017"), PopularDB.toDecimal("-10.53"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("28/09/2017"), PopularDB.toDecimal("-15.15"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("29/09/2017"), PopularDB.toDecimal("-12.30"), "FEIJAO E PROSA ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("29/09/2017"), PopularDB.toDecimal("-2.27"), "PAO NOSSO ");
            insertTransacao(PopularDB.SantanderId, "SALARIO", PopularDB.ToDateTime("02/10/2017"), PopularDB.toDecimal("6289.62"), "SALARIO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("02/10/2017"), PopularDB.toDecimal("-56.85"), "EMPORIO BAR");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("02/10/2017"), PopularDB.toDecimal("-15.97"), "FEIJAO E PROSA ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("03/10/2017"), PopularDB.toDecimal("-11.32"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("03/10/2017"), PopularDB.toDecimal("-4.62"), "PAO NOSSO ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("04/10/2017"), PopularDB.toDecimal("-15.17"), "LUMA FONSECA AM ");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("05/10/2017"), PopularDB.toDecimal("-171.43"), "DAFITI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("06/10/2017"), PopularDB.toDecimal("-53.20"), "GIOVANNI PIZZAR ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("09/10/2017"), PopularDB.toDecimal("-189.40"), "LOJAS RENNER FL ");
            insertTransacao(PopularDB.SantanderId, "DEPOSITO", PopularDB.ToDateTime("09/10/2017"), PopularDB.toDecimal("470"), "PAULINE");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("09/10/2017"), PopularDB.toDecimal("-12.28"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("10/10/2017"), PopularDB.toDecimal("-13.65"), "LUMA FONSECA AM ");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("11/10/2017"), PopularDB.toDecimal("-946.56"), "FATURA CARTAO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("11/10/2017"), PopularDB.toDecimal("-12.45"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("11/10/2017"), PopularDB.toDecimal("-16000.00"), "DEPOSITO_POUPANCA");

            insertTitulo(PopularDB.SantanderInv, "POUPANCA", "POUPANCA SANTANDER", PopularDB.ToDateTime("11/10/2017"), PopularDB.toDecimal("16000.00"));
            insertProtocolo(PopularDB.SantanderInv, "POUPANCA SANTANDER", PopularDB.ToDateTime("15/09/2017"), 1, PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), PopularDB.toDecimal("65070.06"), "POUPANCA ESPECIAL PF 3476-60.028285.1");

            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("11/10/2017"), PopularDB.toDecimal("-12.06"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("13/10/2017"), PopularDB.toDecimal("-344.76"), "DAFITI");
            insertTransacao(PopularDB.SantanderId, "DEPOSITO", PopularDB.ToDateTime("16/10/2017"), PopularDB.toDecimal("794.43"), "RESTITUICAO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("16/10/2017"), PopularDB.toDecimal("-12.12"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("17/10/2017"), PopularDB.toDecimal("-13.82"), "FEIJAO E PROSA ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("18/10/2017"), PopularDB.toDecimal("-12.57"), "RESTAURANTE TRI ");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("19/10/2017"), PopularDB.toDecimal("-13.14"), "FEIJAO E PROSA");

            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("18/10/2017"), PopularDB.toDecimal("-12,57"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("19/10/2017"), PopularDB.toDecimal("-13,14"), "FEIJAO E PROSA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("20/10/2017"), PopularDB.toDecimal("-14,36"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("23/10/2017"), PopularDB.toDecimal("-13,78"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("24/10/2017"), PopularDB.toDecimal("-11,81"), "ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("25/10/2017"), PopularDB.toDecimal("-13,20"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("26/10/2017"), PopularDB.toDecimal("-14,49"), "LUMA FONSECA AM");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("27/10/2017"), PopularDB.toDecimal("-13,35"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("30/10/2017"), PopularDB.toDecimal("-10,70"), "RESTAURANTE TRI");
            insertTransacao(PopularDB.SantanderId, "SAQUE", PopularDB.ToDateTime("30/10/2017"), PopularDB.toDecimal("-200,00"), "Dinheiro");
            insertTransacao(PopularDB.SantanderId, "REMUNERACAO", PopularDB.ToDateTime("30/10/2017"), PopularDB.toDecimal("0,05"), "REMUNERACAO CONTAMAX CDB DI");
            insertTransacao(PopularDB.SantanderId, "SALARIO", PopularDB.ToDateTime("31/10/2017"), PopularDB.toDecimal("4539,68"), "SALARIO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("31/10/2017"), PopularDB.toDecimal("-13,48"), "ANA LUMA");
            insertTransacao(PopularDB.SantanderId, "SAQUE", PopularDB.ToDateTime("31/10/2017"), PopularDB.toDecimal("-200,00"), "Dinheiro");
            insertTransacao(PopularDB.SantanderId, "SALARIO", PopularDB.ToDateTime("01/11/2017"), PopularDB.toDecimal("6289,62"), "SALARIO");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("03/11/2017"), PopularDB.toDecimal("-62,26"), "COCONUT");
            insertTransacao(PopularDB.SantanderId, "REMUNERACAO", PopularDB.ToDateTime("03/11/2017"), PopularDB.toDecimal("0,31"), "REMUNERACAO CONTAMAX CDB DI");
            insertTransacao(PopularDB.SantanderId, "REMUNERACAO", PopularDB.ToDateTime("06/11/2017"), PopularDB.toDecimal("1,98"), "REMUNERACAO CONTAMAX CDB DI");
            insertTransacao(PopularDB.SantanderId, "FATURA.CARTAO", PopularDB.ToDateTime("07/11/2017"), PopularDB.toDecimal("-1418,40"), "CARTAO VISA");
            insertTransacao(PopularDB.SantanderId, "REMUNERACAO", PopularDB.ToDateTime("07/11/2017"), PopularDB.toDecimal("0,12"), "REMUNERACAO CONTAMAX CDB DI");

            insertTransacao(PopularDB.SantanderId, "RECARGA.TELEFONE.CELULAR", PopularDB.ToDateTime("13/11/2017"), PopularDB.toDecimal("-50"), "31 *****8958 TIM BRASI");
            insertTransacao(PopularDB.SantanderId, "PAGAMENTO.TITULO", PopularDB.ToDateTime("20/11/2017"), PopularDB.toDecimal("-112,25"), "Camisa.RedBug");
            insertTransacao(PopularDB.SantanderId, "ALIMENTACAO", PopularDB.ToDateTime("20/11/2017"), PopularDB.toDecimal("-15,36"), "RESTAURANTE CAN");
        }
    }
}