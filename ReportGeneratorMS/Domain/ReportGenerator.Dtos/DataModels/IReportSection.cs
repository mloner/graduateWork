using System.Collections.Generic;

namespace ReportingFramework.Dto.DataModels
{
    public interface IReportSection
    {
        void Init(AbstractSectionParameters sectionParameters);
        void Generate();
        void AddImage(
            MigraDoc.DocumentObjectModel.Section section,
            string imgPath,
            string imgTitle,
            double imgWidthCm,
            GlobalSettings.GlobalSettings globalSettings,
            List<Style> styles,
            int? figureNum = null,
            double titleSize = 10,
            bool isShortTitle = false);
    }
}