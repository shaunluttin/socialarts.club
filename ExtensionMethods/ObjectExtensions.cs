using System;
using Newtonsoft.Json;

namespace socialarts.club.ObjectExtensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj) 
            => JsonConvert.SerializeObject(obj, Formatting.Indented);

        public static void DumpJson(this object obj) 
            => Console.WriteLine(obj.ToJson());
    }
}