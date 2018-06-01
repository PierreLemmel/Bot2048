using System;
using System.Collections.Generic;
using System.Text;

namespace Bot2048.Core
{
    public static class MoreLinq
    {
        public static TResult GetValueOrDefault<TKey, TResult>(this IReadOnlyDictionary<TKey, TResult> dictionary, TKey key)
        {
            return dictionary.GetValueOrDefault(key, default(TResult));
        }

        public static TResult GetValueOrDefault<TKey, TResult>(this IReadOnlyDictionary<TKey, TResult> dictionary, TKey key, TResult defaultValue)
        {
            Check.NotNull(dictionary, nameof(dictionary));
            return dictionary.TryGetValue(key, out TResult result) ? result : defaultValue;
        }
    }
}
