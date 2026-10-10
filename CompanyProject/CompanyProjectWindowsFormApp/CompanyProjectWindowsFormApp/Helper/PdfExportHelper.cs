using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

using PdfDocument = MigraDoc.DocumentObjectModel.Document;

namespace CompanyProjectWindowsFormApp.Helper
{
    internal class PdfExportHelper
    {
        public static void ExportToPdf(
            DataGridView dataGridView,
            int[] columnIndices,
            string filePath,
            string documentTitle = "Data",
            bool textOnly = true,
            int? imageColumnIndex = null,
            int? progressColumnIndex = null,
            int? progressValueColumnIndex = null,
            double progressMaximum = 10)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            PdfDocument document = CreateDocument(documentTitle);
            Section section = document.LastSection;

            List<int> columns = GetValidColumns(
                dataGridView, columnIndices);

            List<string> temporaryFiles = new List<string>();

            try
            {
                AddDataGridViewTable(
                    section,
                    dataGridView,
                    columns,
                    textOnly,
                    imageColumnIndex,
                    progressColumnIndex,
                    progressValueColumnIndex,
                    progressMaximum,
                    temporaryFiles);

                SaveDocument(document, filePath);
            }
            finally
            {
                DeleteTemporaryFiles(temporaryFiles);
            }
        }

        public static void ExportToPdf(
            Chart chart,
            string filePath,
            string documentTitle = "Chart")
        {
            if (chart == null)
                throw new ArgumentNullException(nameof(chart));

            PdfDocument document = CreateDocument(documentTitle);
            Section section = document.LastSection;

            List<string> temporaryFiles = new List<string>();

            try
            {
                string imagePath = CreateTemporaryImagePath();
                temporaryFiles.Add(imagePath);

                chart.SaveImage(imagePath, ChartImageFormat.Png);

                MigraDoc.DocumentObjectModel.Shapes.Image image =
                    section.AddImage(imagePath);

                image.LockAspectRatio = true;
                image.Width = Unit.FromCentimeter(24);

                SaveDocument(document, filePath);
            }
            finally
            {
                DeleteTemporaryFiles(temporaryFiles);
            }
        }

        public static void ExportToPdf(
            DataGridView dataGridView,
            int[] columnIndices,
            Chart[] charts,
            string filePath,
            string documentTitle = "Report",
            bool textOnly = true,
            int? imageColumnIndex = null,
            int? progressColumnIndex = null,
            int? progressValueColumnIndex = null,
            double progressMaximum = 10)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            PdfDocument document = CreateDocument(documentTitle);
            Section section = document.LastSection;

            List<int> columns = GetValidColumns(
                dataGridView, columnIndices);

            List<string> temporaryFiles = new List<string>();

            try
            {
                AddDataGridViewTable(
                    section,
                    dataGridView,
                    columns,
                    textOnly,
                    imageColumnIndex,
                    progressColumnIndex,
                    progressValueColumnIndex,
                    progressMaximum,
                    temporaryFiles);

                if (charts != null)
                {
                    int chartNumber = 1;

                    foreach (Chart chart in charts)
                    {
                        if (chart == null)
                            continue;

                        section.AddPageBreak();

                        Paragraph heading = section.AddParagraph(
                            "Chart " + chartNumber);

                        heading.Format.Font.Bold = true;
                        heading.Format.Font.Size = 16;
                        heading.Format.SpaceAfter =
                            Unit.FromCentimeter(0.5);

                        string imagePath = CreateTemporaryImagePath();
                        temporaryFiles.Add(imagePath);

                        chart.SaveImage(
                            imagePath, ChartImageFormat.Png);

                        MigraDoc.DocumentObjectModel.Shapes.Image image =
                            section.AddImage(imagePath);

                        image.LockAspectRatio = true;
                        image.Width = Unit.FromCentimeter(24);

                        chartNumber++;
                    }
                }

                SaveDocument(document, filePath);
            }
            finally
            {
                DeleteTemporaryFiles(temporaryFiles);
            }
        }

        private static PdfDocument CreateDocument(
            string documentTitle)
        {
            PdfDocument document = new PdfDocument();

            document.Info.Title = documentTitle;

            document.Styles[StyleNames.Normal].Font.Name =
                "Arial";

            document.Styles[StyleNames.Normal].Font.Size = 8;

            Section section = document.AddSection();

            section.PageSetup.Orientation =
                MigraDoc.DocumentObjectModel.Orientation.Landscape;

            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(1.5);
            section.PageSetup.LeftMargin = Unit.FromCentimeter(1);
            section.PageSetup.RightMargin = Unit.FromCentimeter(1);

            Paragraph title = section.AddParagraph(documentTitle);

            title.Format.Font.Name = "Arial";
            title.Format.Font.Size = 16;
            title.Format.Font.Bold = true;
            title.Format.SpaceAfter = Unit.FromCentimeter(0.5);
            title.Format.Alignment = ParagraphAlignment.Center;

            return document;
        }

        private static List<int> GetValidColumns(
            DataGridView dataGridView,
            int[] columnIndices)
        {
            return (columnIndices ?? new int[0])
                .Distinct()
                .Where(index =>
                    index >= 0 &&
                    index < dataGridView.Columns.Count)
                .ToList();
        }

        private static void AddDataGridViewTable(
            Section section,
            DataGridView dataGridView,
            List<int> columns,
            bool textOnly,
            int? imageColumnIndex,
            int? progressColumnIndex,
            int? progressValueColumnIndex,
            double progressMaximum,
            List<string> temporaryFiles)
        {
            if (columns.Count == 0)
            {
                section.AddParagraph(
                    "No columns available for export.");

                return;
            }

            Table table = section.AddTable();

            table.Borders.Width = 0.5;
            table.Borders.Color = Colors.LightGray;

            table.TopPadding = Unit.FromPoint(3);
            table.BottomPadding = Unit.FromPoint(3);
            table.LeftPadding = Unit.FromPoint(3);
            table.RightPadding = Unit.FromPoint(3);

            double availableWidth = 27.7;
            double columnWidth = availableWidth / columns.Count;

            foreach (int columnIndex in columns)
            {
                Column column = table.AddColumn(
                    Unit.FromCentimeter(columnWidth));

                column.Format.Alignment =
                    ParagraphAlignment.Left;
            }

            Row headerRow = table.AddRow();

            headerRow.HeadingFormat = true;
            headerRow.Shading.Color = Colors.LightGray;
            headerRow.Format.Font.Bold = true;
            headerRow.Format.Font.Size = 8;

            for (int i = 0; i < columns.Count; i++)
            {
                headerRow.Cells[i].AddParagraph(
                    dataGridView.Columns[columns[i]].HeaderText);
            }

            foreach (DataGridViewRow sourceRow in dataGridView.Rows)
            {
                if (sourceRow.IsNewRow || !sourceRow.Visible)
                    continue;

                Row targetRow = table.AddRow();

                targetRow.VerticalAlignment =
                    VerticalAlignment.Center;

                for (int i = 0; i < columns.Count; i++)
                {
                    int sourceColumn = columns[i];

                    DataGridViewCell sourceCell =
                        sourceRow.Cells[sourceColumn];

                    Cell targetCell = targetRow.Cells[i];

                    object value = sourceCell.Value;

                    if (value == null || value == DBNull.Value)
                        continue;

                    if (!textOnly &&
                        imageColumnIndex == sourceColumn &&
                        value is System.Drawing.Image sourceImage)
                    {
                        string imagePath =
                            CreateTemporaryImagePath();

                        temporaryFiles.Add(imagePath);

                        using (Bitmap bitmap = new Bitmap(sourceImage))
                        {
                            bitmap.Save(
                                imagePath,
                                System.Drawing.Imaging.ImageFormat.Png);
                        }

                        MigraDoc.DocumentObjectModel.Shapes.Image image =
                            targetCell.AddImage(imagePath);

                        image.LockAspectRatio = true;
                        image.Width = Unit.FromCentimeter(2);
                        image.Height = Unit.FromCentimeter(1.5);

                        continue;
                    }

                    if (!textOnly &&
                        progressColumnIndex == sourceColumn &&
                        progressValueColumnIndex.HasValue &&
                        progressValueColumnIndex.Value >= 0 &&
                        progressValueColumnIndex.Value <
                            sourceRow.Cells.Count)
                    {
                        object progressObject =
                            sourceRow.Cells[
                                progressValueColumnIndex.Value].Value;

                        if (double.TryParse(
                            Convert.ToString(
                                progressObject,
                                CultureInfo.CurrentCulture),
                            NumberStyles.Any,
                            CultureInfo.CurrentCulture,
                            out double progress))
                        {
                            double ratio = progressMaximum > 0
                                ? Math.Max(
                                    0,
                                    Math.Min(
                                        progress / progressMaximum,
                                        1))
                                : 0;

                            targetCell.AddParagraph(
                                (ratio * 100).ToString("0") + "%");
                        }

                        continue;
                    }

                    targetCell.AddParagraph(
                        ConvertCellValue(value));
                }
            }

            Paragraph footer =
                section.Footers.Primary.AddParagraph();

            footer.Format.Font.Name = "Arial";
            footer.Format.Font.Size = 8;
            footer.Format.Alignment =
                ParagraphAlignment.Center;

            footer.AddText("Page ");
            footer.AddPageField();
            footer.AddText(" / ");
            footer.AddNumPagesField();
        }

        private static string ConvertCellValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            if (value is DateTime dateValue)
            {
                return dateValue.ToString(
                    "dd.MM.yyyy HH:mm");
            }

            if (value is bool boolValue)
                return boolValue ? "Yes" : "No";

            return Convert.ToString(
                value,
                CultureInfo.CurrentCulture) ?? string.Empty;
        }

        private static string CreateTemporaryImagePath()
        {
            return Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString("N") + ".png");
        }

        private static void SaveDocument(
            PdfDocument document,
            string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException(
                    "File path cannot be empty.",
                    nameof(filePath));
            }

            if (!string.Equals(
                Path.GetExtension(filePath),
                ".pdf",
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "File extension must be .pdf.",
                    nameof(filePath));
            }

            string directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            PdfDocumentRenderer renderer =
                new PdfDocumentRenderer();

            renderer.Document = document;
            renderer.RenderDocument();
            renderer.Save(filePath);

            if (!File.Exists(filePath) ||
                new FileInfo(filePath).Length == 0)
            {
                throw new IOException(
                    "The PDF file could not be created.");
            }
        }

        private static void DeleteTemporaryFiles(
            List<string> temporaryFiles)
        {
            foreach (string filePath in temporaryFiles)
            {
                try
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                catch
                {
                    // Do not interrupt the export if a temporary file cannot be deleted.
                }
            }
        }
    }
}