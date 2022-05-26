using System;
using System.Linq;
using MigraDoc.DocumentObjectModel;
using Font = ReportingFramework.Dto.Font;

namespace ReportingFramework.Common.Template.Style
{
    public static class FontExtension
    {
        public static MigraDoc.DocumentObjectModel.Font ToPdfFont(this Font font)
        {
            var color = font.Color.Split(",").Select(x => Convert.ToByte((string)x)).ToList();
            var result = new MigraDoc.DocumentObjectModel.Font()
            {
                Name = font.Name?? "",
                Size = font.Size.HasValue ?  new Unit(font.Size.Value, UnitType.Point) : 0,
                Bold = font.Bold.HasValue ? font.Bold.Value : false,
            };
            if (color.Count == 3)
            {
                result.Color = new Color(color[0], color[1], color[2]);
            }
            else if (color.Count == 4)
            {
                result.Color = new Color(color[0], color[1], color[2], color[3]);
            }
            return result;
        }
    }
}