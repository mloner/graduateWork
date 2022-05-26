using MigraDoc.DocumentObjectModel;

namespace ReportingFramework.Common.Template.Style
{
    public static class StyleExtension
    {
        public static ParagraphFormat ToParagraphFormat(this Dto.Style style)
        {
            var res = new ParagraphFormat()
            {
                Alignment = style.Alignment.ToPdfParameter(),
                LineSpacingRule = LineSpacingRule.Multiple,
                LineSpacing = style.LineSpace,
                SpaceAfter = new Unit(style.SpaceAfter, UnitType.Centimeter),
                Font = style.Font == null ? null : style.Font.ToPdfFont(),
            };

            return res;
        }
    }
}