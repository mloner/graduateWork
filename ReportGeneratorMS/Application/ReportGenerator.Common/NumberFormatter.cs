using System;
using System.Globalization;
using ReportingFramework.Dto;

namespace ReportingFramework.Common
{
    public class NumberFormatter : INumberFormatter
    {
        public string GroupSeparator { get; set; }
        public string DecimalSeparator { get; set; }
        public int Decimals { get; set; }
        public string NullValue { get; set; }
        
        public string Format(double? d, int? decimals=null, string groupSeparator=null, string decimalSeparator=null)
        {
            if ((d == null || !double.IsNormal(d.Value) && d != 0))
            {
                return NullValue ?? "...";
            }
            else
            {
                return Format(
                    d.Value,
                    decimals: decimals ?? Decimals,
                    groupSeparator: groupSeparator ?? GroupSeparator,
                    decimalSeparator: decimalSeparator ?? DecimalSeparator);
            }
        }
        public string Format(double d, int? decimals=null, string groupSeparator=null, string decimalSeparator=null)
        {
            if (!double.IsNormal(d) && d != 0)
                return NullValue ?? "...";
            decimal dec = Math.Round(Convert.ToDecimal(d), decimals ?? Decimals, MidpointRounding.AwayFromZero);
            var f = new NumberFormatInfo
            {
                NumberGroupSeparator = groupSeparator ?? GroupSeparator,
                NumberDecimalSeparator = decimalSeparator ?? DecimalSeparator,
                NumberDecimalDigits = decimals ?? Decimals
            };
            var result = dec.ToString("N", f);
            
            //cut zeros after decimal separator
            var decSep = decimalSeparator ?? DecimalSeparator;
            if (result.Contains(decSep))
            {
                result = result.TrimEnd('0');
                if (result.EndsWith(decSep))
                {
                    result = result.Substring(0, result.Length - decSep.Length);
                }
            }
            
            return result;
        }
        public string Format(int? i, int? decimals=null)
        {
            return Format((i * 1.0) as double?, decimals: decimals ?? Decimals);
        }
        public string Format(int i, int? decimals=null)
        {
            return Format((i * 1.0),
                decimals: decimals ?? Decimals);
        }
        public string Format(string s, int? decimals=null, string groupSeparator=null, string decimalSeparator=null)
        {
            if (s == "")
            {
                return Format((double?)null,
                    decimals: decimals ?? Decimals,
                    groupSeparator: groupSeparator ?? GroupSeparator,
                    decimalSeparator: decimalSeparator ?? DecimalSeparator);
            }
            
            //if this is not a number (some string), then return this string
            if (!double.TryParse(s,NumberStyles.Float, CultureInfo.InvariantCulture, out var res))
            {
                return s;
            }
            else
            {
                return Format((double.Parse(s, NumberStyles.Float, CultureInfo.InvariantCulture) * 1.0) as double?,
                    decimals: decimals ?? Decimals,
                    groupSeparator: groupSeparator ?? GroupSeparator,
                    decimalSeparator: decimalSeparator ?? DecimalSeparator);
            }
        }
    } 
}