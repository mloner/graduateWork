using System;
using System.IO;
using System.Reflection;

namespace ReportingFramework.FontResolver
{
    /// <summary>
    /// Helper class that reads font data from embedded resources.
    /// </summary>
    public static class FontHelper
    {
        public static byte[] AvertaReg
        {
            get { return LoadFontData("ReportingFramework.FontResolver.fonts.averta.avertastd_regular.ttf"); }
        }
        public static byte[] AvertaBold
        {
            get { return LoadFontData("ReportingFramework.FontResolver.fonts.averta.avertastd_bold.ttf"); }
        }
        public static byte[] AvertaItalic
        {
            get { return LoadFontData("ReportingFramework.FontResolver.fonts.averta.avertastd_regular_italic.ttf"); }
        }
        
        public static byte[] AvertaBoldItalic
        {
            get { return LoadFontData("ReportingFramework.FontResolver.fonts.averta.avertastd_bold_italic.ttf"); }
        }

        /// <summary>
        /// Returns the specified font from an embedded resource.
        /// </summary>
        static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);

                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }
}