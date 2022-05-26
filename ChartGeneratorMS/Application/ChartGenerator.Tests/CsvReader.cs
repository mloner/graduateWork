using System.Globalization;

namespace ChartGenerator.Tests;

public class CsvReader
{
    public List<IDictionary<string, object>> GetData(string fileName)
    {
        List<IDictionary<string, object>> res;
        using (TextReader reader = new StreamReader(fileName))
        {
            using (var csvReader = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csvReader.Configuration.Delimiter = ",";
                res = csvReader.GetRecords<dynamic>().Select(x => (IDictionary<string, object>)x).ToList();
            }
        }

        return res;
    }
}