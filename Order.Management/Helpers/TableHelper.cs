using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management.Helpers
{
    public static class TableHelper
    {
        private static readonly string[] TableHeader = { "        ", "   Red   ", "  Blue  ", " Yellow " };
        private static readonly string[] CuttingTableHeader = { "        ", "   Qty   " };

        public static void GenerateTable(int tableWidth, List<Shape> orderedBlocks)
        {
            PrintLine(tableWidth);
            PrintRow(tableWidth, TableHeader);
            PrintLine(tableWidth);
            foreach (Shape shape in orderedBlocks)
            {
                PrintRow(
                    tableWidth,
                    shape.Name,
                    shape.NumberOfRedShape.ToString(),
                    shape.NumberOfBlueShape.ToString(),
                    shape.NumberOfYellowShape.ToString());
            }
            PrintLine(tableWidth);
        }

        public static void GenerateCuttingTable(int tableWidth, List<Shape> orderedBlocks)
        {
            PrintLine(tableWidth);
            PrintRow(tableWidth, CuttingTableHeader);
            PrintLine(tableWidth);
            foreach (Shape shape in orderedBlocks)
            {
                PrintRow(
                    tableWidth,
                    shape.Name,
                    shape.TotalQuantityOfShape().ToString());
            }
            PrintLine(tableWidth);
        }

        private static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        private static void PrintRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
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
    }
}
