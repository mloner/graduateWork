using System.ComponentModel;

namespace ReportingFramework.Dto
{
    public enum StyleEnum
    {
        [Description("TitlePageHeader")]
        TitlePageHeader,
        
        [Description("TitlePageSubheader")]
        TitlePageSubheader,
        
        [Description("Title")]
        Title,
        
        [Description("H1")]
        H1,
        
        [Description("H2")]
        H2,
        
        [Description("H3")]
        H3,
        
        [Description("H4")]
        H4,
        
        [Description("H5")]
        H5,
        
        [Description("H6")]
        H6,
        
        [Description("H7")]
        H7,
        
        [Description("Normal")]
        Normal,
        
        [Description("Footer")]
        Footer,
        
        [Description("Header")]
        Header,
        
        [Description("Image")]
        Image,
        
        [Description("ImageTitle")]
        ImageTitle,
        
        [Description("ImageTitleShort")]
        ImageTitleShort,
        
        [Description("TableHeader")]
        TableHeader,
        
        [Description("TableSubheader")]
        TableSubheader,

        [Description("TableContentDefault")]
        TableContentDefault,

        [Description("TableContentPrimary")]
        TableContentPrimary,
        
        [Description("TableContentWarning")]
        TableContentWarning,
        
        [Description("TableContentDanger")]
        TableContentDanger,
    }
}