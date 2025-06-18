using System;

namespace Ex41;

 public class ShoppingCart
{
    public List<(string Name, decimal Price)> Items { get; set;  } = new List<(string, decimal)>();

    public void AddItem(string name, decimal price)
    {
        Items.Add((name, price));
    }

    public decimal CalculateTotal()
    {
        // Aplica 10% de desconto se total > 2000
        var sum = Items.Sum(i => i.Price);
        if (sum > 2000m) sum *= 0.9m;
        return sum;
    }
}