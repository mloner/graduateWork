using System;
using ReportingFramework.Dto;

namespace ReportingFramework.Common.Template.Style
{
    public static class AlignmentExtension
    {
        public static MigraDoc.DocumentObjectModel.ParagraphAlignment ToPdfParameter(this AlignmentEnum alignmentEnum)
        {
            switch (alignmentEnum)
            {
                case AlignmentEnum.Center:
                    return MigraDoc.DocumentObjectModel.ParagraphAlignment.Center;
                case AlignmentEnum.Justify:
                    return MigraDoc.DocumentObjectModel.ParagraphAlignment.Justify;
                case AlignmentEnum.Left:
                    return MigraDoc.DocumentObjectModel.ParagraphAlignment.Left;
                case AlignmentEnum.Right:
                    return MigraDoc.DocumentObjectModel.ParagraphAlignment.Right;
                default:
                    throw new Exception();
            }
        }
    }
}