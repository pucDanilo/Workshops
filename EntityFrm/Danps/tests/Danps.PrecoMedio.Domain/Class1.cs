using Danps.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Danps.PrecoMedio.Domain
{
    public enum TipoCombustivel : short
    {
        Gasolina = 1,
        Etanol = 2,
        Diesel = 3
    }

    public class PrecoMedio : Entity
    {
        public Guid Id { get; set; }
        public TipoCombustivel TipoCombustivel { get; private set; }
        public double ValorMedio { get; private set; }
        public double ValorMinimo { get; private set; }
        public double ValorMaximo { get; private set; }

        protected PrecoMedio(TipoCombustivel tipoCombustivel, double valorMinimo, double valorMaximo)
        {
            this.TipoCombustivel = tipoCombustivel;
            AlterarPreco(valorMinimo, valorMaximo);
        }

        public void AlterarPreco(double valorMinimo, double valorMaximo)
        {
            this.ValorMinimo = valorMinimo;
            this.ValorMaximo = valorMaximo;
            var valorMedio = (valorMinimo + valorMaximo) / 2;
            AlterarPrecoMedio(valorMedio);
        }

        public void AlterarPrecoMedio(double valorMedio)
        {
            this.ValorMedio = valorMedio;
        }
    }

    public class Veiculo : Entity
    {
        public string Nome { get; private set; }
        public double Odometro { get; private set; }
        public double DistanciaPercorrida { get; private set; }

        private readonly List<Abastecimento> _abastecimentoItems;
        public IReadOnlyCollection<Abastecimento> AbastecimentoItems => _abastecimentoItems;

        public double DistanciaPorVolume { get; private set; }

        protected Veiculo()
        {
            _abastecimentoItems = new List<Abastecimento>();
        }

        public Veiculo(string nome, double odometro, double distanciaPorVolume = 10)
        {
            this.Nome = nome;
            this.Odometro = odometro;
            this.DistanciaPorVolume = distanciaPorVolume;
            _abastecimentoItems = new List<Abastecimento>();
        }

        public void AtualizarDistanciaPorVolume(double distanciaPorVolume)
        {
            this.DistanciaPorVolume = distanciaPorVolume;
        }

        public void AtualizarDistanciaPercorrida(double distanciaPercorrida)
        {
            this.DistanciaPercorrida = distanciaPercorrida;
            this.Odometro += distanciaPercorrida;
        }

        public void AtualizarOdometro(double odometroAtual)
        {
            this.DistanciaPercorrida = odometroAtual - this.Odometro;
            this.Odometro = odometroAtual;
        }

        public void Abastecer(Combustivel combustivel)
        {
            var distancia = CalcularDistancia(combustivel.Quantidade);

            Abastecer(combustivel, distancia);
        }

        private double CalcularDistancia(double quantidade)
        {
            if (DistanciaPorVolume <= 0) DistanciaPorVolume = 10;

            return quantidade * DistanciaPorVolume;
        }

        public void Abastecer(Combustivel combustivel, double distanciaPercorrida)
        {
            this.AtualizarDistanciaPercorrida(distanciaPercorrida);
            var item = new Abastecimento(combustivel, this.DistanciaPercorrida);
            item.AssociarVeiculo(Id);
            _abastecimentoItems.Add(item);
        }

        public void AbastecerOdometro(double odometroAtual, Combustivel combustivel)
        {
            AtualizarOdometro(odometroAtual);

            var item = new Abastecimento(combustivel, this.DistanciaPercorrida);
            item.AssociarVeiculo(Id);
            _abastecimentoItems.Add(item);
        }
    }

    public class Combustivel
    {
        public TipoCombustivel TipoCombustivel { get; private set; }
        public double ValorPago { get; private set; }
        public double Quantidade { get; private set; }
        public double PrecoUnitario { get; private set; }

        public Combustivel(TipoCombustivel tipoCombustivel, double valorPago, double quantidade)
        {
            this.TipoCombustivel = tipoCombustivel;
            this.ValorPago = valorPago;
            this.Quantidade = quantidade;
            this.PrecoUnitario = valorPago / quantidade;
        }
    }

    public class Abastecimento : Entity
    {
        public int VeiculoId { get; private set; }
        public Combustivel Combustivel { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public double Distancia { get; private set; }

        protected Abastecimento()
        {
        }

        public Abastecimento(Combustivel combustivel, double distancia)
        {
            this.Combustivel = combustivel;
            this.Distancia = distancia;
            Validar();
        }

        internal void AssociarVeiculo(int veiculoId)
        {
            this.VeiculoId = veiculoId;
        }

        internal void AtualizarDistancia(double valor)
        {
            this.Distancia = valor;
        }

        public void Validar()
        {
        }
    }
}