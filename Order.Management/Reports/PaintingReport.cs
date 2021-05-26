using System;

namespace Order.Management.Reports
{
    public class PaintingReport : Report
    {
        private const int TABLE_WIDTH = 73;

        public PaintingReport(Order order) : base(order, TABLE_WIDTH)
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
    }
}
