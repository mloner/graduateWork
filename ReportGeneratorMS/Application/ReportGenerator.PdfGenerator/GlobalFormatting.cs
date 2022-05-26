using System.Linq;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using Style = ReportingFramework.Dto.Style;

namespace ReportingFramework
{
    public static class GlobalFormatting
    {
        public static class Tables
        {
            //header
            private static MigraDoc.DocumentObjectModel.Tables.Row CreateHeader()
            {
                return new Row()
                {
                    BottomPadding = new Unit(0.1, UnitType.Centimeter),
                    TopPadding = new Unit(0.1, UnitType.Centimeter),
                    Borders = new Borders()
                    {
                        Bottom = new Border()
                        {
                            Color = Colors.LightGray,
                            Width = new Unit(0.02, UnitType.Centimeter),
                            Visible = true
                        },
                        //Width = new Unit(0.01, UnitType.Centimeter),
                        //Color = Colors.DarkGray
                    }
                };
            }

            public static Row InitHeader(Style style)
            {
                var header = CreateHeader();
                
                //color
                var color = style.BgColor.Split(",").Select(x => byte.Parse(x)).ToList();
                header.Shading.Color = new Color(color[0], color[1], color[2]);

                return header;
            }

            public static Row InitHeaderWithoutCaptions(Style style)
            {
                var header = CreateHeader();
                
                //color
                var color = style.BgColor.Split(",").Select(x => byte.Parse(x)).ToList();
                header.Shading.Color = new Color(color[0], color[1], color[2]);

                //height
                header.BottomPadding = 0;
                header.TopPadding = 0;
                
                return header;
            }
            
            //subheader
            private static MigraDoc.DocumentObjectModel.Tables.Row CreateSubheader()
            {
                return new Row()
                {
                    BottomPadding = new Unit(0.1, UnitType.Centimeter),
                    TopPadding = new Unit(0, UnitType.Centimeter),
                    Borders = new Borders()
                    {
                        Bottom = new Border()
                        {
                            Color = Colors.LightGray,
                            Width = new Unit(0.02, UnitType.Centimeter),
                            Visible = true
                        },
                        //Width = new Unit(0.01, UnitType.Centimeter),
                        //Color = Colors.DarkGray
                    },
                    VerticalAlignment = VerticalAlignment.Center
                };
            }

            public static Row InitSubheader(Style style)
            {
                var subheader = CreateSubheader();
                
                
                
                return subheader;
            }
            
            //row
            private static MigraDoc.DocumentObjectModel.Tables.Row CreateRow()
            {
                return new Row()
                {
                    BottomPadding = new Unit(0, UnitType.Centimeter),
                    TopPadding = new Unit(0, UnitType.Centimeter),
                    Borders = new Borders()
                    {
                        Bottom = new Border()
                        {
                            Color = Colors.LightGray,
                            Width = new Unit(0.02, UnitType.Centimeter),
                            Visible = true
                        },
                        //Width = new Unit(0.01, UnitType.Centimeter),
                        //Color = Colors.DarkGray
                    },
                    VerticalAlignment = VerticalAlignment.Top
                };
            }

            public static Row InitRow(Style style)
            {
                var row = CreateRow();
                
                
                
                return row;
            }
        }
    }
}