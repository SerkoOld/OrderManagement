using System;
using System.Collections.Generic;

namespace Order.Management
{
    class PaintingReport : Order
    {
        private int tableWidth = 73;
        public PaintingReport(string customerName, string customerAddress, string dueDate, List<Shape> shapes)
        {
            CustomerName = customerName;
            Address = customerAddress;
            DueDate = dueDate;
            OrderedBlocks = shapes;
            OrderNumber += 1;
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(ToString());
            GenerateTable();            
        }

        private void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", OrderedBlocks[0].NumberOfRedShape.ToString(), OrderedBlocks[0].NumberOfBlueShape.ToString(), OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", OrderedBlocks[1].NumberOfRedShape.ToString(), OrderedBlocks[1].NumberOfBlueShape.ToString(), OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", OrderedBlocks[2].NumberOfRedShape.ToString(), OrderedBlocks[2].NumberOfBlueShape.ToString(), OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
        
        private void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        private void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
        {
            if (text == "0") text = "-";
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}
