using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace ReportingFramework.Common.Extentions
{
    public static class PdfSharpExtensions
    {
        public static void Add(this Cell cell, List<Paragraph> paragraphs)
        {
            foreach (var paragraph in paragraphs)
            {
                cell.Add(paragraph);
            }
        }
    }
}