using System;
using System.Collections.Generic;

namespace CommandPattern
{
    // Command interface
    interface ICommand
    {
        void Execute();
        void Unexecute();
    }

    // Receiver class
    class TextEditor
    {
        public string Text { get; private set; } = "";

        public void Write(string text)
        {
            Text += text;
            Console.WriteLine($"Text after write: {Text}");
        }

        public void UndoWrite(string text)
        {
            if (Text.EndsWith(text))
            {
                Text = Text.Substring(0, Text.Length - text.Length);
                Console.WriteLine($"Text after undo: {Text}");
            }
        }
    }

    // Concrete command for writing text
    class WriteCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly string _text;

        public WriteCommand(TextEditor editor, string text)
        {
            _editor = editor;
            _text = text;
        }

        public void Execute()
        {
            _editor.Write(_text);
        }

        public void Unexecute()
        {
            _editor.UndoWrite(_text);
        }
    }

    // Invoker class
    class TextEditorInvoker
    {
        private readonly Stack<ICommand> _commands = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commands.Push(command);
        }

        public void Undo()
        {
            if (_commands.Count > 0)
            {
                ICommand command = _commands.Pop();
                command.Unexecute();
            }
            else
            {
                Console.WriteLine("No commands to undo.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            TextEditorInvoker invoker = new TextEditorInvoker();

            ICommand writeHello = new WriteCommand(editor, "Hello ");
            ICommand writeWorld = new WriteCommand(editor, "World!");

            invoker.ExecuteCommand(writeHello);
            invoker.ExecuteCommand(writeWorld);

            invoker.Undo(); // Should undo "World!"
            invoker.Undo(); // Should undo "Hello "
            invoker.Undo(); // No commands to undo
        }
    }
}
