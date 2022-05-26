using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ReportingFramework.Common
{
    public static class ResHelper
    {
        private static string _commonResourceName;

        public static string CommonResourceName
        {
            get => _commonResourceName;
            set { _commonResourceName ??= value; }
        }

        public static string GetResVal(string resourceName, string key, CultureInfo cultureInfo, bool returnErrorOnFail = true)
        {
            string result;
            ResourceManager rm;
            string errorString = $"### {key}";
            try
            {
                rm = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());
                result = rm.GetString($"{key}", cultureInfo);
                if (result == null)
                {
                    if (returnErrorOnFail)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return key;
                    }
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine($"ResName: {resourceName}\n" +
                                  $"Key: {errorString}");
                return errorString;
            }
            

            return result;
        }

        public static string GetResVal(
            List<string> resourceNames,
            string key,
            CultureInfo cultureInfo)
        {
            string result;
            ResourceManager rm;
            string errorString = $"### {key}";
            foreach (var resourceName in resourceNames)
            {
                try
                {
                    rm = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());
                    result = rm.GetString(key, cultureInfo);
                    if (result == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return result;
                    }
                }
                catch (Exception e2)
                {
                    Console.WriteLine($"ResName: {resourceName}\n" +
                                      $"Key: {errorString}\n===\n");
                }
            }

            return errorString;

        }
        
    }
}