using System;
using System.Collections.Generic;
using System.Text;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    internal class PaintingReport : Order
    {
        private const int TableWidth = 73;
        public PaintingReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            base.CustomerName = customerName;
            base.Address = customerAddress;
            base.DueDate = dueDate;
            base.OrderedBlocks = shapes;
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
        }

        private void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", base.OrderedBlocks[0].NumberOfRedShape.ToString(), base.OrderedBlocks[0].NumberOfBlueShape.ToString(), base.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", base.OrderedBlocks[1].NumberOfRedShape.ToString(), base.OrderedBlocks[1].NumberOfBlueShape.ToString(), base.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", base.OrderedBlocks[2].NumberOfRedShape.ToString(), base.OrderedBlocks[2].NumberOfBlueShape.ToString(), base.OrderedBlocks[2].NumberOfYellowShape.ToString());
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
