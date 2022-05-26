using System;
using System.Drawing;

namespace ChartGenerator.Extensions
{
    public static class ColorConverterExtension
    {
        public static string ToRgbaString(this Color c) => $"rgba({c.R},{c.G},{c.B},{Math.Round((double)c.A/256, 2)})";
    }
}