using Microsoft.Extensions.Logging;

namespace Singleton.SingletonTypes
{

    // Full lazy 
    // Is thread safe
    // Is performant
    // Complicated
    public sealed class SingletonWithNestedInstanceWrapperClass
    {

        private SingletonWithNestedInstanceWrapperClass()
        {
            // ILogger<BasicSingleton>Log("Constructor called.");
        }


        public static SingletonWithNestedInstanceWrapperClass Instance
        {
            get
            {
                return Nested.Instance;
            }
        }

        private class Nested
        {
            static Nested() { }

            internal static readonly SingletonWithNestedInstanceWrapperClass
                Instance = new SingletonWithNestedInstanceWrapperClass();
        }
    }
}