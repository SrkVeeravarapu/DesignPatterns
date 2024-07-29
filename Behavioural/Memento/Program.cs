using System;
using System.Collections.Generic;

namespace MementoPattern
{
    // Memento class
    class TextEditorMemento
    {
        public string Text { get; private set; }

        public TextEditorMemento(string text)
        {
            Text = text;
        }
    }

    // Originator class
    class TextEditor
    {
        public string Text { get; private set; }

        public void SetText(string text)
        {
            Text = text;
            Console.WriteLine($"Current Text: {Text}");
        }

        public TextEditorMemento Save()
        {
            return new TextEditorMemento(Text);
        }

        public void Restore(TextEditorMemento memento)
        {
            Text = memento.Text;
            Console.WriteLine($"Restored Text: {Text}");
        }
    }

    // Caretaker class
    class TextEditorHistory
    {
        private Stack<TextEditorMemento> _history = new Stack<TextEditorMemento>();

        public void SaveState(TextEditor editor)
        {
            _history.Push(editor.Save());
            Console.WriteLine("State saved.");
        }

        public void Undo(TextEditor editor)
        {
            if (_history.Count > 0)
            {
                TextEditorMemento memento = _history.Pop();
                editor.Restore(memento);
                Console.WriteLine("State restored.");
            }
            else
            {
                Console.WriteLine("No states to restore.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            TextEditorHistory history = new TextEditorHistory();

            editor.SetText("Version 1");
            history.SaveState(editor);

            editor.SetText("Version 2");
            history.SaveState(editor);

            editor.SetText("Version 3");

            history.Undo(editor); // Should restore to "Version 2"
            history.Undo(editor); // Should restore to "Version 1"
            history.Undo(editor); // No more states to restore
        }
    }
}
