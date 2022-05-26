namespace GeneratorDataBase.DataBaseModels
{
    public partial class Report
    {
        public Guid Id { get; set; }
        public string Parameters { get; set; }
        public int StatusId { get; set; }
        public string? Link { get; set; }
    }
}
