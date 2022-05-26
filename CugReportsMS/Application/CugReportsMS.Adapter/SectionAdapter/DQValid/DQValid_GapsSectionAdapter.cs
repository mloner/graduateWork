using System.Collections.Generic;
using ReportingFramework.ReportTypesAdapter.DQValid.DataModels;
using SectionModels;
using SectionModels.Excel.SectionModels.DQValid;


namespace ReportingFramework.SectionAdapter.DQValid
{
    public class DQValid_GapsSectionAdapter : ExcelSectionAdapter
    {
        public new DQValid_GapsSectionModel SectionModelModel { get; set; }

        public DQValid_GapsSectionAdapter()
        {
            SectionModelModel = new DQValid_GapsSectionModel();
        }
        public override SectionModel CreateSectionModel()
        {
            var data = (DQInputData)CommonData["Data"];
           
            if (data.ReportsConfigurator.Contains("gaps"))
            {
                LoadInputData(data.ResultInfo);
            }
            return SectionModelModel;
            
        }
        
        private void LoadInputData(List<Input> InputData)
        {
            foreach (var input in InputData)
            {
                if (input.Reports?.Gaps?.Report.GapsCount.Total != 0 && input.Reports?.Gaps?.Report != null)
                {
                    foreach (var val in input.Reports?.Gaps?.Report?.Gaps)
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
                            for(int i = 1; i < input.Source.MeasurementsNames.Count; i++)
                            {
                                MeasurementToString +="\n" + input.Source.MeasurementsNames[i] ;
                            }
                        }
                    
                        newRow.Add("MeasurementsNames", MeasurementToString);
                        newRow.Add("InputName", input.Source?.InputName);
                        newRow.Add("Timestamp", val?.Timestamp);
                        newRow.Add("GapsType", val?.Type);
                        newRow.Add("Fit", val?.Fit);
                        
                        SectionModelModel.Data.Add(newRow);
                    }
                }
            }
        }
    }
}