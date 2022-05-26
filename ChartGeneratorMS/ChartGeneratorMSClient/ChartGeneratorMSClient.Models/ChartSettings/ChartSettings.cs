using System.Drawing;
using ChartGeneratorModels.ChartGeneratorModels;

namespace ChartGeneratorModels.ChartSettings
{
    public class ChartSettings
    {
        public ChartLanguage Language { get; set; }
        public List<double?> YMaxes { get; set; }
        public Dictionary<string, Color> Colors { get; set; }
        public Dictionary<string, string> CustomParameters { get; set; }

        public DateTime DefaultStartDate
        {
            get => new DateTime(1970, 01, 01);
        }

    }
}