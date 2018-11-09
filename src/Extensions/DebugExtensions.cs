namespace socialarts.club.ViewComponents.Extensions
{
    public static class DebugExtensions
    {
        public static T Dump<T>(this T obj)
        {
            var output = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("--------------");
            System.Console.WriteLine("--------------");
            System.Console.WriteLine(output);
            return obj;
        }
    }
}