using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace socialarts.club.IEnumerableExtensions
{
    public static class IEnumerableExtensions
    {
        // TODO (Shaun) Consider using Responsive Extensions
        public static async Task<IEnumerable<T>> WhereAsync<T>(this IEnumerable<T> source, Func<T, Task<bool>> func)
        {
            var result = new List<T>();
            foreach(var item in source) {
                if(await func(item)) 
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(
            this Task<IEnumerable<TSource>> source, Func<TSource, TResult> func) 
        {
            var result = await source;
            return result.Select(func);
        }
    }
}