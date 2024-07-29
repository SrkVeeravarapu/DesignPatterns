using System;
using System.Collections;
using System.Collections.Generic;

namespace IteratorPattern
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

    // Iterator interface
    interface IIterator<T>
    {
        T Current { get; }
        bool MoveNext();
        void Reset();
    }

    // Concrete iterator
    class BookIterator : IIterator<Book>
    {
        private readonly BookCollection _collection;
        private int _currentIndex = -1;

        public BookIterator(BookCollection collection)
        {
            _collection = collection;
        }

        public Book Current => _collection[_currentIndex];

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }

    // Collection interface
    interface IBookCollection
    {
        IIterator<Book> CreateIterator();
        int Count { get; }
        Book this[int index] { get; }
    }

    // Concrete collection
    class BookCollection : IBookCollection
    {
        private readonly List<Book> _books = new List<Book>();

        public int Count => _books.Count;

        public Book this[int index] => _books[index];

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public IIterator<Book> CreateIterator()
        {
            return new BookIterator(this);
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

            IIterator<Book> iterator = collection.CreateIterator();

            Console.WriteLine("Iterating over collection:");
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Title);
            }
        }
    }
}
