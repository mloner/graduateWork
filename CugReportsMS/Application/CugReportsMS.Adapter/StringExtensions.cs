using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportingFramework
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string ReplaceVals(this string input, Dictionary<string, string> dict)
        {
            foreach (var keyValuePair in dict)
            {
               input =  input.Replace($"[{keyValuePair.Key}]", keyValuePair.Value);
            }

            return input;
        }
    }
}