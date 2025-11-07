using Danps.PrecoMedio.Domain;
using System;

namespace Danps.PrecoMedio.ConsoleApp1
{
    class Program
    {
        public static Veiculo Teste()
        {
            var veiculo = new Veiculo("Honda Civic", 76080);

            var combustivel = new Combustivel(TipoCombustivel.Gasolina, 167.68, 9.54);
            veiculo.Abastecer(combustivel, 200);

            var combustivel2 = new Combustivel(TipoCombustivel.Gasolina, 267.68, 19.54);
            
            veiculo.AbastecerOdometro(76500,combustivel2);

            return veiculo;
        }
        static void Main(string[] args)
        {
            Teste();
            Console.WriteLine("Hello World!");
        }
    }
}
