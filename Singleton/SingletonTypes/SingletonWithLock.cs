using Microsoft.Extensions.Logging;

namespace Singleton.SingletonTypes
{    
#nullable enable
    // Add thread safety with lock
    public sealed class SingletonWithLock
    {
        private static SingletonWithLock? _instance;

        private static readonly object _lock = new object();

        private SingletonWithLock()
        {
            // ILogger<BasicSingleton>Log("Constructor called.");
        }

        public static SingletonWithLock Instance
        {
            get
            {
                lock (_lock)
                {
                    // ILogger<BasicSingleton>Log("Instance called.");
                    return _instance ??= new SingletonWithLock();
                }
            }
        }
    }
}
