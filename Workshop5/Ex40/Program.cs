using Ex40;

var rep = new EmployeeRepository();
var processor = new PayrollProcessor(rep);
processor.ProcessAllEmployees();

Console.WriteLine("Processamento concluído. Pressione qualquer tecla...");
Console.ReadKey();