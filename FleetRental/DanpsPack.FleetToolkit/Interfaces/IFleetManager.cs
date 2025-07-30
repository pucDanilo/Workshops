using DanpsPack.FleetToolkit.Models;

namespace DanpsPack.FleetToolkit.Interfaces
{
    public interface IFleetManager
    {
        /// <summary>
        /// Retorna os carros disponíveis para o período informado.
        /// </summary>
        IEnumerable<Car> GetAvailableCars(DateTime from, DateTime to);

        /// <summary>
        /// Reserva o carro identificado por <paramref name="carId"/> no período.
        /// </summary>
        void ReserveCar(string carId, DateTime from, DateTime to);

        /// <summary>
        /// Calcula o valor do aluguel desse carro por <paramref name="days"/> dias.
        /// </summary>
        decimal CalculateRentalCost(string carId, int days);

        /// <summary>
        /// Lista os carros que deveriam ter sido devolvidos até <paramref name="asOf"/>.
        /// </summary>
        IEnumerable<Car> GetOverdueReturns(DateTime asOf);

        /// <summary>
        /// (Desafio) Prevê a data da próxima manutenção com base em uso e histórico.
        /// </summary>
        DateTime PredictMaintenanceDate(Car car);
    }
}
