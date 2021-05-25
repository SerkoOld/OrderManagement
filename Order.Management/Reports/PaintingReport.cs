using System;

namespace Order.Management.Reports
{
    public class PaintingReport : Report
    {
        public const int TABLE_WIDTH = 73;

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
            PrintRow(
                "Square",
                Order.OrderedBlocks[0].NumberOfRedShape.ToString(),
                Order.OrderedBlocks[0].NumberOfBlueShape.ToString(),
                Order.OrderedBlocks[0].NumberOfYellowShape.ToString());
            PrintRow(
                "Triangle",
                Order.OrderedBlocks[1].NumberOfRedShape.ToString(),
                Order.OrderedBlocks[1].NumberOfBlueShape.ToString(),
                Order.OrderedBlocks[1].NumberOfYellowShape.ToString());
            PrintRow(
                "Circle",
                Order.OrderedBlocks[2].NumberOfRedShape.ToString(),
                Order.OrderedBlocks[2].NumberOfBlueShape.ToString(),
                Order.OrderedBlocks[2].NumberOfYellowShape.ToString());
            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine(new string('-', TABLE_WIDTH));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (TABLE_WIDTH - columns.Length) / columns.Length;
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
