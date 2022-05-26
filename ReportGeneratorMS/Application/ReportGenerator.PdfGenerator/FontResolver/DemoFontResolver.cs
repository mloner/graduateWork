using PdfSharp.Fonts;

namespace ReportingFramework.FontResolver
{
    /// <summary>
    /// Font resolver that extends the default implementation to handle the two font families we include in embedded resources.
    /// </summary>
    public class DemoFontResolver : IFontResolver // FontResolverBase
    {
        public /*override*/ FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Ignore case of font names.
            var name = familyName.ToLower();
            string baseFontName;
            string postfix = "";
            // Deal with the fonts we know.
            switch (name)
            {
                case "averta":
                    baseFontName = "Averta";
                    break;
                default:
                    // We pass all other font requests to the default handler.
                    // When running on a web server without sufficient permission, you can return a default font at this stage.
                    return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
                    //return base.ResolveTypeface(familyName, isBold, isItalic);
            }
            
            if (isBold)
            {
                postfix += "b";
            }
            if (isItalic)
            {
                postfix += "i";
            }
            
            return new FontResolverInfo($"{baseFontName}#{postfix}");
        }

        /// <summary>
        /// Return the font data for the fonts.
        /// </summary>
        public /*override*/ byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "Averta#":
                    return FontHelper.AvertaReg;
                case "Averta#b":
                    return FontHelper.AvertaBold;
                case "Averta#i":
                    return FontHelper.AvertaItalic;
                case "Averta#bi":
                    return FontHelper.AvertaBoldItalic;
            }

            //return base.GetFont(faceName);
            return null;
        }
    }
}
