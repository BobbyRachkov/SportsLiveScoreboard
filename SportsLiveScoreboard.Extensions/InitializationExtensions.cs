using System;
using System.Collections.Generic;

namespace SportsLiveScoreboard.Extensions
{
    public static class InitializationExtensions
    {
        public static T Init<T>(this T obj) where T : class, new()
        {
            obj = new T();
            return obj;
        }

        public static Lazy<TInterface> InitLazy<TInterface, TImplementation>(this Lazy<TInterface> lazy,
            TImplementation obj)
            where TImplementation : TInterface
        {
            lazy = new Lazy<TInterface>(() => obj);
            return lazy;
        }

        public static Lazy<TInterface> InitLazy<TInterface, TImplementation>(this Lazy<TInterface> lazy)
            where TImplementation : TInterface
        {
            lazy = new Lazy<TInterface>();
            return lazy;
        }
    }
}