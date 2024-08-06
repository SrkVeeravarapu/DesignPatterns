using System;

namespace PrototypePattern
{
    // Prototype interface with Clone method
    public interface IShape
    {
        IShape Clone();
        void Draw();
    }

    // Concrete class implementing the prototype interface
    public class Circle : IShape
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
            Console.WriteLine("Creating a new Circle with radius " + Radius);
        }

        // Clone method creates a copy of the object
        public IShape Clone()
        {
            return new Circle(Radius);
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }

    // Another concrete class implementing the prototype interface
    public class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
            Console.WriteLine("Creating a new Rectangle with width " + Width + " and height " + Height);
        }

        // Clone method creates a copy of the object
        public IShape Clone()
        {
            return new Rectangle(Width, Height);
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle with width {Width} and height {Height}");
        }
    }

    // Client code using the Prototype pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Original objects
            Circle originalCircle = new Circle(10);
            Rectangle originalRectangle = new Rectangle(5, 8);

            // Cloning the objects
            Circle clonedCircle = (Circle)originalCircle.Clone();
            Rectangle clonedRectangle = (Rectangle)originalRectangle.Clone();

            // Drawing the original and cloned objects
            originalCircle.Draw();
            clonedCircle.Draw();

            originalRectangle.Draw();
            clonedRectangle.Draw();
        }
    }
}
