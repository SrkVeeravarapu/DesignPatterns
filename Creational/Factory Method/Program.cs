using System;

namespace FactoryMethodPattern
{
    // Product interface
    public interface IDocument
    {
        void Print();
    }

    // Concrete product classes
    public class WordDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing Word Document...");
        }
    }

    public class PDFDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Printing PDF Document...");
        }
    }

    // Creator class
    public abstract class DocumentCreator
    {
        // Factory Method
        public abstract IDocument CreateDocument();

        // Other methods
        public void PrintDocument()
        {
            IDocument document = CreateDocument();
            document.Print();
        }
    }

    // Concrete creators
    public class WordDocumentCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PDFDocumentCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new PDFDocument();
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            DocumentCreator creator;

            // Creating and printing a Word document
            creator = new WordDocumentCreator();
            creator.PrintDocument();

            // Creating and printing a PDF document
            creator = new PDFDocumentCreator();
            creator.PrintDocument();
        }
    }
}
