using System;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using ReportingFramework.Common.Template.SectionTypeTemplate;

namespace ReportingFramework.Structure.SectionElements.FooterSetter
{
    public class FooterSetterJabbaStyle : FooterSetter
    {
        public override void Set(Section section, Footer footer, ParagraphFormat footerStyle)
        {
            Table footerTable;
            Paragraph par;
            Column col;
            Row row;
            Image img;
            
            double sectionWidth = section.PageSetup.PageWidth - section.PageSetup.LeftMargin
                                                              - section.PageSetup.RightMargin;
            double columnWidth;
            
            columnWidth = sectionWidth;
            footerTable = new Table();
            col = footerTable.AddColumn();
            col.Width = columnWidth;
            row = footerTable.AddRow();
            par = new Paragraph();
            par.Format = footerStyle.Clone();
            
            par.AddText("p.");
            par.AddPageField();
            par.AddText($" {footer.Copyright} {DateTime.Now.Year}");
            
            row.Cells[0].Add(par);
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            section.Footers.Primary.Add(footerTable.Clone());
        }
    }
}