using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class PaintingReport : Report
    {
        public PaintingReport(Order order, int tableWidth)
        : base(order, "painting", tableWidth)
        {
        }

        protected override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Red   ", "  Blue  ", " Yellow ");
            PrintLine();
            PrintRow("Square", Order.CustomerInfo.OrderedShape[0].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[0].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[0].NumberOfYellowShape.ToString());
            PrintRow("Triangle", Order.CustomerInfo.OrderedShape[1].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[1].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[1].NumberOfYellowShape.ToString());
            PrintRow("Circle", Order.CustomerInfo.OrderedShape[2].NumberOfRedShape.ToString(), Order.CustomerInfo.OrderedShape[2].NumberOfBlueShape.ToString(), Order.CustomerInfo.OrderedShape[2].NumberOfYellowShape.ToString());
            PrintLine();
        }
    }
}
