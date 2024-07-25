using System;
using System.Collections.Generic;

namespace MediatorPattern
{
    // Mediator interface
    interface IChatRoom
    {
        void SendMessage(string message, User user);
        void AddUser(User user);
    }

    // Concrete mediator
    class ChatRoom : IChatRoom
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user)
        {
            _users.Add(user);
            user.SetChatRoom(this);
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                // Message should not be sent to the sender
                if (user != sender)
                {
                    user.ReceiveMessage(message);
                }
            }
        }
    }

    // Colleague class
    abstract class User
    {
        protected IChatRoom _chatRoom;
        public string Name { get; private set; }

        protected User(string name)
        {
            Name = name;
        }

        public void SetChatRoom(IChatRoom chatRoom)
        {
            _chatRoom = chatRoom;
        }

        public abstract void ReceiveMessage(string message);

        public void SendMessage(string message)
        {
            _chatRoom.SendMessage(message, this);
        }
    }

    // Concrete colleague
    class ConcreteUser : User
    {
        public ConcreteUser(string name) : base(name) { }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} received: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IChatRoom chatRoom = new ChatRoom();

            User alice = new ConcreteUser("Alice");
            User bob = new ConcreteUser("Bob");
            User charlie = new ConcreteUser("Charlie");

            chatRoom.AddUser(alice);
            chatRoom.AddUser(bob);
            chatRoom.AddUser(charlie);

            alice.SendMessage("Hello everyone!");
            bob.SendMessage("Hi Alice!");
        }
    }
}
