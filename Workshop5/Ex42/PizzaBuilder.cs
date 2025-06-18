namespace Ex42
{
    public class PizzaBuilder
    {
        private readonly Pizza _pizza;

        public PizzaBuilder(string type)
        {
            _pizza = new Pizza { Type = type };
        }

        public PizzaBuilder SetSize(string size)
        {
            _pizza.Size = size;
            return this;
        }

        public PizzaBuilder AddExtraCheese(bool cheese)
        {
            _pizza.ExtraCheese = cheese;
            return this;
        }

        public PizzaBuilder AddMushrooms(bool mushrooms)
        {
            _pizza.Mushrooms = mushrooms;
            return this;
        }

        public Pizza Build()
        {
            return _pizza;
        }
    }
}