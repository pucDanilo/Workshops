using System;

namespace Ex40;

 public class CurrencyConverter
    {
        // complexidade extra para conversão de moedas
        public decimal ToUSD(decimal amount, string fromCurrency)
        {
            // API externa simulada
            if (fromCurrency == "BRL") return amount / 5.0m;
            if (fromCurrency == "EUR") return amount / 0.9m;
            // ...
            return amount;
        }
    }