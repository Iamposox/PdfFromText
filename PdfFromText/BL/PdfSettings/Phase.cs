using System;
using System.Collections.Generic;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

namespace PdfFromText.BL.PdfSettings {
    public static class Phase {
        public static void PhaseOne(Document document) {
            var paragraph = document.LastSection.AddParagraph("Phase 1", "Heading1");
            paragraph = document.LastSection.AddParagraph("Installed technologies:");
            paragraph.AddText("Installed technologies:");
            AddParagraph(document,"Geothermal/water gas absorption heat pumps – 2 pcs", "ListInfo");
            Figure(document, $"images/3.jpg", "Figure 1: Phase 1 Energy Diagram");
            AddParagraph(document,"\r\nThis month 20 MWh of heating energy was provided to the phase 1 building by heat pumps. Consumption of gas compared with previous months is shown below.", "Zero");
            DefCharts(document, "Figure 2: Phase 1 Energy Consumption monthly comparison");
            DefCharts(document, "Figure 3: Phase 1 Control(December, 2020)");
            AddParagraph(document,"\r\nThe minimum return water temperature this month was 39.4 °C", "Zero");
        }

        public static void PhaseTwo(Document document) {
            var paragraph = document.LastSection.AddParagraph("Phase 2", "Heading1");
            paragraph = document.LastSection.AddParagraph("\r\n");
            paragraph.AddText("Installed technologies:");
            AddParagraph(document, "Electrical air/water heat pump", "ListInfo");
            AddParagraph(document, "Electrical geothermal/water heat pump", "ListInfo");
            AddParagraph(document, "Geothermal/water gas absorption heat pump", "ListInfo");
            AddParagraph(document, "Gas condensing boiler", "ListInfo");
            Figure(document, $"images/1.jpg", "Figure 4: Phase 2 Energy Diagram");
            AddParagraph(document, "\r\nThe electrical and gas energy consumed by the installed technologies this month is shown below:", "Zero");
            DefCharts(document, "Figure 5: Phase 2 Energy Consumption");
            AddParagraph(document, "\r\nThis month 19.5 MWh of heating energy was provided to the phase 2 building by heat pumps and the gas boiler." +
                                   "Consumption of electricity and gas compared with previous months is shown below.", "Zero");
            DefCharts(document, "Figure 6: Phase 2 Energy Consumption monthly comparison");
            DefCharts(document, "Figure 7: Phase 2 Control (December, 2020)");
            AddParagraph(document, "\r\nThe minimum return water temperature this month was 35.6 °C", "Zero");
        }
        
        static void AddParagraph(Document document, string text, string style) => document.LastSection.AddParagraph(text, style);

        static void Figure(Document document, string filename, string info) {
            var paragraph = document.LastSection.AddParagraph();
            var image = paragraph.AddImage(filename);
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            image.Height = "5cm";
            image.Width = "5cm";
            paragraph.AddText($"\r\n{info}");
        }

        public static void DefCharts(Document document, string info) {
            document.LastSection.AddParagraph("", "Heading2");
            Chart chart = new Chart();
            chart.Left = 0;
            chart.Width = Unit.FromCentimeter(16);
            chart.Height = Unit.FromCentimeter(12);
            Series series = chart.SeriesCollection.AddSeries();
            series.ChartType = ChartType.Column2D;
            series.Add(new double[] { 220, 105, 95, 50, 3, 45, 90, 180, 190, 185 });
            XSeries xseries = chart.XValues.AddXSeries();
            xseries.Add("March", "April", "May", "June", "July", "August", "September", "October", "November", "December");
            chart.XAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.MajorTickMark = TickMarkType.Outside;
            chart.YAxis.HasMajorGridlines = true;
            chart.PlotArea.LineFormat.Color = Colors.Black;
            chart.PlotArea.LineFormat.Width = 1;
            document.LastSection.Add(chart);
            var paragraph = document.LastSection.AddParagraph($"\r\n{info}");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
        }
    }
}
