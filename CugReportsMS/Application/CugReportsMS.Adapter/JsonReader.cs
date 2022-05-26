using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ReportingFramework
{
    public static class JsonReader
    {
        // public static string Serialize<T>(T obj)
        // {
        //     DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        //     MemoryStream ms = new MemoryStream();
        //     serializer.WriteObject(ms, obj);
        //     string retVal = Encoding.UTF8.GetString(ms.ToArray());
        //     return retVal;
        // }

        public static T Read<T>(string filePath)
        {
            string str;
            using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                str = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<T>(str);
        }

    }
}