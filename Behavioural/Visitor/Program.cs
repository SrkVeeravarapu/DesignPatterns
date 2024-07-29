using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    // Visitor interface
    interface IVisitor
    {
        void Visit(TextElement textElement);
        void Visit(ImageElement imageElement);
        void Visit(TableElement tableElement);
    }

    // Concrete visitor for rendering elements
    class RenderVisitor : IVisitor
    {
        public void Visit(TextElement textElement)
        {
            Console.WriteLine($"Rendering text: {textElement.Text}");
        }

        public void Visit(ImageElement imageElement)
        {
            Console.WriteLine($"Rendering image: {imageElement.ImagePath}");
        }

        public void Visit(TableElement tableElement)
        {
            Console.WriteLine("Rendering table");
        }
    }

    // Concrete visitor for printing elements
    class PrintVisitor : IVisitor
    {
        public void Visit(TextElement textElement)
        {
            Console.WriteLine($"Printing text: {textElement.Text}");
        }

        public void Visit(ImageElement imageElement)
        {
            Console.WriteLine($"Printing image: {imageElement.ImagePath}");
        }

        public void Visit(TableElement tableElement)
        {
            Console.WriteLine("Printing table");
        }
    }

    // Element interface
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Concrete element for text
    class TextElement : IElement
    {
        public string Text { get; set; }

        public TextElement(string text)
        {
            Text = text;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete element for image
    class ImageElement : IElement
    {
        public string ImagePath { get; set; }

        public ImageElement(string imagePath)
        {
            ImagePath = imagePath;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete element for table
    class TableElement : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IElement> elements = new List<IElement>
            {
                new TextElement("Hello, world!"),
                new ImageElement("/path/to/image.jpg"),
                new TableElement()
            };

            IVisitor renderVisitor = new RenderVisitor();
            IVisitor printVisitor = new PrintVisitor();

            Console.WriteLine("Rendering elements:");
            foreach (var element in elements)
            {
                element.Accept(renderVisitor);
            }

            Console.WriteLine("\nPrinting elements:");
            foreach (var element in elements)
            {
                element.Accept(printVisitor);
            }
        }
    }
}
