using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    // Observer interface
    interface IObserver
    {
        void Update(string stockSymbol, float stockPrice);
    }

    // Concrete observer
    class Investor : IObserver
    {
        public string Name { get; private set; }

        public Investor(string name)
        {
            Name = name;
        }

        public void Update(string stockSymbol, float stockPrice)
        {
            Console.WriteLine($"Notified {Name} of {stockSymbol}'s change to {stockPrice}");
        }
    }

    // Subject interface
    interface IStock
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    // Concrete subject
    class Stock : IStock
    {
        private List<IObserver> _observers;
        private string _symbol;
        private float _price;

        public Stock(string symbol, float price)
        {
            _observers = new List<IObserver>();
            _symbol = symbol;
            _price = price;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_symbol, _price);
            }
        }

        public void SetPrice(float price)
        {
            _price = price;
            NotifyObservers();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock appleStock = new Stock("AAPL", 150.00f);

            IObserver investor1 = new Investor("John Doe");
            IObserver investor2 = new Investor("Jane Smith");

            appleStock.RegisterObserver(investor1);
            appleStock.RegisterObserver(investor2);

            appleStock.SetPrice(155.00f);
            appleStock.SetPrice(160.00f);

            appleStock.RemoveObserver(investor1);

            appleStock.SetPrice(165.00f);
        }
    }
}
