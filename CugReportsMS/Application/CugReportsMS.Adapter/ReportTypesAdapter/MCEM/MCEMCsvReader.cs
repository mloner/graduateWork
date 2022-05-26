using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ReportingFramework.ReportTypesAdapter.MCEM.DataModels;

namespace ReportingFramework.ReportTypesAdapter.MCEM
{
    public class MCEMCsvReader : CsvReader
    {
        public List<MECMReportDataModel> GetMultiCugDataModels(string fileName)
        {
            var result = new List<MECMReportDataModel>();
            using (TextReader reader = File.OpenText(fileName))
            {
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ",";
                csv.Configuration.MissingFieldFound = null;
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    result.Add(new MECMReportDataModel
                    {
                        CugName = csv.GetField<string>(0),
                        BuildingName = csv.GetField<string>(1),
                        BuildingType = csv.GetField<string>(2),
                        Surface = csv.GetField<double?>(3),
                        ElectricityCurrentYear = csv.GetField<double?>(4),
                        ElectricityRefYear = csv.GetField<double?>(5),
                        GasCurrentYear = csv.GetField<double?>(6),
                        GasRefYear = csv.GetField<double?>(7),
                        SolarCurrentYear = csv.GetField<double?>(8),
                        SolarRefYear = csv.GetField<double?>(9),
                    });
                }
            }

            return result;
        }
    }
}