using System;

namespace SingletonPattern
{
    public sealed class ConfigurationManager
    {
        // Private static field to hold the single instance of the class
        private static readonly ConfigurationManager instance = new ConfigurationManager();

        // Private constructor to prevent instantiation from outside
        private ConfigurationManager()
        {
            // Initialize configuration settings
            Console.WriteLine("Initializing Configuration Manager");
        }

        // Public static method to provide global access to the instance
        public static ConfigurationManager Instance
        {
            get
            {
                return instance;
            }
        }

        // Method to get a configuration setting
        public string GetSetting(string key)
        {
            // Retrieve the setting from a configuration source (e.g., file, database)
            // For demonstration, return a dummy value
            return "Value of " + key;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager config = ConfigurationManager.Instance;
            string setting1 = config.GetSetting("SomeSetting");
            Console.WriteLine(setting1);

            string setting2 = config.GetSetting("AnotherSetting");
            Console.WriteLine(setting2);

            // Both setting1 and setting2 are retrieved from the same instance
        }
    }
}
