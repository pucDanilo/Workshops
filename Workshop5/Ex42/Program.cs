using Ex42;

Console.WriteLine("Tipo de pizza (Margherita, Pepperoni):");
var type = Console.ReadLine();

Console.WriteLine("Tamanho (Small, Medium, Large):");
var size = Console.ReadLine();

Console.WriteLine("Adicionar queijo extra? (s/n):");
var cheese = Console.ReadLine() == "s";

Console.WriteLine("Adicionar cogumelos? (s/n):");
var mushrooms = Console.ReadLine() == "s";

// montagem direta do objeto
var pizza = new Pizza
{
    Type = type,
    Size = size,
    ExtraCheese = cheese,
    Mushrooms = mushrooms
};

pizza.Bake();
pizza.Serve();