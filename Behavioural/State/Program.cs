using System;

namespace StatePattern
{
    // Context class
    class Document
    {
        private IDocumentState _state;

        public Document()
        {
            _state = new DraftState();
        }

        public void SetState(IDocumentState state)
        {
            _state = state;
        }

        public void Publish()
        {
            _state.Publish(this);
        }

        public void Edit()
        {
            _state.Edit(this);
        }
    }

    // State interface
    interface IDocumentState
    {
        void Publish(Document document);
        void Edit(Document document);
    }

    // Concrete state for Draft
    class DraftState : IDocumentState
    {
        public void Publish(Document document)
        {
            Console.WriteLine("Document is in Draft state and is being sent for moderation.");
            document.SetState(new ModerationState());
        }

        public void Edit(Document document)
        {
            Console.WriteLine("Document is in Draft state and is being edited.");
        }
    }

    // Concrete state for Moderation
    class ModerationState : IDocumentState
    {
        public void Publish(Document document)
        {
            Console.WriteLine("Document is in Moderation state and is being published.");
            document.SetState(new PublishedState());
        }

        public void Edit(Document document)
        {
            Console.WriteLine("Document is in Moderation state and cannot be edited.");
        }
    }

    // Concrete state for Published
    class PublishedState : IDocumentState
    {
        public void Publish(Document document)
        {
            Console.WriteLine("Document is already published.");
        }

        public void Edit(Document document)
        {
            Console.WriteLine("Document is published and cannot be edited.");
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
