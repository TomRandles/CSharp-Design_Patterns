using Microsoft.Extensions.Logging;
using System;

namespace Singleton.SingletonTypes
{
    // Full lazy 
    // Specify a type
    // Is thread safe
    // Is performant
    // No null checking required on _lazy.Value

    public sealed class NetLazyGenericTypeSingleton
    {
        private static readonly Lazy<NetLazyGenericTypeSingleton> _lazy =
            new Lazy<NetLazyGenericTypeSingleton>(() =>
                new NetLazyGenericTypeSingleton());

        public static NetLazyGenericTypeSingleton Instance
        {
            get
            {
                return _lazy.Value;
            }
        }
        private NetLazyGenericTypeSingleton()
        { }
    }
}