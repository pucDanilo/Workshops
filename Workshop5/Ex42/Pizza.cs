using System;

namespace Ex42;

public class Pizza
{
    public string Type { get; set; }
    public string Size { get; set; }
    public bool ExtraCheese { get; set; }
    public bool Mushrooms { get; set; }

    public void Bake()
    {
        Console.WriteLine($"Assando {Type} ({Size}) – queijo extra: {ExtraCheese}, cogumelos: {Mushrooms}.");
    }

    public void Serve()
    {
        Console.WriteLine("Pizza servida!");
    }
}