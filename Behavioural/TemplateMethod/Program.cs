using System;

namespace TemplateMethodPattern
{
    // Abstract base class
    abstract class DataProcessor
    {
        // Template method
        public void ProcessData()
        {
            ReadData();
            Process();
            WriteData();
        }

        // Abstract methods to be overridden by subclasses
        protected abstract void ReadData();
        protected abstract void Process();
        protected abstract void WriteData();
    }

    // Concrete class for CSV data processing
    class CsvDataProcessor : DataProcessor
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading CSV data...");
        }

        protected override void Process()
        {
            Console.WriteLine("Processing CSV data...");
        }

        protected override void WriteData()
        {
            Console.WriteLine("Writing CSV data...");
        }
    }

    // Concrete class for XML data processing
    class XmlDataProcessor : DataProcessor
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading XML data...");
        }

        protected override void Process()
        {
            Console.WriteLine("Processing XML data...");
        }

        protected override void WriteData()
        {
            Console.WriteLine("Writing XML data...");
        }
    }

    // Concrete class for JSON data processing
    class JsonDataProcessor : DataProcessor
    {
        protected override void ReadData()
        {
            Console.WriteLine("Reading JSON data...");
        }

        protected override void Process()
        {
            Console.WriteLine("Processing JSON data...");
        }

        protected override void WriteData()
        {
            Console.WriteLine("Writing JSON data...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataProcessor csvProcessor = new CsvDataProcessor();
            csvProcessor.ProcessData();

            DataProcessor xmlProcessor = new XmlDataProcessor();
            xmlProcessor.ProcessData();

            DataProcessor jsonProcessor = new JsonDataProcessor();
            jsonProcessor.ProcessData();
        }
    }
}
