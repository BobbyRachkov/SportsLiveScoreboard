using System;
using Newtonsoft.Json;

namespace SportsLiveScoreboard.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }

        public static void Clone<T>(this T source, out T result)
        {
            if (Object.ReferenceEquals(source, null))
            {
                result = default(T);
            }

            result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }

        public static bool IsNull(this object obj)
        {
            return obj is null;
        }
        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }
    }
}