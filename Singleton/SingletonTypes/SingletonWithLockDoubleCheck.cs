using Microsoft.Extensions.Logging;

namespace Singleton.SingletonTypes
{
#nullable enable
    // Complex solution. 
    // May not be thread safe
    // Easy to get wrong
    public sealed class SingletonWithLockDoubleCheck
    {
        private static SingletonWithLockDoubleCheck? _instance;
        private static readonly object _lock = new object();

        private SingletonWithLockDoubleCheck()
        {
            // ILogger<BasicSingleton>Log("Constructor called.");
        }

        public static SingletonWithLockDoubleCheck Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            // ILogger<BasicSingleton>Log("Instance called.");
                            _instance ??= new SingletonWithLockDoubleCheck();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}