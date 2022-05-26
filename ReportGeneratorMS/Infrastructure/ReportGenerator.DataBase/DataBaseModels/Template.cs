namespace GeneratorDataBase.DataBaseModels
{
    public partial class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? GlobalSettingsId { get; set; }
        public int? StylesId { get; set; }
        public int? SectionToTemplateRelationsId { get; set; }
        public int? SectionTypeTemplatesId { get; set; }

        public virtual TemplateComponent? GlobalSettings { get; set; }
        public virtual TemplateComponent? SectionToTemplateRelations { get; set; }
        public virtual TemplateComponent? SectionTypeTemplates { get; set; }
        public virtual TemplateComponent? Styles { get; set; }
    }
}
