using System;
using System.Collections.Generic;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    public class PaintingReport : Report
    {
        public int tableWidth = 73;
        public PaintingReport(Order order) : base(order)
        {
        }
        public override void GenerateReport()
        {
            Console.WriteLine("\nYour painting report has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }

        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.OrderedShapes[0].NumberOfRedShape.ToString(), Order.OrderedShapes[0].NumberOfBlueShape.ToString(), Order.OrderedShapes[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", Order.OrderedShapes[1].NumberOfRedShape.ToString(), Order.OrderedShapes[1].NumberOfBlueShape.ToString(), Order.OrderedShapes[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", Order.OrderedShapes[2].NumberOfRedShape.ToString(), Order.OrderedShapes[2].NumberOfBlueShape.ToString(), Order.OrderedShapes[2].NumberOfYellowShape.ToString());
            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
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
