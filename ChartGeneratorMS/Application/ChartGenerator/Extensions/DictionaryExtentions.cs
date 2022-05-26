using System.Collections.Generic;
using System.Collections.Specialized;

namespace ChartGenerator.Extensions
{
    public static class DictionaryExtentions
    {
        public static NameValueCollection ToNameValueCollection(this Dictionary<string, object> dict)
        {
            var nameValueCollection = new NameValueCollection();
            foreach(var kvp in dict)
            {
                nameValueCollection.Add(kvp.Key.ToString(), kvp.Value.ToString());
            }

            return nameValueCollection;
        }
    }
}