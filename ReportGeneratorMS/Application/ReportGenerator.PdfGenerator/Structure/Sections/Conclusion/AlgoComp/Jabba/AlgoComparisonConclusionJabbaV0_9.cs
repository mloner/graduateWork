﻿namespace ReportingFramework.Structure.Sections.Conclusion.AlgoComp.Jabba
{
    public class AlgoComparisonConclusionJabbaV0_9 : PdfReportSection
    {
        public override void InitSectionModel(string sectionModelJson)
        {
            throw new System.NotImplementedException();
        }

        public override void Generate()
        {
            string parName;
            
            // #region Desc
            //
            // parName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc1";
            // var par = GetReportObj(_secParams.AbstractSection, parName) as ReportParagraph;
            // par.Init(_resParams, _template, _secParams.NumFmtr);
            // par.Text = ResHelper.GetResVal(_sectionResName, $"{parName}", _ci)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"Price", _secParams.NumFmtr.Format(par.Parameters.First(x => x.Key == "Price").Value.ToString(), decimals:1)},
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
            //         })
            //         ;
            // AddParagraph(par);
            //
            // AddSpace(0.3);
            //
            //
            // parName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_Desc2";
            // par = GetReportObj(_secParams.AbstractSection, parName) as ReportParagraph;
            // par.Init(_resParams, _template, _secParams.NumFmtr);
            // par.Text = ResHelper.GetResVal(_sectionResName, $"{parName}", _ci)
            //         .ReplaceVals(new Dictionary<string, string>()
            //         {
            //             {"BatteryName", _secParams.NumFmtr.Format(par.Parameters.First(x => x.Key == "BatteryName").Value.ToString(), decimals:1)},
            //             {"CompanyName", _template.GlobalSettings.CompanyName},
            //         })
            //     ;
            // AddParagraph(par);
            //
            // #endregion
        }

        public override void GenerateContent()
        {
            throw new System.NotImplementedException();
        }
    }
}