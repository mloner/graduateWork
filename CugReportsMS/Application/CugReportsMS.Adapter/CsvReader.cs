using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ReportingFramework
{
    public class CsvReader
    {
        public List<IDictionary<string, object>> GetData(string fileName)
        {
            List<IDictionary<string, object>> res = new List<IDictionary<string, object>>();
            using (TextReader _reader = new StreamReader(fileName))
            {
                using (var _csvReader = new CsvHelper.CsvReader(_reader, CultureInfo.InvariantCulture))
                {
                    _csvReader.Configuration.Delimiter = ",";
                    res = _csvReader.GetRecords<dynamic>().Select(x => (IDictionary<string, object>)x).ToList();
                }
            }

            return res;
        }
    }
}