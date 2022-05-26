namespace ReportingFramework.Dto
{
    public class Style
    {
        public string Name { get; set; }
        public AlignmentEnum Alignment { get; set; }
        public double LineSpace { get; set; }
        public double SpaceAfter { get; set; }
        public Font Font { get; set; }
        public string BgColor { get; set; }
    }
}