using Microsoft.Extensions.Logging;

namespace Singleton.SingletonTypes
{

    
#nullable enable
    // Not recommended - not thread safe
    public sealed class BasicSingleton
    {
        private static BasicSingleton? _instance;

        private BasicSingleton()
        {
            // ILogger<BasicSingleton>Log("Constructor called.");
        }

        public static BasicSingleton Instance
        {
            get
            {
                // ILogger<BasicSingleton>Log("Instance called.");
                return _instance ??= new BasicSingleton();
            }
        }
    }
}
