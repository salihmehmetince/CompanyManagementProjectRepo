using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CompanyProjectWindowsFormApp.Helpers
{
    public static class ExcelExportHelper
    {
        public static void ExportToExcel(
            DataGridView dataGridView,
            int[] columnIndices,
            string filePath,
            bool textOnly = true,
            int? iconColumnIndex = null,
            Action<Graphics, Rectangle, string, Color> drawIcon = null,
            int? progressColumnIndex = null,
            int? progressValueColumnIndex = null,
            double progressMaximum = 10,
            int? progressColorColumnIndex = null,
            string worksheetName = "Veriler")
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                List<MemoryStream> imageStreams = new List<MemoryStream>();

                try
                {
                    IXLWorksheet worksheet =
                        workbook.Worksheets.Add(worksheetName);

                    WriteDataGridView(
                        worksheet,
                        dataGridView,
                        columnIndices,
                        textOnly,
                        iconColumnIndex,
                        drawIcon,
                        progressColumnIndex,
                        progressValueColumnIndex,
                        progressMaximum,
                        progressColorColumnIndex,
                        imageStreams);

                    SaveWorkbook(workbook, filePath);
                }
                finally
                {
                    foreach (MemoryStream stream in imageStreams)
                        stream.Dispose();
                }
            }
        }

        public static void ExportToExcel(
            Chart chart,
            string filePath,
            string worksheetName = "Grafik")
        {
            using (XLWorkbook workbook = new XLWorkbook())
            using (MemoryStream imageStream = new MemoryStream())
            {
                IXLWorksheet worksheet =
                    workbook.Worksheets.Add(worksheetName);

                chart.SaveImage(imageStream, ChartImageFormat.Png);
                imageStream.Position = 0;

                worksheet.AddPicture(imageStream)
                    .MoveTo(worksheet.Cell("B2"))
                    .WithSize(700, 400);

                SaveWorkbook(workbook, filePath);
            }
        }

        public static void ExportToExcel(
            DataGridView dataGridView,
            int[] columnIndices,
            Chart[] charts,
            string filePath,
            bool textOnly = true,
            int? iconColumnIndex = null,
            Action<Graphics, Rectangle, string, Color> drawIcon = null,
            int? progressColumnIndex = null,
            int? progressValueColumnIndex = null,
            double progressMaximum = 10,
            int? progressColorColumnIndex = null)
        {
            using (XLWorkbook workbook = new XLWorkbook())
            {
                List<MemoryStream> imageStreams = new List<MemoryStream>();

                try
                {
                    IXLWorksheet dataWorksheet =
                        workbook.Worksheets.Add("Veriler");

                    WriteDataGridView(
                        dataWorksheet,
                        dataGridView,
                        columnIndices,
                        textOnly,
                        iconColumnIndex,
                        drawIcon,
                        progressColumnIndex,
                        progressValueColumnIndex,
                        progressMaximum,
                        progressColorColumnIndex,
                        imageStreams);

                    if (charts != null)
                    {
                        int chartNumber = 1;

                        foreach (Chart chart in charts)
                        {
                            if (chart == null)
                                continue;

                            IXLWorksheet chartWorksheet =
                                workbook.Worksheets.Add(
                                    "Grafik " + chartNumber);

                            MemoryStream stream = new MemoryStream();
                            imageStreams.Add(stream);

                            chart.SaveImage(stream, ChartImageFormat.Png);
                            stream.Position = 0;

                            chartWorksheet.AddPicture(stream)
                                .MoveTo(chartWorksheet.Cell("B2"))
                                .WithSize(700, 400);

                            chartNumber++;
                        }
                    }

                    SaveWorkbook(workbook, filePath);
                }
                finally
                {
                    foreach (MemoryStream stream in imageStreams)
                        stream.Dispose();
                }
            }
        }

        private static void WriteDataGridView(
            IXLWorksheet worksheet,
            DataGridView dataGridView,
            int[] columnIndices,
            bool textOnly,
            int? iconColumnIndex,
            Action<Graphics, Rectangle, string, Color> drawIcon,
            int? progressColumnIndex,
            int? progressValueColumnIndex,
            double progressMaximum,
            int? progressColorColumnIndex,
            List<MemoryStream> imageStreams)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            List<int> columns = (columnIndices ?? Array.Empty<int>())
                .Distinct()
                .Where(index =>
                    index >= 0 &&
                    index < dataGridView.Columns.Count)
                .ToList();

            for (int i = 0; i < columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value =
                    dataGridView.Columns[columns[i]].HeaderText;
            }

            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.LightGray;

            int excelRow = 2;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow || !row.Visible)
                    continue;

                worksheet.Row(excelRow).Height = 25;

                for (int i = 0; i < columns.Count; i++)
                {
                    int sourceColumn = columns[i];
                    DataGridViewCell sourceCell = row.Cells[sourceColumn];
                    IXLCell targetCell = worksheet.Cell(excelRow, i + 1);

                    object value = sourceCell.Value;

                    if (textOnly)
                    {
                        WriteCellValue(targetCell, value);
                        continue;
                    }

                    if (iconColumnIndex == sourceColumn &&
                        drawIcon != null &&
                        value != null)
                    {
                        Color iconColor = GetCellColor(
                            row,
                            sourceColumn,
                            Color.Black);

                        using (Bitmap bitmap = new Bitmap(24, 24))
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.Transparent);
                            graphics.SmoothingMode =
                                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                            drawIcon(
                                graphics,
                                new Rectangle(2, 2, 20, 20),
                                Convert.ToString(value),
                                iconColor);

                            AddBitmap(
                                worksheet,
                                targetCell,
                                bitmap,
                                24,
                                24,
                                imageStreams);
                        }

                        continue;
                    }

                    if (progressColumnIndex == sourceColumn &&
                        progressValueColumnIndex.HasValue &&
                        progressValueColumnIndex.Value >= 0 &&
                        progressValueColumnIndex.Value < row.Cells.Count)
                    {
                        object progressValue =
                            row.Cells[progressValueColumnIndex.Value].Value;

                        if (double.TryParse(
                            Convert.ToString(progressValue),
                            out double progress))
                        {
                            double ratio = progressMaximum > 0
                                ? Math.Max(
                                    0,
                                    Math.Min(progress / progressMaximum, 1))
                                : 0;

                            Color barColor = GetCellColor(
                                row,
                                progressColorColumnIndex ?? sourceColumn,
                                Color.SteelBlue);

                            using (Bitmap bitmap = CreateProgressBitmap(
                                ratio,
                                barColor))
                            {
                                AddBitmap(
                                    worksheet,
                                    targetCell,
                                    bitmap,
                                    100,
                                    18,
                                    imageStreams);
                            }
                        }

                        continue;
                    }

                    WriteCellValue(targetCell, value);
                }

                excelRow++;
            }

            worksheet.Columns().AdjustToContents();

            for (int i = 0; i < columns.Count; i++)
            {
                int sourceColumn = columns[i];

                if (!textOnly &&
                    (sourceColumn == iconColumnIndex ||
                     sourceColumn == progressColumnIndex))
                {
                    worksheet.Column(i + 1).Width =
                        sourceColumn == iconColumnIndex ? 6 : 18;
                }
            }
        }

        private static void WriteCellValue(
            IXLCell cell,
            object value)
        {
            if (value == null || value == DBNull.Value)
                return;

            if (value is DateTime dateValue)
            {
                cell.Value = dateValue;
                cell.Style.DateFormat.Format = "dd.MM.yyyy HH:mm";
            }
            else if (value is bool boolValue)
            {
                cell.Value = boolValue ? "Yes" : "No";
            }
            else if (value is string stringValue)
            {
                cell.Value = stringValue;
            }
            else if (value is int intValue)
            {
                cell.Value = intValue;
            }
            else if (value is long longValue)
            {
                cell.Value = longValue;
            }
            else if (value is decimal decimalValue)
            {
                cell.Value = decimalValue;
            }
            else if (value is double doubleValue)
            {
                cell.Value = doubleValue;
            }
            else if (value is float floatValue)
            {
                cell.Value = floatValue;
            }
            else
            {
                cell.Value = Convert.ToString(value);
            }
        }

        private static Color GetCellColor(
            DataGridViewRow row,
            int columnIndex,
            Color fallbackColor)
        {
            if (columnIndex < 0 || columnIndex >= row.Cells.Count)
                return fallbackColor;

            Color color = row.Cells[columnIndex].Style.ForeColor;

            return color.IsEmpty ? fallbackColor : color;
        }

        private static Bitmap CreateProgressBitmap(
            double ratio,
            Color fillColor)
        {
            Bitmap bitmap = new Bitmap(100, 18);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            using (SolidBrush backgroundBrush =
                new SolidBrush(Color.FromArgb(226, 232, 240)))
            using (SolidBrush fillBrush = new SolidBrush(fillColor))
            using (Pen borderPen = new Pen(Color.LightGray))
            {
                graphics.Clear(Color.White);
                graphics.FillRectangle(backgroundBrush, 0, 2, 98, 14);

                int fillWidth = (int)Math.Round(98 * ratio);

                if (fillWidth > 0)
                    graphics.FillRectangle(fillBrush, 0, 2, fillWidth, 14);

                graphics.DrawRectangle(borderPen, 0, 2, 98, 14);
            }

            return bitmap;
        }

        private static void AddBitmap(
            IXLWorksheet worksheet,
            IXLCell cell,
            Bitmap bitmap,
            int width,
            int height,
            List<MemoryStream> imageStreams)
        {
            MemoryStream stream = new MemoryStream();
            imageStreams.Add(stream);

            bitmap.Save(stream, ImageFormat.Png);
            stream.Position = 0;

            worksheet.AddPicture(stream)
                .MoveTo(cell)
                .WithSize(width, height);
        }

        private static void SaveWorkbook(
            XLWorkbook workbook,
            string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException(
                    "Dosya yolu boş olamaz.",
                    nameof(filePath));

            string directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
                Directory.CreateDirectory(directory);

            workbook.SaveAs(filePath);
        }

        public static void ExportToExcel(
    DataGridView dataGridView,
    int[] columnIndices,
    int bitmapColumnIndex,
    string filePath,
    string worksheetName = "Veriler",
    int imageWidth = 80,
    int imageHeight = 60)
        {
            if (dataGridView == null)
                throw new ArgumentNullException(nameof(dataGridView));

            using (XLWorkbook workbook = new XLWorkbook())
            {
                List<MemoryStream> imageStreams = new List<MemoryStream>();

                try
                {
                    IXLWorksheet worksheet =
                        workbook.Worksheets.Add(worksheetName);

                    List<int> columns = (columnIndices ?? Array.Empty<int>())
                        .Distinct()
                        .Where(index =>
                            index >= 0 &&
                            index < dataGridView.Columns.Count)
                        .ToList();

                    for (int i = 0; i < columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value =
                            dataGridView.Columns[columns[i]].HeaderText;
                    }

                    worksheet.Row(1).Style.Font.Bold = true;
                    worksheet.Row(1).Style.Fill.BackgroundColor = XLColor.LightGray;

                    int excelRow = 2;

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.IsNewRow || !row.Visible)
                            continue;

                        worksheet.Row(excelRow).Height = 25;

                        for (int i = 0; i < columns.Count; i++)
                        {
                            int sourceColumn = columns[i];

                            object value = row.Cells[sourceColumn].Value;

                            IXLCell targetCell =
                                worksheet.Cell(excelRow, i + 1);

                            if (sourceColumn == bitmapColumnIndex)
                            {
                                if (value is Image image)
                                {
                                    using (Bitmap bitmap = new Bitmap(image))
                                    {
                                        MemoryStream stream = new MemoryStream();
                                        imageStreams.Add(stream);

                                        bitmap.Save(stream, ImageFormat.Png);
                                        stream.Position = 0;

                                        worksheet.AddPicture(stream)
                                            .MoveTo(targetCell)
                                            .WithSize(imageWidth, imageHeight);
                                    }

                                    worksheet.Row(excelRow).Height =
                                        Math.Max(25, imageHeight * 0.75 + 5);
                                }
                            }
                            else
                            {
                                WriteCellValue(targetCell, value);
                            }
                        }

                        excelRow++;
                    }

                    worksheet.Columns().AdjustToContents();

                    int excelImageColumn =
                        columns.IndexOf(bitmapColumnIndex) + 1;

                    if (excelImageColumn > 0)
                    {
                        worksheet.Column(excelImageColumn).Width =
                            Math.Max(12, imageWidth / 7.0);
                    }

                    SaveWorkbook(workbook, filePath);
                }
                finally
                {
                    foreach (MemoryStream stream in imageStreams)
                        stream.Dispose();
                }
            }
        }
    }
}