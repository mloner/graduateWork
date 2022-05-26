using System.ComponentModel.DataAnnotations;

namespace ReportingFramework.WebApp.Database.DataBaseModels
{
    public partial class TemplateEditor
    {
        [Key]
        public int Id { get; set; }
        public string EcoscadaUsername { get; set; }
        public string Link { get; set; }
        public string Token { get; set; }
    }
}
