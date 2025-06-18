using Ex42;

string ReadValidOption(string prompt, string[] validOptions)
{
    string option;
    do
    {
        Console.WriteLine(prompt);
        option = Console.ReadLine();
        if (Array.Exists(validOptions, o => o.Equals(option, StringComparison.OrdinalIgnoreCase)))
        {
            return option;
        }
        Console.WriteLine("Opção inválida. Tente novamente.");
    } while (true);
}

var type = ReadValidOption("Tipo de pizza (Margherita, Pepperoni):", new[] { "Margherita", "Pepperoni" });
var size = ReadValidOption("Tamanho (Small, Medium, Large):", new[] { "Small", "Medium", "Large" });

Console.WriteLine("Adicionar queijo extra? (s/n):");
var cheese = Console.ReadLine() == "s";

Console.WriteLine("Adicionar cogumelos? (s/n):");
var mushrooms = Console.ReadLine() == "s";

var builder = PizzaFactory.Create(type)
   .SetSize(size)
   .AddExtraCheese(cheese)
   .AddMushrooms(mushrooms);

var pizza = builder.Build();
pizza.Bake();
pizza.Serve();