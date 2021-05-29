using System;
using System.Collections.Generic;
using System.Linq;
using Order.Management.Shapes;

namespace Order.Management.Reports
{
    internal class CuttingListReport : BaseReport
    {
        public CuttingListReport(CustomerInfo customerInfo, Order order) : base(customerInfo, order)
        {
            TableWidth = 20;
            ReportName = "cutting list";
        }

        protected override void GenerateTable()
        {
            PrintLine();
            PrintRow("        ", "   Qty   ");
            PrintLine();

            foreach (var groupedOrder in this.Order.OrderedBlocks.GroupBy(o => o.ShapeName))
            {
                PrintRow(groupedOrder.Key, groupedOrder.Sum(o => o.Quantity).ToString());
            }

            PrintLine();
        }
    }
}