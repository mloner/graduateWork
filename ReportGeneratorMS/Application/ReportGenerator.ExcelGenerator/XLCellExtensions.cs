using System.Collections.Generic;
using ClosedXML.Excel;

namespace ExcelGenerator
{
    public static class XLCellExtensions
    {
        public static IXLCell AddCustomConditionalFormats(this IXLCell cell, Dictionary<string, XLColor> formats)
        {
            foreach (var formatElem in formats)
            {
                cell.AddConditionalFormat().WhenEquals(formatElem.Key).Fill.SetBackgroundColor(formatElem.Value);
            }
            

            return cell;
        }
    }
}