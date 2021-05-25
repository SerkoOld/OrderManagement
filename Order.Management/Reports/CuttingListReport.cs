using System;

namespace Order.Management.Reports
{
    public class CuttingListReport : Report
    {
        private const int TABLE_WIDTH = 20;

        public CuttingListReport(Order order) : base(order, TABLE_WIDTH)
        {
        }

        public override void GenerateReport()
        {
            Console.WriteLine("\nYour cutting list has been generated: ");
            Console.WriteLine(Order.ToString());
            GenerateTable();
        }

        public void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square", Order.OrderedBlocks[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", Order.OrderedBlocks[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", Order.OrderedBlocks[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
    }
}
