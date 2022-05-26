using Newtonsoft.Json;

namespace ReportingFramework.Common.Extentions
{
    public static class ObjectExtentions
    {
        public static T DeepClone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}