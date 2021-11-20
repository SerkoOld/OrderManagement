using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : Report
    {
        public CuttingListReport(Order order, int tableWidth)
        : base(order,"cutting list",tableWidth)
        {
        }

        protected override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();
            PrintRow("Square", Order.CustomerInfo.OrderedShape[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", Order.CustomerInfo.OrderedShape[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", Order.CustomerInfo.OrderedShape[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
    }
}
