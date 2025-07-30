// See https://aka.ms/new-console-template for more information
using DanpsPack.FleetToolkit;
using DanpsPack.FleetToolkit.Interfaces;

Console.WriteLine("Hello, World!");

    IFleetManager manager = new FleetManager(); // implementação do colega

    // 1) Buscar carros disponíveis para a próxima semana
    var available = manager.GetAvailableCars(
        DateTime.Today.AddDays(1),
        DateTime.Today.AddDays(7)
    );
    Console.WriteLine("Carros disponíveis:");
    foreach (var car in available)
        Console.WriteLine($"  {car.Id} – {car.Model}");

    // 2) Reservar o primeiro carro
    var firstCar = available.FirstOrDefault()?.Id;
    if (firstCar != null)
    {
        manager.ReserveCar(firstCar,
            DateTime.Today.AddDays(1),
            DateTime.Today.AddDays(7)
        );
        Console.WriteLine($"Reservado carro {firstCar} para 1–7 dias.");
    }

    // 3) Calcular custo de 5 dias
    var cost = manager.CalculateRentalCost(firstCar, 5);
    Console.WriteLine($"Custo de 5 dias: {cost:C}");

    // 4) Listar devoluções atrasadas (hoje)
    var overdue = manager.GetOverdueReturns(DateTime.Today);
    Console.WriteLine("Devoluções atrasadas:");
    foreach (var car in overdue)
        Console.WriteLine($"  {car.Id} – {car.Model}");
