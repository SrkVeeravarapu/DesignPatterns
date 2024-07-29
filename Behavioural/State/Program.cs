using System;

namespace WithoutStatePattern
{
    // Context class
    class Document
    {
        public string State { get; private set; }

        public Document()
        {
            State = "Draft";
        }

        public void Publish()
        {
            if (State == "Draft")
            {
                Console.WriteLine("Document is in Draft state and is being sent for moderation.");
                State = "Moderation";
            }
            else if (State == "Moderation")
            {
                Console.WriteLine("Document is in Moderation state and is being published.");
                State = "Published";
            }
            else if (State == "Published")
            {
                Console.WriteLine("Document is already published.");
            }
        }

        public void Edit()
        {
            if (State == "Draft")
            {
                Console.WriteLine("Document is in Draft state and is being edited.");
            }
            else if (State == "Moderation")
            {
                Console.WriteLine("Document is in Moderation state and cannot be edited.");
            }
            else if (State == "Published")
            {
                Console.WriteLine("Document is published and cannot be edited.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            document.Edit();
            document.Publish();

            document.Edit();
            document.Publish();

            document.Publish();
        }
    }
}
