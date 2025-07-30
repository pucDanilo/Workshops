namespace DanpsPack.FleetToolkit.Models
{ 
    public class Car
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public decimal DailyRate { get; set; }
        public DateTime LastMaintenance { get; set; }
        public int Mileage { get; set; }

        public Car() { }
         
        public Car(string id, string model, decimal dailyRate, DateTime lastMaintenance, int mileage)
        {
            Id = id;
            Model = model;
            DailyRate = dailyRate;
            LastMaintenance = lastMaintenance;
            Mileage = mileage;
        }
    }
}
