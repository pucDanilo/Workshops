namespace DanpsPack.FleetToolkit
{
    // Classe de suporte para reservas (pode ser ajustada conforme necessidade)
    internal class Reservation
    {
        public string CustomerId { get; set; }
        public string CarId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}