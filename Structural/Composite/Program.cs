using System;
using System.Collections.Generic;

namespace CompositePattern
{
    // Component
    interface IFileSystemComponent
    {
        string Name { get; }
        void Display();
    }

    // Leaf
    class File : IFileSystemComponent
    {
        public string Name { get; }

        public File(string name)
        {
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine(Name);
        }
    }

    // Composite
    class Directory : IFileSystemComponent
    {
        public string Name { get; }
        private List<IFileSystemComponent> components = new List<IFileSystemComponent>();

        public Directory(string name)
        {
            Name = name;
        }

        public void Add(IFileSystemComponent component)
        {
            components.Add(component);
        }

        public void Display()
        {
            Console.WriteLine(Name);
            foreach (var component in components)
            {
                component.Display();
            }
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IFileSystemComponent file1 = new File("File1.txt");
            IFileSystemComponent file2 = new File("File2.txt");

            Directory root = new Directory("Root");
            Directory subDir = new Directory("SubDir");

            root.Add(file1);
            root.Add(subDir);
            subDir.Add(file2);

            root.Display();
        }
    }
}
