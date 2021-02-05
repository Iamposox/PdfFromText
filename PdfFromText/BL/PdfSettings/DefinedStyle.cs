using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;

namespace PdfFromText.BL.PdfSettings {
    public static class DefinedStyle {
        public static void DefineStyles(Document document) {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style = document.Styles.AddStyle("Zero", "Normal");
            style.ParagraphFormat.SpaceAfter = 0;
            style.ParagraphFormat.SpaceBefore = 0;
            style = document.Styles.AddStyle("ListInfo", "Zero");
            style.ParagraphFormat.LeftIndent = "0.5cm";
            style.ParagraphFormat.ListInfo = new ListInfo {
                ContinuePreviousList = true,
                ListType = ListType.BulletList1
            };
            style = document.Styles.AddStyle("Title", "Zero");
            style.ParagraphFormat.Font.Size = 16;
            style.ParagraphFormat.SpaceBefore = "0.5cm";
            style.ParagraphFormat.SpaceAfter = "0.5cm";
            style.ParagraphFormat.Font.Color = Colors.LightBlue;
            style.ParagraphFormat.Borders.Bottom = new Border { Width = "1pt", Color = Colors.DarkGray };
            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 16;
            style.Font.Color = Colors.LightBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = "0.5cm";
            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;
            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;
            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }
    }
}
