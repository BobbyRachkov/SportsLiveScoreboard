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
    }
}