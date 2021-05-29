using System;
using System.Collections.Generic;
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

        private static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            var width = (TableWidth - columns.Length) / columns.Length;
            var row = "|";

            foreach (var column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
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
