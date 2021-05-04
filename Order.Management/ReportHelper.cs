using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Management
{
    public static class ReportHelper
    {
        public static void GenerateReport(List<Shape> shapes)
        {
            var headerRows = Enum.GetValues(typeof(ShapeColors)).Cast<ShapeColors>().ToList();

            var reportHeader = new List<string> { "        " };
            reportHeader.AddRange(headerRows.Select(headerRow => $"   {headerRow.ToString()}   "));

            PrintLine(Constants.LargeTableWidth);
            PrintRow(Constants.LargeTableWidth, reportHeader.ToArray());
            PrintLine(Constants.LargeTableWidth);

            var headerColumns = Enum.GetValues(typeof(ShapeTypes)).Cast<ShapeTypes>().ToList();
            foreach (var shapeType in headerColumns)
            {
                var reportContent = new List<string> { shapeType.ToString() };

                var shapeColors = Enum.GetValues(typeof(ShapeColors)).Cast<ShapeColors>().ToList();
                reportContent.AddRange(shapeColors.Select(shapeColor => shapes[(int)shapeType].TotalQtyByShapeColor(shapeColor) > 0
                    ? shapes[(int)shapeType].TotalQtyByShapeColor(shapeColor).ToString()
                    : "-"));

                PrintRow(Constants.LargeTableWidth, reportContent.ToArray());
            }

            PrintLine(Constants.LargeTableWidth);
        }

        public static void GenerateCuttingListReport(List<Shape> shapes)
        {
            var shapeTypes = Enum.GetValues(typeof(ShapeTypes)).Cast<ShapeTypes>().ToList();
            var reportHeader = new List<string>() { "        ", "   Qty   " };

            PrintLine(Constants.SmallTableWidth);
            PrintRow(Constants.SmallTableWidth, reportHeader.ToArray());
            PrintLine(Constants.SmallTableWidth);

            foreach (var shapeType in shapeTypes)
            {
                PrintRow(Constants.SmallTableWidth, shapeType.ToString(), shapes[(int)shapeType].TotalQuantityOfShape().ToString());
            }

            PrintLine(Constants.SmallTableWidth);
        }

        #region Hellper Function

        public static void PrintLine(int reportWidth)
        {
            Console.WriteLine(new string('-', reportWidth));
        }

        public static void PrintRow(int reportWidth, params string[] columns)
        {
            int width = (reportWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        #endregion

    }
}
