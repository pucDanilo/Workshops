using Ex40;

var employees = new[] { ("Alice", 3000m), ("Bob", 4500m), ("Carol", 2000m) };
var processor = new PayrollProcessor();

foreach (var (name, salary) in employees)
{
    processor.Process(name, salary);
    Console.WriteLine();
}

Console.WriteLine("Processamento concluído. Pressione qualquer tecla...");
Console.ReadKey();