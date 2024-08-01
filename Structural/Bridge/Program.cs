using System;

namespace BridgePattern
{
    // Implementor
    interface IDevice
    {
        void PowerOn();
        void PowerOff();
        void SetVolume(int volume);
    }

    // Concrete Implementors
    class TV : IDevice
    {
        public void PowerOn() => Console.WriteLine("TV is ON");
        public void PowerOff() => Console.WriteLine("TV is OFF");
        public void SetVolume(int volume) => Console.WriteLine($"TV volume set to {volume}");
    }

    class Radio : IDevice
    {
        public void PowerOn() => Console.WriteLine("Radio is ON");
        public void PowerOff() => Console.WriteLine("Radio is OFF");
        public void SetVolume(int volume) => Console.WriteLine($"Radio volume set to {volume}");
    }

    // Abstraction
    abstract class RemoteControl
    {
        protected IDevice device;

        public RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            Console.WriteLine("Toggling power...");
            // Some logic to toggle power
        }

        public void VolumeUp()
        {
            Console.WriteLine("Increasing volume...");
            // Some logic to increase volume
        }

        public void VolumeDown()
        {
            Console.WriteLine("Decreasing volume...");
            // Some logic to decrease volume
        }
    }

    // Refined Abstraction
    class BasicRemote : RemoteControl
    {
        public BasicRemote(IDevice device) : base(device) { }

        public void Power()
        {
            Console.WriteLine("Basic remote power button pressed");
            device.PowerOn();
        }
    }

    class AdvancedRemote : RemoteControl
    {
        public AdvancedRemote(IDevice device) : base(device) { }

        public void Mute()
        {
            Console.WriteLine("Advanced remote mute button pressed");
            device.SetVolume(0);
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            IDevice tv = new TV();
            RemoteControl basicRemote = new BasicRemote(tv);
            basicRemote.TogglePower();
            basicRemote.VolumeUp();

            IDevice radio = new Radio();
            RemoteControl advancedRemote = new AdvancedRemote(radio);
            advancedRemote.TogglePower();
            ((AdvancedRemote)advancedRemote).Mute();
        }
    }
}
