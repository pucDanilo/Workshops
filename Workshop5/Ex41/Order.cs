using System;

namespace Ex41;

public class Order
{
    public List<(string Name, decimal Price)> Items { get; set; }
    public decimal Total { get; set; }
}