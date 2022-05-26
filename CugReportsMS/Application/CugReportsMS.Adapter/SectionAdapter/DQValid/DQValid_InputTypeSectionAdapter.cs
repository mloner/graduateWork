using System.Collections.Generic;
using ReportingFramework.ReportTypesAdapter.DQValid.DataModels;
using SectionModels;
using SectionModels.Excel.SectionModels.DQValid;


namespace ReportingFramework.SectionAdapter.DQValid
{
    public class DQValid_InputTypeSectionAdapter : ExcelSectionAdapter
    {
        public new DQValid_InputTypeSectionModel SectionModelModel { get; set; }

        public DQValid_InputTypeSectionAdapter()
        {
            SectionModelModel = new DQValid_InputTypeSectionModel();
        }

        public override SectionModel CreateSectionModel()
        {
            var data = (DQInputData) CommonData["Data"];
            if (data.ReportsConfigurator.Contains("input_type"))
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
                newRow.Add("EcoscadaInputType", input.Reports?.InputType?.Report?.EcoscadaInfo?.EcoscadaInputType);
                newRow.Add("IsMeterBidirectional", input.Reports?.InputType?.Report?.EcoscadaInfo?.IsMeterBidirectional.ToString());
                newRow.Add("IsMeterreading", input.Reports?.InputType?.Report?.TypeClassification?.IsMeterReading.ToString());
                newRow.Add("IsPulse",input.Reports?.InputType?.Report?.TypeClassification?.IsPulse.ToString());

                SectionModelModel.Data.Add(newRow);
            }
        }
    }
}