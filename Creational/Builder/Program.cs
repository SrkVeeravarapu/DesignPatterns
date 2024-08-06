using System;

namespace BuilderPattern
{
    // Product class with multiple features
    public class House
    {
        public string Foundation { get; set; }
        public string Walls { get; set; }
        public string Roof { get; set; }
        public string Garage { get; set; }
        public string SwimmingPool { get; set; }
        public string Garden { get; set; }

        public override string ToString()
        {
            return $"House with {Foundation} foundation, {Walls} walls, {Roof} roof, " +
                   $"{Garage} garage, {SwimmingPool} swimming pool, and {Garden} garden.";
        }
    }

    // Builder interface with methods to build different parts of the product
    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildWalls();
        void BuildRoof();
        void BuildGarage();
        void BuildSwimmingPool();
        void BuildGarden();
        House GetResult();
    }

    // Concrete builder for a specific type of house
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new House();

        public void BuildFoundation() => _house.Foundation = "Concrete foundation";
        public void BuildWalls() => _house.Walls = "Brick walls";
        public void BuildRoof() => _house.Roof = "Tiled roof";
        public void BuildGarage() => _house.Garage = "Two-car garage";
        public void BuildSwimmingPool() => _house.SwimmingPool = "Swimming pool";
        public void BuildGarden() => _house.Garden = "Beautiful garden";

        public House GetResult() => _house;
    }

    // Director class to manage the building process
    public class Director
    {
        private readonly IHouseBuilder _builder;

        public Director(IHouseBuilder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildFoundation();
            _builder.BuildWalls();
            _builder.BuildRoof();
            _builder.BuildGarage();
            _builder.BuildSwimmingPool();
            _builder.BuildGarden();
        }
    }

    // Client code using the Builder pattern
    class Program
    {
        static void Main(string[] args)
        {
            IHouseBuilder builder = new ConcreteHouseBuilder();
            Director director = new Director(builder);

            director.Construct();

            House house = builder.GetResult();
            Console.WriteLine(house);
        }
    }
}
