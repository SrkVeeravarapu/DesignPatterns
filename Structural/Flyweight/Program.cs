using System;
using System.Collections.Generic;

namespace FlyweightMethodPattern
{
    // Flyweight Interface
    interface ICircle
    {
        void Draw(int x, int y);
    }

    // Concrete Flyweight
    class Circle : ICircle
    {
        private string _color;

        public Circle(string color)
        {
            _color = color;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing Circle [Color: {_color}, X: {x}, Y: {y}]");
        }
    }

    // Flyweight Factory
    class CircleFactory
    {
        private static Dictionary<string, Circle> _circleMap = new Dictionary<string, Circle>();

        public static ICircle GetCircle(string color)
        {
            if (!_circleMap.ContainsKey(color))
            {
                _circleMap[color] = new Circle(color);
                Console.WriteLine($"Creating circle of color : {color}");
            }
            return _circleMap[color];
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            // Creating 1,000 circles with varying positions but only 5 colors
            string[] colors = { "Red", "Green", "Blue", "Yellow", "Black" };
            Random random = new Random();

            for (int i = 0; i < 1000; i++)
            {
                string color = colors[random.Next(colors.Length)];
                int x = random.Next(100);
                int y = random.Next(100);

                ICircle circle = CircleFactory.GetCircle(color);
                circle.Draw(x, y);
            }
        }
    }
}
