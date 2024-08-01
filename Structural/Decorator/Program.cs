using System;

namespace DecoratorPattern
{
    // Component
    abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    // Concrete Component
    class Espresso : Beverage
    {
        public override string GetDescription() => "Espresso";
        public override double GetCost() => 1.99;
    }

    class Latte : Beverage
    {
        public override string GetDescription() => "Latte";
        public override double GetCost() => 2.99;
    }

    // Decorator
    abstract class BeverageDecorator : Beverage
    {
        protected Beverage _beverage;

        public BeverageDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }
    }

    // Concrete Decorators
    class Milk : BeverageDecorator
    {
        public Milk(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Milk";
        public override double GetCost() => _beverage.GetCost() + 0.50;
    }

    class Sugar : BeverageDecorator
    {
        public Sugar(Beverage beverage) : base(beverage) { }

        public override string GetDescription() => _beverage.GetDescription() + ", Sugar";
        public override double GetCost() => _beverage.GetCost() + 0.20;
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            Console.WriteLine($"{beverage.GetDescription()} costs {beverage.GetCost()}");

            beverage = new Milk(beverage);
            Console.WriteLine($"{beverage.GetDescription()} costs {beverage.GetCost()}");

            beverage = new Sugar(beverage);
            Console.WriteLine($"{beverage.GetDescription()} costs {beverage.GetCost()}");
        }
    }
}
