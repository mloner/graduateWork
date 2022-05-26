using System.Collections.Generic;
using ReportingFramework.ReportTypesAdapter.DQValid.DataModels;
using SectionModels;
using SectionModels.Excel.SectionModels.DQValid;


namespace ReportingFramework.SectionAdapter.DQValid
{
    public class DQValid_InputProfileSectionAdapter : ExcelSectionAdapter
    {
        public new DQValid_InputProfileSectionModel SectionModelModel { get; set; }

        public DQValid_InputProfileSectionAdapter()
        {
            SectionModelModel = new DQValid_InputProfileSectionModel();
        }
        public override SectionModel CreateSectionModel()
        {
            var data = (DQInputData)CommonData["Data"];
            if (data.ReportsConfigurator.Contains("input_profile"))
            {
                LoadInputData(data.ResultInfo);
            }
            return SectionModelModel;
        }
        
        private void LoadInputData(List<Input> InputData)
        {
            foreach (var input in InputData)
            {
                var newRow = new Dictionary<string, string>();

                // Source
                newRow.Add("CugName", input.Source?.CugName);
                newRow.Add("BuildingName", input.Source?.BuildingName);

                // Convert measurements in string
                string MeasurementToString = null;
                if (input.Source.MeasurementsNames.Count != 0)
                {
                    MeasurementToString = input.Source.MeasurementsNames[0];
                    for (int i = 1; i < input.Source.MeasurementsNames.Count; i++)
                    {
                        MeasurementToString += "\n" + input.Source.MeasurementsNames[i];
                    }
                }

                newRow.Add("MeasurementsNames", MeasurementToString);
                newRow.Add("InputName", input.Source?.InputName);
                newRow.Add("IsSolar", input.Reports?.InputProfile?.Report?.ProfileClassification?.IsSolar.ToString());
                newRow.Add("IsGrid", input.Reports?.InputProfile?.Report?.ProfileClassification?.IsGrid.ToString());
                
                SectionModelModel.Data.Add(newRow);
            }
        }
    }
}