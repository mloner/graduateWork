namespace ReportingFramework.Structure.Sections.Advice.BatSim.Default.BE
{
    public class AdviceBatSimDefaultBESecV0_9 : AdviceBatSimDefaultSec
    {
        // public override void AddDesc1Case()
        // {
        //     // var desc1Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_1";
        //     // var desc1Par = (ReportParagraph)GetReportObj(_sectionData, desc1Name);
        //     // desc1Par.Text = ResHelper.GetResVal(_sectionResName, desc1Name, _ci)
        //     //     .ReplaceVals(new Dictionary<string, string>()
        //     //     {
        //     //         { "CompanyName", _template.GlobalSettings.CompanyName },
        //     //     });
        //     // AddParagraph(desc1Par);
        // }
        //
        // public override void AddDesc1NoCase()
        // {
        //     AddDesc1Case();
        // }
        //
        // public override void AddDesc2Case()
        // {
        //     // var desc2Name = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc_2";
        //     // var desc2Obj = GetReportObj(_sectionData, desc2Name);
        //     // var desc2Childs = desc2Obj.ChildObjects;
        //     //
        //     // #region Title
        //     //
        //     // var desc2Par = (ReportParagraph)GetReportObj(_sectionData, desc2Name);
        //     // desc2Par.Title = ResHelper.GetResVal(_sectionResName, $"{desc2Name}_Title", _ci);
        //     // AddParagraph(desc2Par.Title
        //     //     .ReplaceVals(new Dictionary<string, string>()
        //     //     {
        //     //         {"CompanyName", _template.GlobalSettings.CompanyName },
        //     //     }), StyleEnum.H1);
        //     //
        //     // #endregion
        //     //
        //     // #region Content
        //     //
        //     // #region 1
        //     //
        //     // var desc2_1Name = $"{desc2Name}_1";
        //     // var desc2_1Par = (ReportParagraph)desc2Childs[0];
        //     // AddParagraph(
        //     //     ResHelper.GetResVal(_sectionResName, desc2_1Name, _resParams.CultureInfo)
        //     //         .ReplaceVals(new Dictionary<string, string>()
        //     //         {
        //     //             {"CompanyName", _template.GlobalSettings.CompanyName},
        //     //         })
        //     // );
        //     //
        //     // #endregion
        //     //
        //     // AddSpace(0.3);
        //     //
        //     // #region 2
        //     //
        //     // var desc2_2Name = $"{desc2Name}_2";
        //     // var desc2_2Par = (ReportParagraph)desc2Childs[1];
        //     // AddParagraph(
        //     //     ResHelper.GetResVal(_sectionResName, desc2_2Name, _resParams.CultureInfo)
        //     //         .ReplaceVals(new Dictionary<string, string>()
        //     //         {
        //     //             {"CompanyName", _template.GlobalSettings.CompanyName},
        //     //         })
        //     // );
        //     //
        //     // #endregion
        //     //
        //     // AddSpace(0.3);
        //     //
        //     // #region 3
        //     //
        //     // var desc2_3Name = $"{desc2Name}_3";
        //     // var desc2_3Par = (ReportParagraph)desc2Childs[2];
        //     // AddParagraph(
        //     //     ResHelper.GetResVal(_sectionResName, desc2_3Name, _resParams.CultureInfo)
        //     //         .ReplaceVals(new Dictionary<string, string>()
        //     //         {
        //     //             {"CompanyName", _template.GlobalSettings.CompanyName},
        //     //         })
        //     // );
        //     //
        //     // #endregion
        //     //
        //     // #endregion
        // }
        //
        // public override void AddDesc2NoCase()
        // {
        //     AddDesc2Case();
        // }
        //
        // public override void AddComparisonTableSavingsBlockContent(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     //total savings
        //     Par = CreateParagraph($"{ResHelper.GetResVal(_sectionResName, $"Total", _ci)}: € {_numFmtr.Format(tableRow["SavingsTotal"])}", styleName);
        //     cell.Add(Par.Clone());
        //     
        //     //savings per year
        //     Par = CreateParagraph($"{ResHelper.GetResVal(_sectionResName, $"PerYear", _ci)}: € {_numFmtr.Format(tableRow["SavingsPerYear"])}", styleName);
        //     cell.Add(Par.Clone());
        //     
        //     cell.VerticalAlignment = VerticalAlignment.Top;
        // }
        //
        // public override void AddComparisonTablePaybackPeriodBlockContentNoCase(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //     
        // }
        //
        // public override void AddComparisonTableRerurnOfInvestmentBlockContentNoCase(Dictionary<string, string> tableRow, Cell cell, string styleName)
        // {
        //    
        // }
        //
        // public override void InitSectionModel(string sectionModelJson)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        // public override void GenerateContent()
        // {
        //     throw new System.NotImplementedException();
        // }
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}