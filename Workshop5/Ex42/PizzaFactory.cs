namespace Ex42
{
    public static class PizzaFactory
    {
        public static PizzaBuilder Create(string type)
        {
            return new PizzaBuilder(type);
        }
    }
}
