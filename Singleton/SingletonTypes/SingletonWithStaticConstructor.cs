using Microsoft.Extensions.Logging;

namespace Singleton.SingletonTypes
{
    // Any reading of static field will initialise the singleton
    // Not ideal lazy loading
    public sealed class SingletonWithStaticConstructor
    {
        public static readonly string GREETING = "Hi";

        private static readonly SingletonWithStaticConstructor _instance
            = new SingletonWithStaticConstructor();

        static SingletonWithStaticConstructor()
        {
            // ILogger<BasicSingleton>Log("Constructor called.");
        }

        public static SingletonWithStaticConstructor Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}