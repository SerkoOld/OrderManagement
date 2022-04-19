using System;
using System.Collections.Generic;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    public class PaintingReport : Report
    {
        private const int tableWidth = 73;
        public PaintingReport(Order order) : base(order, tableWidth)
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
    }
}
