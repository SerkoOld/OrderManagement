using System;

namespace Order.Management.Reports
{
    public class CuttingListReport : Report
    {
        private const int tableWidth = 20;
        public CuttingListReport(Order order) : base(order, tableWidth)
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
    }
}
