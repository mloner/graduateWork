namespace GeneratorDataBase.DataBaseModels
{
    public partial class TemplateComponent
    {
        public TemplateComponent()
        {
            TemplateGlobalSettings = new HashSet<Template>();
            TemplateSectionToTemplateRelations = new HashSet<Template>();
            TemplateSectionTypeTemplates = new HashSet<Template>();
            TemplateStyles = new HashSet<Template>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Template> TemplateGlobalSettings { get; set; }
        public virtual ICollection<Template> TemplateSectionToTemplateRelations { get; set; }
        public virtual ICollection<Template> TemplateSectionTypeTemplates { get; set; }
        public virtual ICollection<Template> TemplateStyles { get; set; }
    }
}
