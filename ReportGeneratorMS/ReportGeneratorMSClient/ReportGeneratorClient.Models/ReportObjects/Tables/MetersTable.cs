namespace SectionModels.ReportObjects.Tables;

public class MetersTable : Table
{
    public new List<MetersTableDataItem> Data { get; set; }

    public MetersTable()
    {
        Type = (int) ReportObjectTypeEnum.Table;
        Subtype = (int) TableTypeEnum.Meters;
    }
    
    public class MetersTableDataItem
    {
        public string BuildingName { get; set; }
        public string AimrId { get; set; }
        public string InputId { get; set; }
        public string Medium { get; set; }
        public string InputName { get; set; }
        public string LastValueTimeStamp { get; set; }
        public string LastValue { get; set; }
    }
}