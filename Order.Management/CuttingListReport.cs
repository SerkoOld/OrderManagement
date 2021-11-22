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
            foreach (var block in _order.CustomerInfo.OrderedShape)
            {
                PrintRow(block.Name, block.TotalQuantityOfShape().ToString());
            }
            PrintLine();
        }
    }
}
