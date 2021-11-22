using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Management
{
    class CuttingListReport : ReportBase
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
            PrintRow("Square", _order.CustomerInfo.OrderedShape[0].TotalQuantityOfShape().ToString());
            PrintRow("Triangle", _order.CustomerInfo.OrderedShape[1].TotalQuantityOfShape().ToString());
            PrintRow("Circle", _order.CustomerInfo.OrderedShape[2].TotalQuantityOfShape().ToString());
            PrintLine();
        }
    }
}
