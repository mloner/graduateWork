namespace ReportingFramework.Structure.Sections.ExSum.BatSimShort
{
    public abstract class ExecSumBatSimShortSec : PdfExecutiveSummary
    {
        public override void Generate()
        {
            AddDesc1();
            AddSpace(0.1);
            AddLocation();
            AddSpace(0.4);
            AddDesc2();
        }

        public abstract void AddDesc1();
        public abstract void AddDesc2();

        public void AddLocation()
        {
            // var locInfoName = $"{SubsectionTypeEnum.CommonDataObj.Desc()}_LocationInfo";
            // var locInfoObj = GetReportObj(_sectionData, locInfoName);
            //
            // foreach (var documentObject in AddLocationInfoBlock(locInfoObj))
            // {
            //     _pdfSection.Elements.Add((DocumentObject)documentObject.Clone());
            // }
        }
    }
}