using System;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using NLog;
using PdfFromText.BL.Interface;
using PdfFromText.BL.PdfSettings;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PdfFromText.BL {
    public class PdfManager : IPdfManager {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private string _createdDocsPath = Environment.CurrentDirectory;

        public PdfManager() { }
        public string CreatePdfAsync() {
            try {
                // Create a new PDF document
                Document document = CreateDocument();

                // Save the document...
                string filename = "HelloWorld.pdf";
                var pdfRenderer = new PdfDocumentRenderer(true, PdfFontEmbedding.Always);
                pdfRenderer.Document = document;
                pdfRenderer.RenderDocument();
                pdfRenderer.PdfDocument.Save(filename);
                return filename;
            }
            catch (Exception e) {
                _logger.Error($"We don't created pdf\r\ngot error:{e.Message}");
                throw;
            }
        }

        private static Document CreateDocument() {
            Document document = new Document();
            DefinedStyle.DefineStyles(document);
            DefineCover.DefCover(document);
            Phase.PhaseOne(document);
            Phase.PhaseTwo(document);
            return document;
        }
    }
}
