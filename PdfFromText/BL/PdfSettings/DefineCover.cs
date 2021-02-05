using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;

namespace PdfFromText.BL.PdfSettings {
    public static class DefineCover {
        public static void DefCover(Document document) {
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            var image = paragraph.AddImage($"images/1.jpg");
            image.Width = "6cm";
            image.Height = "3cm";
            paragraph.Format.SpaceAfter = "-3cm";
            paragraph.Format.SpaceBefore = "-2cm";
            paragraph.Format.Borders.Bottom = new Border { Width = "2pt", Color = Colors.DarkGray };
            paragraph = section.AddParagraph("Energy Service Report", "Zero");
            paragraph.Format.Font.Color = Colors.DarkBlue;
            paragraph.Format.Font.Size = 22;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.LeftIndent = "7cm";
            paragraph = section.AddParagraph("Cordium: Real-time heat control", "Zero");
            paragraph.Format.Font.Color = Colors.LightBlue;
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.LeftIndent = "7cm";
            paragraph.Format.Font.Size = 18;
            paragraph = section.AddParagraph("Period:", "Title");
            paragraph = section.AddParagraph();
            var data = paragraph.AddDateField();
            data.Format = "MM, yyyy";
            paragraph.Format.Font.Size = 16;
            paragraph.Format.SpaceBefore = "-1.3cm";
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            ProjectDetails(section);
            ExecutiveSum(section);
            ProjectOverview(section);
        }

        static void ProjectDetails(Section section) {
            var paragraph = section.AddParagraph("Project Details", "Title");
            paragraph = section.AddParagraph("", "Zero");
            var image = paragraph.AddImage($"images/2.jpg");
            image.Height = "3cm";
            image.Width = "8cm";
            image = paragraph.AddImage($"images/3.jpg");
            image.Height = "3cm";
            image.Width = "8cm";
            section.AddParagraph("Project Manager:Frank Louwet", "ListInfo");
            section.AddParagraph("Location: Crutzestraat, Hasselt", "ListInfo");
        }

        static void ExecutiveSum(Section section) {
            var paragraph = section.AddParagraph("Executive Summary", "Title");
            paragraph = section.AddParagraph("This month there werea total of 345 degree days","Zero");
            paragraph = section.AddParagraph("\r\n");
            paragraph.AddText("Phase 1 heating energy:");
            section.AddParagraph("2196 kWh of gas consumed (0.32 kWh per apartment per degree day)", "ListInfo");
            paragraph = section.AddParagraph("\r\n");
            paragraph.AddText("Phase 2 heating energy:");
            section.AddParagraph("14515 kWh of gas consumed (2.1 kWh per apartment per degree day)", "ListInfo");
            section.AddParagraph("3.5 kWh of electricity consumed (0.00051 kWh per apartment per degree day)", "ListInfo");
            paragraph = section.AddParagraph("\r\n");
            paragraph.AddText("Phase 3 heating energy:");
            section.AddParagraph("17791 kWh of gas consumed (1.8 kWh per apartment per degree day)", "ListInfo");
            section.AddParagraph("650 kWh of electricity produced", "ListInfo");
        }

        static void ProjectOverview(Section section) {
            var paragraph = section.AddParagraph("Project Overview", "Title");
            paragraph = section.AddParagraph("Theadvanced control strategy is implemented in a district heating system for social housing in Crutzestraat, Hasselt. " +
                                             "Thesocial housing is operated by Cordium, the operating manager for social housing in Flemish region.The project" +
                                             "consists of three phases or buildings with 20, 20 and 28 apartments in each phase.Each building has its own central" +
                                             "heating system with various technologies installed.Furthermore, central heating systems areinterconnected by an" +
                                             "internal heat transfer network.i.Leco developed thecontrol strategy which sends hourly setpoints fo: maximum and" +
                                             "minimum temperaturesetpoint in each building and/or distribution circuit, operation modes of installed technologies," +
                                             "and distribution statesettings between building/heating systems", "Zero");
            section.PageSetup.DifferentFirstPageHeaderFooter = false;
            section.Footers.Primary.AddParagraph("i.Leco © 29/01/2021");
            var number = new Paragraph();
            number.AddTab();
            number.AddTab();
            number.AddPageField();
            section.Footers.Primary.Add(number);
        }
    }
}
