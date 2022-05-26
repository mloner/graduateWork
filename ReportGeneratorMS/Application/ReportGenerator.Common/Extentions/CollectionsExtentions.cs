using System.Collections.Generic;

namespace ReportingFramework.Common.Extentions
{
    public class CollectionsExtentions
    {
        public static IEnumerable<T> Reverse<T>(IEnumerable<T> input)
        {
            return new Stack<T>(input);
        }
    }
}