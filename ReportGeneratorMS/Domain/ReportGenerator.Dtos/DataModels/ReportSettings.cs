namespace ReportingFramework.Dto.DataModels
{
    public class ReportSettings
    {
        private int FigureNum;
        private int AppendixNum;
        private int FootnoteNum;

        public ReportSettings()
        {
            AppendixNum = 1;
            FigureNum = 1;
            FootnoteNum = 1;
        }
        
        public int AddFigure => FigureNum++;
        public int AddAppendix => AppendixNum++;
        public int AddFootnote => FootnoteNum++;
    }
}