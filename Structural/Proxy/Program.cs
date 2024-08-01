using System;

namespace ProxyMethodPattern
{
    // Subject Interface
    interface IVideo
    {
        void Play();
    }

    // Real Subject
    class Video : IVideo
    {
        private string _fileName;

        public Video(string fileName)
        {
            _fileName = fileName;
            LoadVideo();
        }

        private void LoadVideo()
        {
            // Simulate expensive operation of loading a video
            Console.WriteLine($"Loading video file {_fileName}...");
            System.Threading.Thread.Sleep(2000); // Simulate delay
        }

        public void Play()
        {
            Console.WriteLine($"Playing video {_fileName}...");
        }
    }

    // Proxy
    class VideoProxy : IVideo
    {
        private string _fileName;
        private Video _video;

        public VideoProxy(string fileName)
        {
            _fileName = fileName;
        }

        public void Play()
        {
            if (_video == null)
            {
                _video = new Video(_fileName);
            }
            _video.Play();
        }
    }

    // Client
    class VideoPlayer
    {
        public void PlayVideo(string fileName)
        {
            IVideo video = new VideoProxy(fileName);
            video.Play();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VideoPlayer player = new VideoPlayer();
            player.PlayVideo("sample.mp4");
        }
    }
}
