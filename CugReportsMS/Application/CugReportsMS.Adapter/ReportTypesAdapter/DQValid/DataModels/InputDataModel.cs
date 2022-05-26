using System.Collections.Generic;
//using ApiService.EcoScadaMicroservice.JsonModels;
using Newtonsoft.Json;

namespace ReportingFramework.ReportTypesAdapter.DQValid.DataModels
{
    
        public class Daterange
        {
            [JsonProperty("timestamp_from")] public string TimestampFrom { get; set; }
            [JsonProperty("timestamp_to")] public string TimestampTo { get; set; }
        }

        public class Validity
        {
            [JsonProperty("is_valid")] public bool IsValid { get; set; }
            [JsonProperty("status")] public string Status { get; set; }
        }
        public class DataFromFuture

        {
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("report")] public DataFromFutureReport Report { get; set; }
            public class DataFromFutureReport
            {
                [JsonProperty("future_points_count")] public int FuturePointsCount { get; set; }
                [JsonProperty("is_forecast")] public bool IsForecast { get; set; }
                [JsonProperty("future_points")] public List<FuturePointsItem> FuturePoints { get; set; }

                public class FuturePointsItem
                {
                    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
                    [JsonProperty("value")] public float Value { get; set; }
                }
            }
        }

        public class Gaps
        {
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("report")] public GapsReport Report { get; set; }

            public class GapsReport
            {
                [JsonProperty("aligned_daterange")] public GapsAlignedDaterange AlignedDaterange { get; set; }
                [JsonProperty("gaps_count")] public GapsGapsCount GapsCount { get; set; }
                public class GapsAlignedDaterange
                {
                    [JsonProperty("timestamp_from")] public string TimestampFrom { get; set; }
                    [JsonProperty("timestamp_to")] public string TimestampTo { get; set; }
                }
                public class GapsGapsCount
                {
                    [JsonProperty("total")] public int Total { get; set; }
                    [JsonProperty("shifted")] public int Shifted { get; set; }
                    [JsonProperty("lost")] public int Lost { get; set; }
                }

                [JsonProperty("gaps")] public List<GapsItem> Gaps { get; set; }
                public class GapsItem
                {
                    [JsonProperty("timestamp")] public string Timestamp { get; set; }
                    [JsonProperty("type")] public string Type { get; set; }
                    [JsonProperty("fit")] public string Fit { get; set; }
                }
            }
        }

        public class Outliers
        {
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("report")] public OutliersReport Report { get; set; }
            public class OutliersReport
            {
                [JsonProperty("outliers_count")] public int OutliersCount { get; set; }
                [JsonProperty("outliers")] public List<OutliersItem> Outliers { get; set; }
                public class OutliersItem
                {
                    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
                    [JsonProperty("value")] public float Value { get; set; }
                }
            }
        }

        public class Anomalies
        {
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("report")] public AnomaliesReport Report { get; set; }
            public class AnomaliesReport
            {
                [JsonProperty("anomalies_count")] public int AnomaliesCount { get; set; }
                [JsonProperty("anomalies")] public List<AnomaliesItem> Anomalies{ get; set; }
                public class AnomaliesItem
                {
                    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
                    [JsonProperty("value")] public double Value { get; set; }
                }

            }
        }

        public class InputType
        {
            [JsonProperty("status")] public string Status { get; set; }
            
            [JsonProperty("report")] public InputTypeReport Report { get; set; }
            public class InputTypeReport
            {
                [JsonProperty("ecoscada_info")] public InputTypeEcoscadaInfo EcoscadaInfo { get; set; }
                [JsonProperty("type_classification")] public InputTypeTypeClassification TypeClassification { get;
                    set;
                }

                public class InputTypeEcoscadaInfo
                {
                    [JsonProperty("ecoscada_input_type")] public string EcoscadaInputType { get; set; } 
                    [JsonProperty("is_meter_bidirectional")] public bool IsMeterBidirectional { get; set; } 
                }

                public class InputTypeTypeClassification
                {
                    [JsonProperty("is_meterreading")] public bool IsMeterReading { get; set; }
                    [JsonProperty("is_pulse")] public bool IsPulse { get; set; }
                }
            }
        }

        public class InputProfile
        {
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("report")] public InputProfileReport Report { get; set; }
            public class InputProfileReport
            {
                [JsonProperty("profile_classification")] public InputProfileProfileClassification ProfileClassification
                {
                    get;
                    set;
                }
                public class InputProfileProfileClassification
                {
                    [JsonProperty("is_solar")] public bool IsSolar { get; set; }
                    [JsonProperty("is_grid")] public bool IsGrid { get; set; }
                }
            }

        }

        public class Reports
        {
            [JsonProperty("data_from_future")] public DataFromFuture DataFromFuture { get; set; }
            [JsonProperty("gaps")] public Gaps Gaps { get; set; }
            [JsonProperty("outliers")] public Outliers Outliers { get; set; }
            [JsonProperty("anomalies")] public Anomalies Anomalies { get; set; }
            [JsonProperty("input_type")] public InputType InputType { get; set; }
            [JsonProperty("input_profile")] public InputProfile InputProfile { get; set; }

        }
        
        // public class Input 
        // {
        //     [JsonProperty("validity")] public Validity Validity { get; set; }
        //     [JsonProperty("daterange")] public Daterange Datareng { get; set; }
        //     [JsonProperty("checkers_reports")]public CheckersReports CheckersReports { get; set; }
        // }

        public class DQInputData
        {
            [JsonProperty("result_info")] public List<Input> ResultInfo { get; set; }
            [JsonProperty("reports_configuration")] public List<string> ReportsConfigurator { get; set;}
        }

        public class Input
        {
            [JsonProperty("source")]public Source Source { get; set; }
            [JsonProperty("properties")] public Properties Properties { get; set; }
            [JsonProperty("validity")] public Validity Validity { get; set; }
            [JsonProperty("daterange")] public Daterange Datareng { get; set; }
            [JsonProperty("reports")]public Reports Reports { get; set; }
        } 
        
        public class Properties
        {
            [JsonProperty("input_type")] public string InputType { get; set; }
            [JsonProperty("medium_unit")] public string MediumUnit { get; set; }
            [JsonProperty("gate_time")] public string GateTime { get; set; }
            [JsonProperty("is_forecast")] public bool IsForecast { get; set; }
        }
        
        public class Source
        {
            [JsonProperty("cug_name")] public string CugName { get; set; }
            [JsonProperty("building_name")] public string BuildingName { get; set; }
            [JsonProperty("measurements_names")] public List<string> MeasurementsNames { get; set; }
            [JsonProperty("input_name")] public string InputName { get; set; }
        }
}