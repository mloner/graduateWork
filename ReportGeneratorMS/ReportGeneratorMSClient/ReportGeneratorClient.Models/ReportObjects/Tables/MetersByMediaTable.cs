namespace SectionModels.ReportObjects.Tables;

public class MetersByMediaTable : Table
{
    public new List<MetersByMediaSectionTableDataItem> Data { get; set; }
    public MetersByMediaTable()
    {
        Type = (int) ReportObjectTypeEnum.Table;
        Subtype = (int) TableTypeEnum.MetersByMedia;
    }
    
    public class MetersByMediaSectionTableDataItem
    {
        public string BuildingName { get; set; }
        public string Medium { get; set; }
        public string Sum { get; set; }
    }
}