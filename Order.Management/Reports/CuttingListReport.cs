using System;

namespace Order.Management.Reports
{
    public class CuttingListReport : Report
    {
        public int tableWidth = 20;
        public CuttingListReport(Order order) : base(order)
        {

        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(base.ToString());
            GenerateTable();
        }
        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square", Order.OrderedShapes[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", Order.OrderedShapes[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", Order.OrderedShapes[2].TotalQuantityOfShape().ToString());
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
