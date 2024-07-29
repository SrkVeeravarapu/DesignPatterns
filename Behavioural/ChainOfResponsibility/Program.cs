using System;

namespace ChainOfResponsibilityPattern
{
    // Request class
    class CustomerServiceRequest
    {
        public string RequestType { get; set; }

        public CustomerServiceRequest(string requestType)
        {
            RequestType = requestType;
        }
    }

    // Handler interface
    interface ICustomerServiceHandler
    {
        void HandleRequest(CustomerServiceRequest request);
        void SetNextHandler(ICustomerServiceHandler nextHandler);
    }

    // Concrete handler for Basic Support
    class BasicSupportHandler : ICustomerServiceHandler
    {
        private ICustomerServiceHandler _nextHandler;

        public void SetNextHandler(ICustomerServiceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(CustomerServiceRequest request)
        {
            if (request.RequestType == "Simple")
            {
                Console.WriteLine("Basic Support can handle simple requests.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No handler available for this request.");
            }
        }
    }

    // Concrete handler for Technical Support
    class TechnicalSupportHandler : ICustomerServiceHandler
    {
        private ICustomerServiceHandler _nextHandler;

        public void SetNextHandler(ICustomerServiceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(CustomerServiceRequest request)
        {
            if (request.RequestType == "Complex")
            {
                Console.WriteLine("Technical Support can handle complex requests.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No handler available for this request.");
            }
        }
    }

    // Concrete handler for Manager Support
    class ManagerSupportHandler : ICustomerServiceHandler
    {
        private ICustomerServiceHandler _nextHandler;

        public void SetNextHandler(ICustomerServiceHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void HandleRequest(CustomerServiceRequest request)
        {
            if (request.RequestType == "Escalated")
            {
                Console.WriteLine("Manager Support can handle escalated requests.");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("No handler available for this request.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create handlers
            ICustomerServiceHandler basicHandler = new BasicSupportHandler();
            ICustomerServiceHandler technicalHandler = new TechnicalSupportHandler();
            ICustomerServiceHandler managerHandler = new ManagerSupportHandler();

            // Set the chain of responsibility
            basicHandler.SetNextHandler(technicalHandler);
            technicalHandler.SetNextHandler(managerHandler);

            // Process requests
            CustomerServiceRequest request1 = new CustomerServiceRequest("Simple");
            basicHandler.HandleRequest(request1);

            CustomerServiceRequest request2 = new CustomerServiceRequest("Complex");
            basicHandler.HandleRequest(request2);

            CustomerServiceRequest request3 = new CustomerServiceRequest("Escalated");
            basicHandler.HandleRequest(request3);

            CustomerServiceRequest request4 = new CustomerServiceRequest("Unknown");
            basicHandler.HandleRequest(request4);
        }
    }
}
