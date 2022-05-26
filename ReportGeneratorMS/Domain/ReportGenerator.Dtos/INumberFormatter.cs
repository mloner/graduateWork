namespace ReportingFramework.Dto
{
    public interface INumberFormatter
    {
        string GroupSeparator { get; set; }
        string DecimalSeparator { get; set; }
        int Decimals { get; set; }
        string NullValue { get; set; }

        string Format(double? d, int? decimals = null, string groupSeparator = null, string decimalSeparator = null);
        public string Format(double d, int? decimals = null, string groupSeparator = null, string decimalSeparator = null);

        public string Format(int? i, int? decimals = null);

        public string Format(int i, int? decimals = null);

        public string Format(string s, int? decimals = null, string groupSeparator = null, string decimalSeparator = null);
    }
}