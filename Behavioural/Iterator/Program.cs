using System;
using System.Collections.Generic;

namespace WithoutIteratorPattern
{
    // Book class
    class Book
    {
        public string Title { get; private set; }

        public Book(string title)
        {
            Title = title;
        }
    }

    // Concrete collection
    class BookCollection
    {
        private readonly List<Book> _books = new List<Book>();

        public int Count => _books.Count;

        public Book this[int index] => _books[index];

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BookCollection collection = new BookCollection();
            collection.AddBook(new Book("Design Patterns"));
            collection.AddBook(new Book("Clean Code"));
            collection.AddBook(new Book("Refactoring"));

            List<Book> books = collection.GetBooks();

            Console.WriteLine("Iterating over collection:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(books[i].Title);
            }
        }
    }
}
