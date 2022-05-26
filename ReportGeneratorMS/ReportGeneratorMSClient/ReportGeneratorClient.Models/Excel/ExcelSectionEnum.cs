namespace SectionModels.Excel;

public enum ExcelSectionEnum
{
    //Maintenance report
    Maintenance_CugGapsInputs,
    Maintenance_AllMeters,
    Maintenance_MetersByMedia,
    
    //MultiCug energy management report
    MCEM_AllCugsSummary,
    MCEM_CugReport,
        
    //Cug savings report
    CugSavingsSheet_CugSavings,
    DataSheet_CugSavings,
        
    //DQValid report
    DQValid_Overview,
    DQValid_DataFromFuture,
    DQValid_Gaps,
    DQValid_Outliers,
    DQValid_Anomalies,
    DQValid_InputType,
    DQValid_InputProfile
}