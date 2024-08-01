using System;

namespace FacadePattern
{
    // Subsystems
    class Amplifier
    {
        public void On() => Console.WriteLine("Amplifier on");
        public void SetVolume(int level) => Console.WriteLine($"Setting volume to {level}");
    }

    class DVDPlayer
    {
        public void On() => Console.WriteLine("DVD Player on");
        public void Play(string movie) => Console.WriteLine($"Playing movie {movie}");
    }

    class Projector
    {
        public void On() => Console.WriteLine("Projector on");
        public void SetInput(DVDPlayer dvd) => Console.WriteLine("Projector set input to DVD Player");
    }

    class Lights
    {
        public void Dim(int level) => Console.WriteLine($"Lights dimmed to {level}%");
    }

    // Facade
    class HomeTheaterFacade
    {
        private Amplifier _amp;
        private DVDPlayer _dvd;
        private Projector _projector;
        private Lights _lights;

        public HomeTheaterFacade(Amplifier amp, DVDPlayer dvd, Projector projector, Lights lights)
        {
            _amp = amp;
            _dvd = dvd;
            _projector = projector;
            _lights = lights;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            _lights.Dim(30);
            _projector.On();
            _projector.SetInput(_dvd);
            _amp.On();
            _amp.SetVolume(5);
            _dvd.On();
            _dvd.Play(movie);
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            _lights.Dim(100);
            _projector.On();
            _amp.On();
            _dvd.On();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            // Using the facade
            Amplifier amp = new Amplifier();
            DVDPlayer dvd = new DVDPlayer();
            Projector projector = new Projector();
            Lights lights = new Lights();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(amp, dvd, projector, lights);
            homeTheater.WatchMovie("Inception");
        }
    }
}
