using System;
using Newtonsoft.Json;

namespace ReportingFramework.Common.Extentions
{
    public static class CastExtension
    {
        public static T CastAs<T>(this object value)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value, settings), settings);
        }
        
        public static int? ToNullableInt(this string s)
        {
            if (s == null)
            {
                return null;
            }
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        public static double ToDouble(this string theValue)
        {
            double retNum;
            var result = double.TryParse(theValue, out retNum);
            return result ? retNum : 0;
        }
        
        public static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }
}