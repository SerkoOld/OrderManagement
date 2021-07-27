using System;
using System.Collections.Generic;
using System.Text;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    internal class CuttingListReport : Order
    {
        private const int TableWidth = 20;
        public CuttingListReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(ToString());
            GenerateTable();
        }
        private void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square",OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
        private void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            StringBuilder row = new StringBuilder("|");

            foreach (string column in columns)
            {
                row.Append($"{AlignCentre(column, width)}|");
            }

            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text[..(width - 3)] + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
