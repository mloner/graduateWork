namespace SectionModels.ReportObjects.Tables;

public class CugGapsInputsTable : Table
{
    public List<CugGapsInputsTableDataItem> Data { get; set; }
    public CugGapsInputsTable()
    {
        Type = (int) ReportObjectTypeEnum.Table;
        Subtype = (int) TableTypeEnum.CugGapsInputs;
    }
    
    public class CugGapsInputsTableDataItem
    {
        public string BuildingName { get; set; }
        public string AimrId { get; set; }
        public string AimrName { get; set; }
        public string AimrType { get; set; }
        public string InputId { get; set; }
        public string Medium { get; set; }
        public string InputName { get; set; }
        public string LastValueTimestamp { get; set; }
        public string LastValue { get; set; }
        public string GateTime { get; set; }  
        public string Description { get; set; }
    }
}