using Singleton.SingletonTypes;
using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Details of different Singleton type instances");

            var singleton = BasicSingleton.Instance;
            Console.WriteLine("Basic singleton: " + singleton.GetType());

            var singleton2 = SingletonWithLock.Instance;
            Console.WriteLine("Singleton with lock: " + singleton2.GetType());

            var singleton3 = SingletonWithLockDoubleCheck.Instance;
            Console.WriteLine("Singleton with lock, double check: " + singleton3.GetType());

            var singleton4 = SingletonWithStaticConstructor.Instance;
            Console.WriteLine("Singleton with static constructor: " + singleton4.GetType());

            var singleton5 = SingletonWithNestedInstanceWrapperClass.Instance;
            Console.WriteLine("Singleton with nested instance wrapper class: " + singleton5.GetType());

            var singleton6 = NetLazyGenericTypeSingleton.Instance;
            Console.WriteLine("Singleton with nested instance wrapper class: " + singleton6.GetType());
        }
    }
}