using System.Collections.Generic;
using ReportingFramework.ReportTypesAdapter.DQValid.DataModels;
using SectionModels;
using SectionModels.Excel.SectionModels.DQValid;

namespace ReportingFramework.SectionAdapter.DQValid
{
    public class DQValid_OverviewSectionAdapter : ExcelSectionAdapter
    {
        public new DQValid_OverviewSectionModel SectionModelModel { get; set; }

        public DQValid_OverviewSectionAdapter()
        {
            SectionModelModel = new DQValid_OverviewSectionModel();
        }
        
        public override SectionModel CreateSectionModel()
        {
            var data = (DQInputData)CommonData["Data"];

            SectionModelModel.Data = new List<Dictionary<string, string>>();
            
            LoadInputData(data.ResultInfo);

            return SectionModelModel;
        }

        private void LoadInputData(List<Input> InputData)
        {
            if (InputData.Count != 0)
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
                        for(int i = 1; i < input.Source.MeasurementsNames.Count; i++)
                        {
                            MeasurementToString +="\n" + input.Source.MeasurementsNames[i] ;
                        }
                    }
                    
                    newRow.Add("MeasurementsNames", MeasurementToString);
                    newRow.Add("InputName", input.Source?.InputName);

                    // Properties
                    newRow.Add("InputType", input.Properties?.InputType);
                    newRow.Add("MediumUnit", input.Properties?.MediumUnit);
                    newRow.Add("GateTime", input.Properties?.GateTime);
                    newRow.Add("IsForecast", input.Properties?.IsForecast.ToString());

                    // Validity
                    newRow.Add("IsValid", input.Validity?.IsValid.ToString());
                    newRow.Add("Status", input.Validity?.Status);

                    //Daterane
                    newRow.Add("FirstDate", input.Datareng?.TimestampFrom);
                    newRow.Add("EndDate", input.Datareng?.TimestampTo);

                    // General information about checkers

                    // DataFromFutureChecker
                    newRow.Add("DataFromFutureStatus", input.Reports?.DataFromFuture?.Status);
                    newRow.Add("FuturePointsCount", input.Reports?.DataFromFuture?.Report?.FuturePointsCount.ToString());

                    // GapsChecker
                    newRow.Add("GapsStatus", input.Reports?.Gaps?.Status);
                    newRow.Add("GapsCount", input.Reports?.Gaps?.Report?.GapsCount?.Total.ToString());

                    // OutliersChecker
                    newRow.Add("OutliersStatus", input.Reports?.Outliers?.Status);
                    newRow.Add("OutliersCount", input.Reports?.Outliers?.Report?.OutliersCount.ToString());

                    // AnomaliesChecker
                    newRow.Add("AnomaliesStatus", input.Reports?.Anomalies?.Status);
                    newRow.Add("AnomaliesCount",
                        input.Reports?.Anomalies?.Report?.AnomaliesCount.ToString());

                    // InputTypeClassifier
                    newRow.Add("InputTypeStatus", input.Reports?.InputType?.Status);

                    // InputProfileClassifier
                    newRow.Add("InputProfileStatus", input.Reports?.InputProfile?.Status);

                    SectionModelModel.Data.Add(newRow);
                }
            }
        }
    }
}