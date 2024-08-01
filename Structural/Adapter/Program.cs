using System;

namespace AdapterPattern
{
    // Legacy class that needs to be adapted
    class LegacyPrinter
    {
        public void PrintDocument(string document)
        {
            Console.WriteLine("Printing document using legacy printer: " + document);
        }
    }

    // New system's expected interface
    interface IPrinter
    {
        void Print(string document);
    }

    // Adapter class that adapts LegacyPrinter to the IPrinter interface
    class PrinterAdapter : IPrinter
    {
        private readonly LegacyPrinter _legacyPrinter;

        public PrinterAdapter(LegacyPrinter legacyPrinter)
        {
            _legacyPrinter = legacyPrinter;
        }

        public void Print(string document)
        {
            _legacyPrinter.PrintDocument(document);
        }
    }

    // Client code that expects IPrinter
    class DocumentEditor
    {
        private readonly IPrinter _printer;

        public DocumentEditor(IPrinter printer)
        {
            _printer = printer;
        }

        public void PrintDocument(string document)
        {
            _printer.Print(document);
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            LegacyPrinter legacyPrinter = new LegacyPrinter();
            IPrinter adapter = new PrinterAdapter(legacyPrinter);

            DocumentEditor editor = new DocumentEditor(adapter);
            editor.PrintDocument("Adapter Pattern Example Document");
        }
    }
}
