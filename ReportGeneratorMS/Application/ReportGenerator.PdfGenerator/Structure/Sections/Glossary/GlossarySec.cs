using System.Collections.Generic;
using MigraDoc.DocumentObjectModel;
using ReportingFramework.Common;

namespace ReportingFramework.Structure.Sections.Glossary
{
    public abstract class GlossarySec : PdfReportSection
    {
        
        public override void Generate()
        {
            // _name = $"{SubsectionTypeEnum.Table.Desc()}_Glossary";
            // var glossaryItemList = ((ReportTable)GetReportObj(_sectionData, _name))
            //     .TableData;
            //
            // AddGlossary(glossaryItemList);
        }
        
        protected void AddGlossary(List<Dictionary<string, string>> items)
        {
            foreach (var item in items)
            {
                AddGlossaryItem(item);
            }
        }

        protected void AddGlossaryItem(Dictionary<string, string> item)
        {
            var prefix = "Glossary";
            
            Par = CreateParagraph("");
            Par.AddFormattedText(ResHelper.GetResVal(SectionResName, $"{prefix}_{item["Name"]}", _ci), TextFormat.Bold);
            Par.AddText(" — ");
            Par.AddText(ResHelper.GetResVal(SectionResName, $"{prefix}_{item["Name"]}_Desc", _ci));
            
            PdfSection.Add(Par.Clone());
            
            AddSpace(0.4);
        }
    }
}